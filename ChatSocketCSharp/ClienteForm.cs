using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatSocketCSharp
{
    public partial class ClienteForm : Form
    {
        private const int MIN_PORTA = 0;
        private const int MAX_PORTA = 65535;

        private Cliente cliente;

        public ClienteForm()
        {
            InitializeComponent();
        }

        private void AddMensagem(string text)
        {
            BeginInvoke(new Action(() =>
            {
                if (rtbChat.Text.Length == 0)
                {
                    rtbChat.AppendText(text);
                }
                else if (!string.IsNullOrEmpty(text))
                {
                    rtbChat.AppendText("\n" + text);
                }
            }));
        }

        private void AddParticipantes(string[] nomes)
        {
            BeginInvoke(new Action(() =>
            {
                foreach (string nome in nomes)
                {
                    if (!string.IsNullOrEmpty(nome))
                    {
                        dgvParticipantes.Rows.Add(nome);
                    }
                }
            }));
        }

        private void AddParticipante(string nome)
        {
            BeginInvoke(new Action(() =>
            {
                dgvParticipantes.Rows.Add(nome);
            }));
        }

        private void RemoverParticipante(string nome)
        {
            BeginInvoke(new Action(() =>
            {
                for (int i = 0; i < dgvParticipantes.Rows.Count; i++)
                {
                    if (dgvParticipantes.Rows[i].Cells[0].Value.Equals(nome))
                    {
                        dgvParticipantes.Rows.RemoveAt(i);
                        break;
                    }
                }
            }));
        }

        private void Conectar(string ip, int porta, string nome)
        {
            tbIP.ReadOnly = true;
            tbIP.BackColor = Color.FromArgb(255, 227, 227, 227);
            tbPorta.ReadOnly = true;
            tbPorta.BackColor = Color.FromArgb(255, 227, 227, 227);
            tbNome.ReadOnly = true;
            tbNome.BackColor = Color.FromArgb(255, 227, 227, 227);
            btConectar.Text = "DESCONECTAR";
            btEnviar.Enabled = true;
            cliente = new Cliente(this, ip, porta, nome);
            Thread thread = new Thread(new ThreadStart(cliente.Run));
            thread.Start();
        }

        private void Desconectar()
        {
            if (cliente != null)
            {
                cliente.Fechar();
            }
            cliente = null;
            dgvParticipantes.Rows.Clear();
            tbIP.ReadOnly = false;
            tbIP.BackColor = Color.FromArgb(255, 255, 255, 255);
            tbPorta.ReadOnly = false;
            tbPorta.BackColor = Color.FromArgb(255, 255, 255, 255);
            tbNome.ReadOnly = false;
            tbNome.BackColor = Color.FromArgb(255, 255, 255, 255);
            btConectar.Text = "CONECTAR";
            btEnviar.Enabled = false;
        }

        private void ProcessarMensagem(string mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem))
            {
                switch (mensagem[0])
                {
                    case 'm':
                        AddMensagem(mensagem.Substring(1));
                        break;
                    case 'e':
                        AddMensagem(mensagem.Substring(1));
                        AddParticipante(mensagem.Substring(1, mensagem.IndexOf(" ")));
                        break;
                    case 's':
                        AddMensagem(mensagem.Substring(1));
                        RemoverParticipante(mensagem.Substring(1, mensagem.IndexOf(" ")));
                        break;
                    case 'p':
                        AddMensagem("Você entrou no chat.");
                        AddParticipantes(mensagem.Substring(1).Split(' '));
                        break;
                    case 'c':
                        AddMensagem("Conexão encerrada.");
                        Desconectar();
                        break;
                }
            }
        }

        private void EnviarMensagem()
        {
            if (btConectar.Text.Equals("DESCONECTAR") && cliente != null)
            {
                string mensagem = rtbMensagem.Text;
                if (!string.IsNullOrEmpty(mensagem))
                {
                    try
                    {
                        rtbMensagem.Clear();
                        cliente.Enviar(mensagem.Trim());
                        rtbMensagem.Focus();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        MessageBox.Show("Não foi possível enviar a mensagem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("O campo destinado a mensagem está vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private class Cliente
        {
            private TcpClient client;

            private volatile bool conectado;

            private ClienteForm clienteForm;

            private readonly string ip;
            private readonly int porta;
            private readonly string nome;

            public Cliente(ClienteForm clienteForm, string ip, int porta, string nome)
            {
                conectado = true;
                this.clienteForm = clienteForm;
                this.ip = ip;
                this.porta = porta;
                this.nome = nome;
            }

            public void Fechar()
            {
                conectado = false;
                try
                {
                    if (client != null)
                    {
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

            public void Enviar(string mensagem)
            {
                if (conectado)
                {
                    try
                    {
                        NetworkStream ns = client.GetStream();
                        byte[] sendBytes = Encoding.UTF8.GetBytes(mensagem);
                        ns.Write(sendBytes, 0, sendBytes.Length);
                        clienteForm.AddMensagem("Você: " + mensagem.Trim());
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
                    client = new TcpClient(ip, porta);
                    try
                    {
                        NetworkStream ns = client.GetStream();
                        byte[] sendBytes = Encoding.UTF8.GetBytes(nome);
                        ns.Write(sendBytes, 0, sendBytes.Length);
                    }
                    catch (Exception)
                    {
                        if (conectado)
                        {
                            clienteForm.AddMensagem("Conexão encerrada.");
                        }
                        clienteForm.Desconectar();
                        return;
                    }
                    while (conectado)
                    {
                        try
                        {
                            NetworkStream ns = client.GetStream();
                            byte[] buffer = new byte[client.ReceiveBufferSize];
                            int bytesRead = ns.Read(buffer, 0, client.ReceiveBufferSize);
                            string mensagem = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            clienteForm.ProcessarMensagem(mensagem);
                        }
                        catch (Exception)
                        {
                            if (conectado)
                            {
                                clienteForm.AddMensagem("Conexão encerrada.");
                            }
                            clienteForm.Desconectar();
                        }
                    }
                }
                catch (Exception e)
                {
                    if (conectado)
                    {
                        Console.WriteLine(e);
                        MessageBox.Show("Não foi possível realizar a conexão. Verifique se o servidor está aberto e se o ip e a porta estão corretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clienteForm.Desconectar();
                    }
                }
            }
        }

        private void BtConectar_Click(object sender, EventArgs e)
        {
            if (btConectar.Text.Equals("CONECTAR"))
            {
                string ip = tbIP.Text.Trim();
                if (!string.IsNullOrEmpty(ip))
                {
                    string sPorta = tbPorta.Text.Trim();
                    if (!string.IsNullOrEmpty(sPorta))
                    {
                        try
                        {
                            int porta = int.Parse(sPorta);
                            if (porta >= MIN_PORTA && porta <= MAX_PORTA)
                            {
                                string nome = tbNome.Text.Trim();
                                if (!string.IsNullOrEmpty(nome))
                                {
                                    Conectar(ip, porta, nome);
                                }
                                else
                                {
                                    MessageBox.Show("Digite o nome de usuário que pretende usar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
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
                        MessageBox.Show("Digite a porta do servidor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Digite o ip do servidor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AddMensagem("Você saiu do chat.");
                Desconectar();
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
            if (e.KeyCode == Keys.Enter && btConectar.Text.Equals("DESCONECTAR") && cliente != null)
            {
                EnviarMensagem();
            }
        }

        private void RtbMensagem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btConectar.Text.Equals("DESCONECTAR") && cliente != null)
            {
                rtbMensagem.Text = rtbMensagem.Text.Trim();
            }
        }

        private void ClienteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cliente != null)
            {
                cliente.Fechar();
            }
            cliente = null;
        }
    }
}
