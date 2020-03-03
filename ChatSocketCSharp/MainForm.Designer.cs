namespace ChatSocketCSharp
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.rbServidor = new System.Windows.Forms.RadioButton();
            this.rbCliente = new System.Windows.Forms.RadioButton();
            this.btIniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione o que deseja iniciar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbServidor
            // 
            this.rbServidor.AutoSize = true;
            this.rbServidor.Checked = true;
            this.rbServidor.Location = new System.Drawing.Point(64, 76);
            this.rbServidor.Name = "rbServidor";
            this.rbServidor.Size = new System.Drawing.Size(78, 22);
            this.rbServidor.TabIndex = 1;
            this.rbServidor.TabStop = true;
            this.rbServidor.Text = "Servidor";
            this.rbServidor.UseVisualStyleBackColor = true;
            this.rbServidor.CheckedChanged += new System.EventHandler(this.RbServidor_CheckedChanged);
            // 
            // rbCliente
            // 
            this.rbCliente.AutoSize = true;
            this.rbCliente.Location = new System.Drawing.Point(252, 76);
            this.rbCliente.Name = "rbCliente";
            this.rbCliente.Size = new System.Drawing.Size(68, 22);
            this.rbCliente.TabIndex = 2;
            this.rbCliente.Text = "Cliente";
            this.rbCliente.UseVisualStyleBackColor = true;
            this.rbCliente.CheckedChanged += new System.EventHandler(this.RbCliente_CheckedChanged);
            // 
            // btIniciar
            // 
            this.btIniciar.Location = new System.Drawing.Point(117, 130);
            this.btIniciar.Name = "btIniciar";
            this.btIniciar.Size = new System.Drawing.Size(151, 26);
            this.btIniciar.TabIndex = 3;
            this.btIniciar.Text = "Iniciar";
            this.btIniciar.UseVisualStyleBackColor = true;
            this.btIniciar.Click += new System.EventHandler(this.BtIniciar_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(384, 181);
            this.Controls.Add(this.btIniciar);
            this.Controls.Add(this.rbCliente);
            this.Controls.Add(this.rbServidor);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChatSocket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbServidor;
        private System.Windows.Forms.RadioButton rbCliente;
        private System.Windows.Forms.Button btIniciar;
    }
}

