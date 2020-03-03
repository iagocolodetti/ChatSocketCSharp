using System;
using System.Drawing;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatSocketCSharp
{
    public partial class ServidorForm : Form
    {
        private const int MIN_PORTA = 0;
        private const int MAX_PORTA = 65535;
        
        private Servidor servidor;
        private List<Cliente> clientes;

        private bool formClosing = false;

        public ServidorForm()
        {
            InitializeComponent();
            clientes = new List<Cliente>();
        }

        private void AddMensagem(string text)
        {
            BeginInvoke(new Action(() =>
            {
                if (rtbChat.Text.Length == 0)
                {
                    rtbChat.AppendText(text);
                }
                else
                {
                    rtbChat.AppendText("\n" + text);
                }
            }));
        }

        private void SetTbIP(string ip)
        {
            BeginInvoke(new Action(() =>
            {
                tbIP.Text = ip;
            }));
        }

        private void AddParticipante(string ip, string nome)
        {
            BeginInvoke(new Action(() =>
            {
                dgvParticipantes.Rows.Add(ip, nome);
            }));
        }

        private void RemoverParticipante(string ip, string nome)
        {
            BeginInvoke(new Action(() =>
            {
                for (int i = 0; i < dgvParticipantes.Rows.Count; i++)
                {
                    if (dgvParticipantes.Rows[i].Cells[0].Value.Equals(ip) && dgvParticipantes.Rows[i].Cells[1].Value.Equals(nome))
                    {
                        dgvParticipantes.Rows.RemoveAt(i);
                        break;
                    }
                }
            }));
        }

        private string GetParticipantes()
        {
            string participantes = "";
            for (int i = 0; i < dgvParticipantes.Rows.Count; i++)
            {
                participantes += dgvParticipantes.Rows[i].Cells[1].Value + " ";
            }
            return participantes;
        }

        private void SetServidorLigado(int porta)
        {
            if (porta != -1)
            {
                btLigar.Text = "DESLIGAR";
                tbPorta.ReadOnly = true;
                tbPorta.BackColor = Color.FromArgb(255, 227, 227, 227);
                btEnviar.Enabled = true;
                servidor = new Servidor(this, porta);
                Thread thread = new Thread(new ThreadStart(servidor.Run));
                thread.Start();
            }
            else if (btLigar.Text.Equals("DESLIGAR"))
            {
                btLigar.Text = "LIGAR";
                foreach (Cliente cliente in clientes)
                {
                    cliente.Fechar();
                }
                if (servidor != null)
                {
                    servidor.Fechar();
                }
                servidor = null;
                clientes.Clear();
                dgvParticipantes.Rows.Clear();
                tbPorta.ReadOnly = false;
                tbPorta.BackColor = Color.FromArgb(255, 255, 255, 255);
                SetTbIP(string.Empty);
                btEnviar.Enabled = false;
                AddMensagem("Chat desligado.");
            }
        }

        private void EnviarMensagem()
        {
            if (btLigar.Text.Equals("DESLIGAR") && servidor != null)
            {
                string mensagem = rtbMensagem.Text;
                if (!string.IsNullOrEmpty(mensagem.Trim()))
                {
                    try
                    {
                        rtbMensagem.Text = string.Empty;
                        rtbMensagem.Focus();
                        servidor.Enviar(mensagem.Trim());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        MessageBox.Show("Não foi possível enviar a mensagem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    rtbMensagem.Text = string.Empty;
                    MessageBox.Show("O campo destinado a mensagem está vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private class Servidor
        {
            private TcpListener listener;
            private TcpClient client;

            private volatile bool ligado;

            private ServidorForm servidorForm;
            private readonly int porta;

            public Servidor(ServidorForm servidorForm, int porta)
            {
                ligado = true;
                this.servidorForm = servidorForm;
                this.porta = porta;
            }

            public void Fechar()
            {
                ligado = false;
                try
                {
                    if (client != null)
                    {
                        client.Close();
                    }
                    if (listener != null)
                    {
                        listener.Stop();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    client = null;
                    listener = null;
                }
            }

            public void Enviar(string mensagem)
            {
                if (ligado)
                {
                    try
                    {
                        foreach (Cliente cliente in servidorForm.clientes)
                        {
                            cliente.Enviar("m", "Servidor: " + mensagem.Trim());
                        }
                        servidorForm.AddMensagem("Você: " + mensagem.Trim());
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }

            private IPAddress GetLocalIP()
            {
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress localIP in localIPs)
                {
                    if (localIP.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return localIP;
                    }
                }
                return null;
            }

            public void Run()
            {
                try
                {
                    IPAddress ipLocal = GetLocalIP();
                    try
                    {
                        listener = new TcpListener(ipLocal, porta);
                        listener.Start();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        MessageBox.Show("Não foi possível ligar o serviço, verifique se a porta já está em uso ou se a rede está funcionando.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        servidorForm.SetServidorLigado(-1);
                        return;
                    }
                    servidorForm.SetTbIP(ipLocal.ToString());
                    servidorForm.AddMensagem("Chat ligado.");
                    while (ligado)
                    {
                        client = listener.AcceptTcpClient();
                        Cliente cliente = new Cliente(servidorForm, client);
                        servidorForm.clientes.Add(cliente);
                        Thread thread = new Thread(new ThreadStart(cliente.Run));
                        thread.Start();
                    }
                }
                catch (Exception)
                {
                    if (!servidorForm.formClosing)
                    {
                        servidorForm.SetServidorLigado(-1);
                    }
                }
            }
        }

        private class Cliente
        {
            private TcpClient client;

            private ServidorForm servidorForm;
            private readonly string ip;
            private string nome;

            private volatile bool conectado;

            public Cliente(ServidorForm servidorForm, TcpClient client)
            {
                conectado = true;
                this.servidorForm = servidorForm;
                ip = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                this.client = client;
            }

            public string GetNome()
            {
                return nome;
            }

            public void Fechar()
            {
                try
                {
                    if (client != null)
                    {
                        Enviar("e", "");
                        conectado = false;
                        client.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    client = null;
                }
            }

            public void Enviar(string tipo, string mensagem)
            {
                if (conectado)
                {
                    try
                    {
                        NetworkStream ns = client.GetStream();
                        byte[] sendBytes = Encoding.UTF8.GetBytes(tipo + mensagem);
                        ns.Write(sendBytes, 0, sendBytes.Length);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }

            public void Run()
            {
                try
                {
                    NetworkStream ns = client.GetStream();
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = ns.Read(buffer, 0, client.ReceiveBufferSize);
                    nome = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    if (string.IsNullOrEmpty(nome))
                    {
                        Enviar("m", "Você precisa fornecer um nome.");
                        servidorForm.clientes.Remove(this);
                        Fechar();
                        return;
                    }
                    if (nome.Length < 3 || nome.Length > 20 || nome.Contains(" "))
                    {
                        Enviar("m", "O nome deve ter de 3 à 20 caracteres e não pode ter espaços.");
                        servidorForm.clientes.Remove(this);
                        Fechar();
                        return;
                    }
                    if (nome.ToLower().Equals("servidor"))
                    {
                        Enviar("m", "O nome 'Servidor' é reservado.");
                        servidorForm.clientes.Remove(this);
                        Fechar();
                        return;
                    }
                    foreach (Cliente cliente in servidorForm.clientes)
                    {
                        if (!this.Equals(cliente) && nome.ToLower().Equals(cliente.GetNome().ToLower()))
                        {
                            Enviar("m", "O nome '" + nome + "' já está em uso.");
                            servidorForm.clientes.Remove(this);
                            Fechar();
                            return;
                        }
                    }
                    servidorForm.AddMensagem(nome + " entrou no chat. (" + ip + ")");
                    Enviar("p", nome + " " + servidorForm.GetParticipantes());
                    servidorForm.AddParticipante(ip, nome);
                    foreach (Cliente cliente in servidorForm.clientes)
                    {
                        if (!this.Equals(cliente))
                        {
                            cliente.Enviar("e", nome + " entrou no chat.");
                        }
                    }
                }
                catch (Exception)
                {
                    servidorForm.clientes.Remove(this);
                    Fechar();
                }
                int mensagensVazias = 0;
                while (conectado)
                {
                    try
                    {
                        NetworkStream ns = client.GetStream();
                        byte[] buffer = new byte[client.ReceiveBufferSize];
                        int bytesRead = ns.Read(buffer, 0, client.ReceiveBufferSize);
                        string mensagem = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        if (!string.IsNullOrEmpty(mensagem))
                        {
                            mensagensVazias = 0;
                            servidorForm.AddMensagem(nome + ": " + mensagem);
                            foreach (Cliente cliente in servidorForm.clientes)
                            {
                                if (!this.Equals(cliente))
                                {
                                    cliente.Enviar("m", nome + ": " + mensagem);
                                }
                            }
                        }
                        else if (mensagensVazias == 3)
                        {
                            throw new SocketException();
                        }
                        else
                        {
                            mensagensVazias++;
                        }
                    }
                    catch (Exception)
                    {
                        if (conectado)
                        {
                            servidorForm.AddMensagem(nome + " saiu do chat. (" + ip + ")");
                            servidorForm.clientes.Remove(this);
                            servidorForm.RemoverParticipante(ip, nome);
                            try
                            {
                                foreach (Cliente cliente in servidorForm.clientes)
                                {
                                    cliente.Enviar("s", nome + " saiu do chat.");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            finally
                            {
                                Fechar();
                            }
                        }
                    }
                }
            }
        }

        private void BtLigar_Click(object sender, EventArgs e)
        {
            if (btLigar.Text.Equals("LIGAR"))
            {
                string sPorta = tbPorta.Text.Trim();
                if (!string.IsNullOrEmpty(sPorta))
                {
                    try
                    {
                        int porta = int.Parse(sPorta);
                        if (porta >= MIN_PORTA && porta <= MAX_PORTA)
                        {
                            SetServidorLigado(porta);
                        }
                        else
                        {
                            MessageBox.Show("O número da porta deve ser um inteiro positivo de no mínimo " + MIN_PORTA + " e no máximo " + MAX_PORTA + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("A porta deve ser um número inteiro positivo de no mínimo " + MIN_PORTA + " e no máximo " + MAX_PORTA + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Digite a porta em que deseja ligar o serviço.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                SetServidorLigado(-1);
            }
        }

        private void BtLimparChat_Click(object sender, EventArgs e)
        {
            rtbChat.Clear();
        }

        private void BtLimparMensagem_Click(object sender, EventArgs e)
        {
            rtbMensagem.Clear();
        }

        private void BtEnviar_Click(object sender, EventArgs e)
        {
            EnviarMensagem();
        }

        private void RtbMensagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btLigar.Text.Equals("DESLIGAR") && servidor != null)
            {
                EnviarMensagem();
            }
        }

        private void RtbMensagem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btLigar.Text.Equals("DESLIGAR") && servidor != null)
            {
                rtbMensagem.Text = rtbMensagem.Text.Trim();
            }
        }

        private void ServidorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            formClosing = true;
            foreach (Cliente cliente in clientes)
            {
                cliente.Fechar();
            }
            if (servidor != null)
            {
                servidor.Fechar();
            }
        }
    }
}
