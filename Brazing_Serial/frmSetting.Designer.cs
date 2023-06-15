namespace Brazing_Serial
{
    partial class frmSetting
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.IP1 = new System.Windows.Forms.TextBox();
            this.IP3 = new System.Windows.Forms.TextBox();
            this.IP2 = new System.Windows.Forms.TextBox();
            this.IP4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbLine = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 55);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Setting";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(376, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(22, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP Address SR1000 :";
            // 
            // IP1
            // 
            this.IP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.IP1.Location = new System.Drawing.Point(29, 127);
            this.IP1.MaxLength = 3;
            this.IP1.Multiline = true;
            this.IP1.Name = "IP1";
            this.IP1.Size = new System.Drawing.Size(94, 36);
            this.IP1.TabIndex = 2;
            this.IP1.Text = "12";
            this.IP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IP3
            // 
            this.IP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.IP3.Location = new System.Drawing.Point(229, 127);
            this.IP3.MaxLength = 3;
            this.IP3.Multiline = true;
            this.IP3.Name = "IP3";
            this.IP3.Size = new System.Drawing.Size(94, 36);
            this.IP3.TabIndex = 3;
            this.IP3.Text = "12";
            this.IP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IP2
            // 
            this.IP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.IP2.Location = new System.Drawing.Point(129, 127);
            this.IP2.MaxLength = 3;
            this.IP2.Multiline = true;
            this.IP2.Name = "IP2";
            this.IP2.Size = new System.Drawing.Size(94, 36);
            this.IP2.TabIndex = 4;
            this.IP2.Text = "12";
            this.IP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IP4
            // 
            this.IP4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.IP4.Location = new System.Drawing.Point(329, 127);
            this.IP4.MaxLength = 3;
            this.IP4.Multiline = true;
            this.IP4.Name = "IP4";
            this.IP4.Size = new System.Drawing.Size(94, 36);
            this.IP4.TabIndex = 5;
            this.IP4.Text = "12";
            this.IP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(22, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Prt SR1000 :";
            // 
            // lbPort
            // 
            this.lbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbPort.Location = new System.Drawing.Point(174, 190);
            this.lbPort.MaxLength = 5;
            this.lbPort.Multiline = true;
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(94, 36);
            this.lbPort.TabIndex = 7;
            this.lbPort.Text = "9004";
            this.lbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(24, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Line No :";
            // 
            // lbLine
            // 
            this.lbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbLine.Location = new System.Drawing.Point(137, 252);
            this.lbLine.MaxLength = 2;
            this.lbLine.Multiline = true;
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new System.Drawing.Size(94, 36);
            this.lbLine.TabIndex = 9;
            this.lbLine.Text = "1";
            this.lbLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Green;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(190, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 43);
            this.button2.TabIndex = 10;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(474, 365);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbLine);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IP4);
            this.Controls.Add(this.IP2);
            this.Controls.Add(this.IP3);
            this.Controls.Add(this.IP1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSetting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IP1;
        private System.Windows.Forms.TextBox IP3;
        private System.Windows.Forms.TextBox IP2;
        private System.Windows.Forms.TextBox IP4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lbPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lbLine;
        private System.Windows.Forms.Button button2;
    }
}