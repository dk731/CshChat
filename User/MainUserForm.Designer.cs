namespace WindowsFormsApp1
{
    partial class MainUserForm
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
            this.InputText = new System.Windows.Forms.TextBox();
            this.IpInputTB = new System.Windows.Forms.TextBox();
            this.EnterIP = new System.Windows.Forms.Label();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.SendBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.SetNameBtn = new System.Windows.Forms.Button();
            this.OutputText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // InputText
            // 
            this.InputText.Enabled = false;
            this.InputText.Location = new System.Drawing.Point(12, 684);
            this.InputText.Multiline = true;
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(594, 57);
            this.InputText.TabIndex = 1;
            this.InputText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InputText_KeyUp);
            // 
            // IpInputTB
            // 
            this.IpInputTB.Location = new System.Drawing.Point(662, 115);
            this.IpInputTB.Name = "IpInputTB";
            this.IpInputTB.Size = new System.Drawing.Size(198, 20);
            this.IpInputTB.TabIndex = 2;
            this.IpInputTB.Text = "localhost";
            // 
            // EnterIP
            // 
            this.EnterIP.AutoSize = true;
            this.EnterIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterIP.Location = new System.Drawing.Point(700, 92);
            this.EnterIP.Name = "EnterIP";
            this.EnterIP.Size = new System.Drawing.Size(128, 20);
            this.EnterIP.TabIndex = 3;
            this.EnterIP.Text = "Enter Server\'s IP";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBtn.Location = new System.Drawing.Point(691, 179);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(137, 114);
            this.ConnectBtn.TabIndex = 4;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // SendBtn
            // 
            this.SendBtn.Enabled = false;
            this.SendBtn.Location = new System.Drawing.Point(612, 696);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(105, 31);
            this.SendBtn.TabIndex = 5;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(722, 153);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(93, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "11000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(678, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Port";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(652, 12);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(43, 13);
            this.StatusLabel.TabIndex = 8;
            this.StatusLabel.Text = "Status :";
            // 
            // NameTB
            // 
            this.NameTB.Enabled = false;
            this.NameTB.Location = new System.Drawing.Point(695, 299);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(133, 20);
            this.NameTB.TabIndex = 9;
            this.NameTB.Text = "...";
            // 
            // SetNameBtn
            // 
            this.SetNameBtn.Enabled = false;
            this.SetNameBtn.Location = new System.Drawing.Point(695, 326);
            this.SetNameBtn.Name = "SetNameBtn";
            this.SetNameBtn.Size = new System.Drawing.Size(130, 23);
            this.SetNameBtn.TabIndex = 10;
            this.SetNameBtn.Text = "Set Name";
            this.SetNameBtn.UseVisualStyleBackColor = true;
            this.SetNameBtn.Click += new System.EventHandler(this.SetNameBtn_Click);
            // 
            // OutputText
            // 
            this.OutputText.Enabled = false;
            this.OutputText.Location = new System.Drawing.Point(12, 12);
            this.OutputText.Name = "OutputText";
            this.OutputText.ReadOnly = true;
            this.OutputText.Size = new System.Drawing.Size(634, 666);
            this.OutputText.TabIndex = 11;
            this.OutputText.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 753);
            this.Controls.Add(this.OutputText);
            this.Controls.Add(this.SetNameBtn);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.EnterIP);
            this.Controls.Add(this.IpInputTB);
            this.Controls.Add(this.InputText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox InputText;
        private System.Windows.Forms.TextBox IpInputTB;
        private System.Windows.Forms.Label EnterIP;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.Button SetNameBtn;
        private System.Windows.Forms.RichTextBox OutputText;
    }
}

