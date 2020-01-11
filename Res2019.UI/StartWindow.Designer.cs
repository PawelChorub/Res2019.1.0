namespace Res2019.UI
{
    partial class StartWindow
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
            this.AgendaBtn = new System.Windows.Forms.Button();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AgendaBtn
            // 
            this.AgendaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AgendaBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.AgendaBtn.FlatAppearance.BorderSize = 0;
            this.AgendaBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AgendaBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.AgendaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AgendaBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AgendaBtn.ForeColor = System.Drawing.Color.Snow;
            this.AgendaBtn.Location = new System.Drawing.Point(-5, 65);
            this.AgendaBtn.Name = "AgendaBtn";
            this.AgendaBtn.Size = new System.Drawing.Size(804, 40);
            this.AgendaBtn.TabIndex = 2;
            this.AgendaBtn.Text = "Terminarz";
            this.AgendaBtn.UseVisualStyleBackColor = false;
            this.AgendaBtn.Click += new System.EventHandler(this.AgendaBtn_Click);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.SettingsBtn.FlatAppearance.BorderSize = 0;
            this.SettingsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SettingsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.SettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SettingsBtn.ForeColor = System.Drawing.Color.Snow;
            this.SettingsBtn.Location = new System.Drawing.Point(-5, 111);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(804, 41);
            this.SettingsBtn.TabIndex = 4;
            this.SettingsBtn.Text = "Ustawienia";
            this.SettingsBtn.UseVisualStyleBackColor = false;
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exitButton.ForeColor = System.Drawing.Color.Snow;
            this.exitButton.Location = new System.Drawing.Point(-5, 158);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(804, 41);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Wyjście";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(800, 265);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.SettingsBtn);
            this.Controls.Add(this.AgendaBtn);
            this.Name = "StartWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Res2019";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AgendaBtn;
        private System.Windows.Forms.Button SettingsBtn;
        private System.Windows.Forms.Button exitButton;
    }
}