namespace Client
{
    partial class Client
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.pnlConnectionStatus = new System.Windows.Forms.Panel();
            this.lstStatus = new System.Windows.Forms.ListBox();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.tlsStatus = new System.Windows.Forms.ToolStrip();
            this.lblConnected = new System.Windows.Forms.ToolStripLabel();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.grpInput.SuspendLayout();
            this.pnlConnectionStatus.SuspendLayout();
            this.grpOutput.SuspendLayout();
            this.tlsStatus.SuspendLayout();
            this.grpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.txtInput);
            this.grpInput.Controls.Add(this.btnSend);
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpInput.Location = new System.Drawing.Point(0, 521);
            this.grpInput.MinimumSize = new System.Drawing.Size(0, 75);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(469, 75);
            this.grpInput.TabIndex = 2;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            this.grpInput.Visible = false;
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Location = new System.Drawing.Point(3, 16);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(463, 20);
            this.txtInput.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(3, 42);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(107, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSendClick);
            // 
            // pnlConnectionStatus
            // 
            this.pnlConnectionStatus.BackColor = System.Drawing.SystemColors.Control;
            this.pnlConnectionStatus.Controls.Add(this.lstStatus);
            this.pnlConnectionStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConnectionStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlConnectionStatus.Name = "pnlConnectionStatus";
            this.pnlConnectionStatus.Size = new System.Drawing.Size(469, 133);
            this.pnlConnectionStatus.TabIndex = 3;
            // 
            // lstStatus
            // 
            this.lstStatus.BackColor = System.Drawing.Color.Firebrick;
            this.lstStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStatus.FormattingEnabled = true;
            this.lstStatus.Location = new System.Drawing.Point(0, 0);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(469, 133);
            this.lstStatus.TabIndex = 0;
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.txtOutput);
            this.grpOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOutput.Location = new System.Drawing.Point(0, 206);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(469, 315);
            this.grpOutput.TabIndex = 0;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            this.grpOutput.Visible = false;
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Enabled = false;
            this.txtOutput.Location = new System.Drawing.Point(3, 16);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(463, 296);
            this.txtOutput.TabIndex = 0;
            // 
            // tlsStatus
            // 
            this.tlsStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnected});
            this.tlsStatus.Location = new System.Drawing.Point(0, 596);
            this.tlsStatus.Name = "tlsStatus";
            this.tlsStatus.Size = new System.Drawing.Size(469, 25);
            this.tlsStatus.TabIndex = 4;
            this.tlsStatus.Text = "toolStrip1";
            // 
            // lblConnected
            // 
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(79, 22);
            this.lblConnected.Text = "Disconnected";
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.label2);
            this.grpLogin.Controls.Add(this.lblUser);
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Controls.Add(this.txtPass);
            this.grpLogin.Controls.Add(this.txtUser);
            this.grpLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLogin.Location = new System.Drawing.Point(0, 133);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(469, 73);
            this.grpLogin.TabIndex = 1;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Credentials";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(52, 22);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "User:";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(347, 19);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(110, 46);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLoginClick);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(102, 45);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(239, 20);
            this.txtPass.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(102, 19);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(239, 20);
            this.txtUser.TabIndex = 0;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 621);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.grpLogin);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.pnlConnectionStatus);
            this.Controls.Add(this.tlsStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.pnlConnectionStatus.ResumeLayout(false);
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            this.tlsStatus.ResumeLayout(false);
            this.tlsStatus.PerformLayout();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel pnlConnectionStatus;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ListBox lstStatus;
        private System.Windows.Forms.ToolStrip tlsStatus;
        private System.Windows.Forms.ToolStripLabel lblConnected;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUser;
    }
}

