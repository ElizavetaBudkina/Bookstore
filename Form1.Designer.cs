
namespace TR_BEA_A_10_20
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fon1 = new System.Windows.Forms.Panel();
            this.buttonlogin = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.Label();
            this.pastextBox = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Label();
            this.logintextBox = new System.Windows.Forms.TextBox();
            this.avtoriz = new System.Windows.Forms.Label();
            this.fon1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fon1
            // 
            this.fon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(227)))), ((int)(((byte)(254)))));
            this.fon1.Controls.Add(this.buttonlogin);
            this.fon1.Controls.Add(this.password);
            this.fon1.Controls.Add(this.pastextBox);
            this.fon1.Controls.Add(this.login);
            this.fon1.Controls.Add(this.logintextBox);
            this.fon1.Controls.Add(this.avtoriz);
            this.fon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fon1.Location = new System.Drawing.Point(0, 0);
            this.fon1.Name = "fon1";
            this.fon1.Size = new System.Drawing.Size(428, 459);
            this.fon1.TabIndex = 0;
            // 
            // buttonlogin
            // 
            this.buttonlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(134)))), ((int)(((byte)(247)))));
            this.buttonlogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(255)))), ((int)(((byte)(182)))));
            this.buttonlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonlogin.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonlogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(3)))), ((int)(((byte)(35)))));
            this.buttonlogin.Location = new System.Drawing.Point(165, 335);
            this.buttonlogin.Name = "buttonlogin";
            this.buttonlogin.Size = new System.Drawing.Size(121, 41);
            this.buttonlogin.TabIndex = 6;
            this.buttonlogin.Text = "Войти";
            this.buttonlogin.UseVisualStyleBackColor = false;
            this.buttonlogin.Click += new System.EventHandler(this.buttonlogin_Click);
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(26)))), ((int)(((byte)(50)))));
            this.password.Location = new System.Drawing.Point(57, 241);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(111, 32);
            this.password.TabIndex = 5;
            this.password.Text = "Пароль";
            // 
            // pastextBox
            // 
            this.pastextBox.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pastextBox.Location = new System.Drawing.Point(188, 239);
            this.pastextBox.Name = "pastextBox";
            this.pastextBox.Size = new System.Drawing.Size(228, 36);
            this.pastextBox.TabIndex = 4;
            this.pastextBox.UseSystemPasswordChar = true;
            // 
            // login
            // 
            this.login.AutoSize = true;
            this.login.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(26)))), ((int)(((byte)(50)))));
            this.login.Location = new System.Drawing.Point(57, 175);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(93, 32);
            this.login.TabIndex = 3;
            this.login.Text = "Логин";
            // 
            // logintextBox
            // 
            this.logintextBox.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logintextBox.Location = new System.Drawing.Point(188, 173);
            this.logintextBox.Name = "logintextBox";
            this.logintextBox.Size = new System.Drawing.Size(228, 36);
            this.logintextBox.TabIndex = 2;
            // 
            // avtoriz
            // 
            this.avtoriz.AutoSize = true;
            this.avtoriz.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.avtoriz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(26)))), ((int)(((byte)(50)))));
            this.avtoriz.Location = new System.Drawing.Point(99, 73);
            this.avtoriz.Name = "avtoriz";
            this.avtoriz.Size = new System.Drawing.Size(245, 48);
            this.avtoriz.TabIndex = 1;
            this.avtoriz.Text = "Авторизация";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 459);
            this.Controls.Add(this.fon1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.fon1.ResumeLayout(false);
            this.fon1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel fon1;
        private System.Windows.Forms.Label login;
        private System.Windows.Forms.TextBox logintextBox;
        private System.Windows.Forms.Label avtoriz;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox pastextBox;
        private System.Windows.Forms.Button buttonlogin;
    }
}

