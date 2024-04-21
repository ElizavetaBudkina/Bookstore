
namespace TR_BEA_A_10_20
{
    partial class Store_id_m
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
            this.fon1 = new System.Windows.Forms.Panel();
            this.on_form = new System.Windows.Forms.Button();
            this.idstore_button = new System.Windows.Forms.Button();
            this.idstore_textbox = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Label();
            this.avtoriz = new System.Windows.Forms.Label();
            this.fon1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fon1
            // 
            this.fon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(227)))), ((int)(((byte)(254)))));
            this.fon1.Controls.Add(this.on_form);
            this.fon1.Controls.Add(this.idstore_button);
            this.fon1.Controls.Add(this.idstore_textbox);
            this.fon1.Controls.Add(this.login);
            this.fon1.Controls.Add(this.avtoriz);
            this.fon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fon1.Location = new System.Drawing.Point(0, 0);
            this.fon1.Name = "fon1";
            this.fon1.Size = new System.Drawing.Size(481, 454);
            this.fon1.TabIndex = 1;
            // 
            // on_form
            // 
            this.on_form.FlatAppearance.BorderSize = 0;
            this.on_form.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.on_form.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.on_form.Location = new System.Drawing.Point(3, 3);
            this.on_form.Name = "on_form";
            this.on_form.Size = new System.Drawing.Size(66, 29);
            this.on_form.TabIndex = 48;
            this.on_form.Text = "назад";
            this.on_form.UseVisualStyleBackColor = false;
            this.on_form.Click += new System.EventHandler(this.on_form_Click);
            // 
            // idstore_button
            // 
            this.idstore_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(134)))), ((int)(((byte)(247)))));
            this.idstore_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(255)))), ((int)(((byte)(182)))));
            this.idstore_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idstore_button.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.idstore_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(3)))), ((int)(((byte)(35)))));
            this.idstore_button.Location = new System.Drawing.Point(165, 335);
            this.idstore_button.Name = "idstore_button";
            this.idstore_button.Size = new System.Drawing.Size(121, 41);
            this.idstore_button.TabIndex = 6;
            this.idstore_button.Text = "Войти";
            this.idstore_button.UseVisualStyleBackColor = false;
            this.idstore_button.Click += new System.EventHandler(this.idstore_button_Click);
            // 
            // idstore_textbox
            // 
            this.idstore_textbox.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.idstore_textbox.Location = new System.Drawing.Point(116, 241);
            this.idstore_textbox.Name = "idstore_textbox";
            this.idstore_textbox.Size = new System.Drawing.Size(228, 36);
            this.idstore_textbox.TabIndex = 4;
            // 
            // login
            // 
            this.login.AutoSize = true;
            this.login.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(26)))), ((int)(((byte)(50)))));
            this.login.Location = new System.Drawing.Point(57, 175);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(389, 32);
            this.login.TabIndex = 3;
            this.login.Text = "Введите код вашего магазина";
            // 
            // avtoriz
            // 
            this.avtoriz.AutoSize = true;
            this.avtoriz.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.avtoriz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(26)))), ((int)(((byte)(50)))));
            this.avtoriz.Location = new System.Drawing.Point(99, 89);
            this.avtoriz.Name = "avtoriz";
            this.avtoriz.Size = new System.Drawing.Size(245, 48);
            this.avtoriz.TabIndex = 1;
            this.avtoriz.Text = "Авторизация";
            // 
            // Store_id_m
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 454);
            this.Controls.Add(this.fon1);
            this.Name = "Store_id_m";
            this.Text = "Store_id_m";
            this.fon1.ResumeLayout(false);
            this.fon1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel fon1;
        private System.Windows.Forms.Button idstore_button;
        private System.Windows.Forms.TextBox idstore_textbox;
        private System.Windows.Forms.Label login;
        private System.Windows.Forms.Label avtoriz;
        private System.Windows.Forms.Button on_form;
    }
}