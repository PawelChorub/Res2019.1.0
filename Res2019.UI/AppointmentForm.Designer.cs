namespace Res2019
{
    partial class AppointmentForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.serviceChoiceComboBox = new System.Windows.Forms.ComboBox();
            this.clientTimeComboBox = new System.Windows.Forms.ComboBox();
            this.telephoneNumbtextBox = new System.Windows.Forms.TextBox();
            this.surenameTextBox = new System.Windows.Forms.TextBox();
            this.forenameTextBox = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelButton.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelButton.Location = new System.Drawing.Point(0, 306);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(219, 36);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(3, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Zarezerwuj czas dla klienta :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(3, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Wybierz usługę :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(3, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Podaj numer telefonu :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Podaj nazwisko :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Podaj imię :";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButton.ForeColor = System.Drawing.SystemColors.Control;
            this.saveButton.Location = new System.Drawing.Point(0, 259);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(219, 36);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Zapisz";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // serviceChoiceComboBox
            // 
            this.serviceChoiceComboBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.serviceChoiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serviceChoiceComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.serviceChoiceComboBox.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.serviceChoiceComboBox.ForeColor = System.Drawing.Color.Snow;
            this.serviceChoiceComboBox.FormattingEnabled = true;
            this.serviceChoiceComboBox.Items.AddRange(new object[] {
            "Manicure",
            "Pedicure",
            "Henna",
            "Zabieg"});
            this.serviceChoiceComboBox.Location = new System.Drawing.Point(-1, 173);
            this.serviceChoiceComboBox.Name = "serviceChoiceComboBox";
            this.serviceChoiceComboBox.Size = new System.Drawing.Size(221, 26);
            this.serviceChoiceComboBox.TabIndex = 8;
            // 
            // clientTimeComboBox
            // 
            this.clientTimeComboBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.clientTimeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientTimeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientTimeComboBox.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.clientTimeComboBox.ForeColor = System.Drawing.Color.Snow;
            this.clientTimeComboBox.FormattingEnabled = true;
            this.clientTimeComboBox.Items.AddRange(new object[] {
            "0:30",
            "1:00",
            "1:30",
            "2:00",
            "2:30",
            "3:00"});
            this.clientTimeComboBox.Location = new System.Drawing.Point(-2, 216);
            this.clientTimeComboBox.Name = "clientTimeComboBox";
            this.clientTimeComboBox.Size = new System.Drawing.Size(221, 26);
            this.clientTimeComboBox.TabIndex = 9;
            // 
            // telephoneNumbtextBox
            // 
            this.telephoneNumbtextBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.telephoneNumbtextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.telephoneNumbtextBox.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.telephoneNumbtextBox.ForeColor = System.Drawing.Color.Snow;
            this.telephoneNumbtextBox.Location = new System.Drawing.Point(-1, 134);
            this.telephoneNumbtextBox.Multiline = true;
            this.telephoneNumbtextBox.Name = "telephoneNumbtextBox";
            this.telephoneNumbtextBox.Size = new System.Drawing.Size(221, 20);
            this.telephoneNumbtextBox.TabIndex = 5;
            this.telephoneNumbtextBox.Text = "721123456";
            this.telephoneNumbtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // surenameTextBox
            // 
            this.surenameTextBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.surenameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.surenameTextBox.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.surenameTextBox.ForeColor = System.Drawing.Color.Snow;
            this.surenameTextBox.Location = new System.Drawing.Point(-1, 94);
            this.surenameTextBox.Multiline = true;
            this.surenameTextBox.Name = "surenameTextBox";
            this.surenameTextBox.Size = new System.Drawing.Size(222, 20);
            this.surenameTextBox.TabIndex = 6;
            this.surenameTextBox.Text = "Nazwisko";
            this.surenameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // forenameTextBox
            // 
            this.forenameTextBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.forenameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.forenameTextBox.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.forenameTextBox.ForeColor = System.Drawing.Color.Snow;
            this.forenameTextBox.Location = new System.Drawing.Point(-1, 54);
            this.forenameTextBox.Multiline = true;
            this.forenameTextBox.Name = "forenameTextBox";
            this.forenameTextBox.Size = new System.Drawing.Size(221, 20);
            this.forenameTextBox.TabIndex = 7;
            this.forenameTextBox.Text = "Imie";
            this.forenameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.timeLabel.Location = new System.Drawing.Point(120, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(83, 23);
            this.timeLabel.TabIndex = 18;
            this.timeLabel.Text = "godzina";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateLabel
            // 
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.dateLabel.Location = new System.Drawing.Point(12, 9);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(102, 23);
            this.dateLabel.TabIndex = 17;
            this.dateLabel.Text = "data";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(219, 364);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.serviceChoiceComboBox);
            this.Controls.Add(this.clientTimeComboBox);
            this.Controls.Add(this.telephoneNumbtextBox);
            this.Controls.Add(this.surenameTextBox);
            this.Controls.Add(this.forenameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AppointmentForm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox serviceChoiceComboBox;
        private System.Windows.Forms.ComboBox clientTimeComboBox;
        private System.Windows.Forms.TextBox telephoneNumbtextBox;
        private System.Windows.Forms.TextBox surenameTextBox;
        private System.Windows.Forms.TextBox forenameTextBox;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label dateLabel;
    }
}