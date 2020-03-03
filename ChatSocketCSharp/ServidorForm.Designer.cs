namespace ChatSocketCSharp
{
    partial class ServidorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPorta = new System.Windows.Forms.TextBox();
            this.btLigar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btEnviar = new System.Windows.Forms.Button();
            this.btLimparMensagem = new System.Windows.Forms.Button();
            this.btLimparChat = new System.Windows.Forms.Button();
            this.rtbMensagem = new System.Windows.Forms.RichTextBox();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvParticipantes = new System.Windows.Forms.DataGridView();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipantes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // tbIP
            // 
            this.tbIP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbIP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbIP.Location = new System.Drawing.Point(149, 21);
            this.tbIP.Name = "tbIP";
            this.tbIP.ReadOnly = true;
            this.tbIP.Size = new System.Drawing.Size(167, 23);
            this.tbIP.TabIndex = 1;
            this.tbIP.TabStop = false;
            this.tbIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Porta:";
            // 
            // tbPorta
            // 
            this.tbPorta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbPorta.Location = new System.Drawing.Point(391, 21);
            this.tbPorta.Name = "tbPorta";
            this.tbPorta.Size = new System.Drawing.Size(75, 23);
            this.tbPorta.TabIndex = 3;
            this.tbPorta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btLigar
            // 
            this.btLigar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btLigar.Location = new System.Drawing.Point(505, 21);
            this.btLigar.Name = "btLigar";
            this.btLigar.Size = new System.Drawing.Size(144, 24);
            this.btLigar.TabIndex = 4;
            this.btLigar.Text = "LIGAR";
            this.btLigar.UseVisualStyleBackColor = true;
            this.btLigar.Click += new System.EventHandler(this.BtLigar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btEnviar);
            this.groupBox2.Controls.Add(this.btLimparMensagem);
            this.groupBox2.Controls.Add(this.btLimparChat);
            this.groupBox2.Controls.Add(this.rtbMensagem);
            this.groupBox2.Controls.Add(this.rtbChat);
            this.groupBox2.Location = new System.Drawing.Point(297, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 439);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chat";
            // 
            // btEnviar
            // 
            this.btEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btEnviar.Enabled = false;
            this.btEnviar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnviar.Location = new System.Drawing.Point(348, 410);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(124, 23);
            this.btEnviar.TabIndex = 12;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.BtEnviar_Click);
            // 
            // btLimparMensagem
            // 
            this.btLimparMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btLimparMensagem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimparMensagem.Location = new System.Drawing.Point(150, 410);
            this.btLimparMensagem.Name = "btLimparMensagem";
            this.btLimparMensagem.Size = new System.Drawing.Size(121, 23);
            this.btLimparMensagem.TabIndex = 11;
            this.btLimparMensagem.Text = "Limpar Mensagem";
            this.btLimparMensagem.UseVisualStyleBackColor = true;
            this.btLimparMensagem.Click += new System.EventHandler(this.BtLimparMensagem_Click);
            // 
            // btLimparChat
            // 
            this.btLimparChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btLimparChat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimparChat.Location = new System.Drawing.Point(6, 410);
            this.btLimparChat.Name = "btLimparChat";
            this.btLimparChat.Size = new System.Drawing.Size(121, 23);
            this.btLimparChat.TabIndex = 10;
            this.btLimparChat.Text = "Limpar Chat";
            this.btLimparChat.UseVisualStyleBackColor = true;
            this.btLimparChat.Click += new System.EventHandler(this.BtLimparChat_Click);
            // 
            // rtbMensagem
            // 
            this.rtbMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMensagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbMensagem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMensagem.Location = new System.Drawing.Point(6, 321);
            this.rtbMensagem.Name = "rtbMensagem";
            this.rtbMensagem.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbMensagem.Size = new System.Drawing.Size(466, 83);
            this.rtbMensagem.TabIndex = 9;
            this.rtbMensagem.Text = "";
            this.rtbMensagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RtbMensagem_KeyDown);
            this.rtbMensagem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RtbMensagem_KeyUp);
            // 
            // rtbChat
            // 
            this.rtbChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChat.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbChat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChat.Location = new System.Drawing.Point(6, 23);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbChat.Size = new System.Drawing.Size(466, 292);
            this.rtbChat.TabIndex = 8;
            this.rtbChat.TabStop = false;
            this.rtbChat.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dgvParticipantes);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 439);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Participantes";
            // 
            // dgvParticipantes
            // 
            this.dgvParticipantes.AllowUserToAddRows = false;
            this.dgvParticipantes.AllowUserToDeleteRows = false;
            this.dgvParticipantes.AllowUserToResizeRows = false;
            this.dgvParticipantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParticipantes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvParticipantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvParticipantes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParticipantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvParticipantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IP,
            this.Nome});
            this.dgvParticipantes.Location = new System.Drawing.Point(6, 23);
            this.dgvParticipantes.MultiSelect = false;
            this.dgvParticipantes.Name = "dgvParticipantes";
            this.dgvParticipantes.ReadOnly = true;
            this.dgvParticipantes.RowHeadersVisible = false;
            this.dgvParticipantes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvParticipantes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvParticipantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParticipantes.Size = new System.Drawing.Size(267, 410);
            this.dgvParticipantes.TabIndex = 6;
            this.dgvParticipantes.TabStop = false;
            // 
            // IP
            // 
            this.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IP.DividerWidth = 1;
            this.IP.HeaderText = "IP";
            this.IP.MinimumWidth = 115;
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.Width = 115;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nome.DividerWidth = 1;
            this.Nome.HeaderText = "Nome";
            this.Nome.MinimumWidth = 100;
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // ServidorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 501);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btLigar);
            this.Controls.Add(this.tbPorta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 540);
            this.Name = "ServidorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChatSocket (Servidor)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServidorForm_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPorta;
        private System.Windows.Forms.Button btLigar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvParticipantes;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.Button btLimparMensagem;
        private System.Windows.Forms.Button btLimparChat;
        private System.Windows.Forms.RichTextBox rtbMensagem;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
    }
}