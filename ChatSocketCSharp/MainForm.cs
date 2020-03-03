using System;
using System.Windows.Forms;

namespace ChatSocketCSharp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void RbServidor_CheckedChanged(object sender, EventArgs e)
        {
            rbCliente.Checked = !rbServidor.Checked;
        }

        private void RbCliente_CheckedChanged(object sender, EventArgs e)
        {
            rbServidor.Checked = !rbCliente.Checked;
        }

        private void BtIniciar_Click(object sender, EventArgs e)
        {
            if (rbServidor.Checked)
            {
                this.Hide();
                ServidorForm servidorForm = new ServidorForm();
                servidorForm.Closed += (s, args) => this.Close();
                servidorForm.Show();
            }
            else if (rbCliente.Checked)
            {
                this.Hide();
                ClienteForm clienteForm = new ClienteForm();
                clienteForm.Closed += (s, args) => this.Close();
                clienteForm.Show();
            }
        }
    }
}
