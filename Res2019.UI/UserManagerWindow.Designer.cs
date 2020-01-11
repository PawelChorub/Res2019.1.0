namespace Res2019.UI
{
    partial class UserManagerWindow
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
            this.LoginTb = new System.Windows.Forms.TextBox();
            this.AddUserBtn = new System.Windows.Forms.Button();
            this.RemoveUserBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.PasswordTb = new System.Windows.Forms.TextBox();
            this.ConfirmPasswordTb = new System.Windows.Forms.TextBox();
            this.UsersComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ExitBtn1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginTb
            // 
            this.LoginTb.BackColor = System.Drawing.Color.RoyalBlue;
            this.LoginTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginTb.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginTb.ForeColor = System.Drawing.Color.White;
            this.LoginTb.Location = new System.Drawing.Point(91, 45);
            this.LoginTb.Name = "LoginTb";
            this.LoginTb.Size = new System.Drawing.Size(322, 19);
            this.LoginTb.TabIndex = 0;
            // 
            // AddUserBtn
            // 
            this.AddUserBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.AddUserBtn.FlatAppearance.BorderSize = 0;
            this.AddUserBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AddUserBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.AddUserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddUserBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddUserBtn.ForeColor = System.Drawing.Color.White;
            this.AddUserBtn.Location = new System.Drawing.Point(91, 179);
            this.AddUserBtn.Name = "AddUserBtn";
            this.AddUserBtn.Size = new System.Drawing.Size(160, 40);
            this.AddUserBtn.TabIndex = 2;
            this.AddUserBtn.Text = "Utwórz konto";
            this.AddUserBtn.UseVisualStyleBackColor = false;
            this.AddUserBtn.Click += new System.EventHandler(this.AddUserBtn_Click);
            // 
            // RemoveUserBtn
            // 
            this.RemoveUserBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.RemoveUserBtn.FlatAppearance.BorderSize = 0;
            this.RemoveUserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveUserBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RemoveUserBtn.ForeColor = System.Drawing.Color.White;
            this.RemoveUserBtn.Location = new System.Drawing.Point(62, 71);
            this.RemoveUserBtn.Name = "RemoveUserBtn";
            this.RemoveUserBtn.Size = new System.Drawing.Size(205, 40);
            this.RemoveUserBtn.TabIndex = 3;
            this.RemoveUserBtn.Text = "Usuń wybrane konto";
            this.RemoveUserBtn.UseVisualStyleBackColor = false;
            this.RemoveUserBtn.Click += new System.EventHandler(this.RemoveUserBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitBtn.ForeColor = System.Drawing.Color.White;
            this.ExitBtn.Location = new System.Drawing.Point(273, 71);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(166, 40);
            this.ExitBtn.TabIndex = 4;
            this.ExitBtn.Text = "Wyjdź";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // PasswordTb
            // 
            this.PasswordTb.BackColor = System.Drawing.Color.RoyalBlue;
            this.PasswordTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTb.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PasswordTb.ForeColor = System.Drawing.Color.White;
            this.PasswordTb.Location = new System.Drawing.Point(91, 90);
            this.PasswordTb.Name = "PasswordTb";
            this.PasswordTb.Size = new System.Drawing.Size(322, 19);
            this.PasswordTb.TabIndex = 5;
            // 
            // ConfirmPasswordTb
            // 
            this.ConfirmPasswordTb.BackColor = System.Drawing.Color.RoyalBlue;
            this.ConfirmPasswordTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfirmPasswordTb.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ConfirmPasswordTb.ForeColor = System.Drawing.Color.White;
            this.ConfirmPasswordTb.Location = new System.Drawing.Point(91, 136);
            this.ConfirmPasswordTb.Name = "ConfirmPasswordTb";
            this.ConfirmPasswordTb.Size = new System.Drawing.Size(322, 19);
            this.ConfirmPasswordTb.TabIndex = 6;
            // 
            // UsersComboBox
            // 
            this.UsersComboBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.UsersComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UsersComboBox.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UsersComboBox.ForeColor = System.Drawing.Color.White;
            this.UsersComboBox.FormattingEnabled = true;
            this.UsersComboBox.Location = new System.Drawing.Point(62, 141);
            this.UsersComboBox.Name = "UsersComboBox";
            this.UsersComboBox.Size = new System.Drawing.Size(377, 30);
            this.UsersComboBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(88, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Login :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(88, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Hasło :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(88, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Powtórz hasło :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 295);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.MidnightBlue;
            this.tabPage1.Controls.Add(this.ExitBtn1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.LoginTb);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.AddUserBtn);
            this.tabPage1.Controls.Add(this.PasswordTb);
            this.tabPage1.Controls.Add(this.ConfirmPasswordTb);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(498, 269);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dodaj";
            // 
            // ExitBtn1
            // 
            this.ExitBtn1.BackColor = System.Drawing.Color.RoyalBlue;
            this.ExitBtn1.FlatAppearance.BorderSize = 0;
            this.ExitBtn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ExitBtn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.ExitBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitBtn1.ForeColor = System.Drawing.Color.White;
            this.ExitBtn1.Location = new System.Drawing.Point(257, 179);
            this.ExitBtn1.Name = "ExitBtn1";
            this.ExitBtn1.Size = new System.Drawing.Size(156, 40);
            this.ExitBtn1.TabIndex = 19;
            this.ExitBtn1.Text = "Wyjdź";
            this.ExitBtn1.UseVisualStyleBackColor = false;
            this.ExitBtn1.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MidnightBlue;
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.RemoveUserBtn);
            this.tabPage2.Controls.Add(this.ExitBtn);
            this.tabPage2.Controls.Add(this.UsersComboBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(498, 269);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Usuń";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(59, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Zarejestrowani użytkownicy :";
            // 
            // UserManagerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(529, 327);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserManagerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserManagerWindow";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox LoginTb;
        private System.Windows.Forms.Button AddUserBtn;
        private System.Windows.Forms.Button RemoveUserBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.TextBox PasswordTb;
        private System.Windows.Forms.TextBox ConfirmPasswordTb;
        private System.Windows.Forms.ComboBox UsersComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button ExitBtn1;
        private System.Windows.Forms.Label label4;
    }
}