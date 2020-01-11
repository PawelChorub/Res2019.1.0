namespace Res2019
{
    partial class ProgramSettings
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.databaseNameTb = new System.Windows.Forms.TextBox();
            this.databasePasswordTb = new System.Windows.Forms.TextBox();
            this.databaseUserTb = new System.Windows.Forms.TextBox();
            this.tableTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DefaultSettingsButton = new System.Windows.Forms.Button();
            this.databaseServerNameTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(280, 217);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(105, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(395, 217);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(105, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // databaseNameTb
            // 
            this.databaseNameTb.Location = new System.Drawing.Point(161, 64);
            this.databaseNameTb.Name = "databaseNameTb";
            this.databaseNameTb.Size = new System.Drawing.Size(386, 20);
            this.databaseNameTb.TabIndex = 2;
            this.databaseNameTb.Text = "ReservationSystem";
            // 
            // databasePasswordTb
            // 
            this.databasePasswordTb.Location = new System.Drawing.Point(161, 142);
            this.databasePasswordTb.Name = "databasePasswordTb";
            this.databasePasswordTb.PasswordChar = '*';
            this.databasePasswordTb.Size = new System.Drawing.Size(386, 20);
            this.databasePasswordTb.TabIndex = 3;
            this.databasePasswordTb.Text = "12trzy";
            // 
            // databaseUserTb
            // 
            this.databaseUserTb.Location = new System.Drawing.Point(161, 116);
            this.databaseUserTb.Name = "databaseUserTb";
            this.databaseUserTb.Size = new System.Drawing.Size(386, 20);
            this.databaseUserTb.TabIndex = 4;
            this.databaseUserTb.Text = "sa";
            // 
            // tableTb
            // 
            this.tableTb.Location = new System.Drawing.Point(161, 90);
            this.tableTb.Name = "tableTb";
            this.tableTb.Size = new System.Drawing.Size(386, 20);
            this.tableTb.TabIndex = 5;
            this.tableTb.Text = "ReservationTable";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Baza danych terminarza :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tabela wizyt terminarza :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Login bazy danych :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hasło bazy danych :";
            // 
            // DefaultSettingsButton
            // 
            this.DefaultSettingsButton.Location = new System.Drawing.Point(165, 217);
            this.DefaultSettingsButton.Name = "DefaultSettingsButton";
            this.DefaultSettingsButton.Size = new System.Drawing.Size(105, 23);
            this.DefaultSettingsButton.TabIndex = 7;
            this.DefaultSettingsButton.Text = "Ustaw domyślne";
            this.DefaultSettingsButton.UseVisualStyleBackColor = true;
            this.DefaultSettingsButton.Click += new System.EventHandler(this.DefaultSettingsButton_Click);
            // 
            // databaseServerNameTb
            // 
            this.databaseServerNameTb.Location = new System.Drawing.Point(161, 38);
            this.databaseServerNameTb.Name = "databaseServerNameTb";
            this.databaseServerNameTb.Size = new System.Drawing.Size(386, 20);
            this.databaseServerNameTb.TabIndex = 2;
            this.databaseServerNameTb.Text = "Server=.\\\\SQLEXPR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Serwer bazy danych :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ustawienia dla bazy danych :";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(161, 167);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(386, 20);
            this.textBox6.TabIndex = 8;
            // 
            // ProgramSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 355);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.DefaultSettingsButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableTb);
            this.Controls.Add(this.databaseUserTb);
            this.Controls.Add(this.databasePasswordTb);
            this.Controls.Add(this.databaseServerNameTb);
            this.Controls.Add(this.databaseNameTb);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Name = "ProgramSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgramSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox databaseNameTb;
        private System.Windows.Forms.TextBox databasePasswordTb;
        private System.Windows.Forms.TextBox databaseUserTb;
        private System.Windows.Forms.TextBox tableTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DefaultSettingsButton;
        private System.Windows.Forms.TextBox databaseServerNameTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
    }
}