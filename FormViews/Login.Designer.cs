namespace TeacherGradingUI_WF.FormViews
{
    partial class Login
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
            this.LoginRole = new System.Windows.Forms.ComboBox();
            this.LoginPassword = new System.Windows.Forms.TextBox();
            this.LoginEmail = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginTitle = new System.Windows.Forms.Label();
            this.RoleLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginRole
            // 
            this.LoginRole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LoginRole.FormattingEnabled = true;
            this.LoginRole.Items.AddRange(new object[] {
            "teacher",
            "admin",
            "student",
            "parent"});
            this.LoginRole.Location = new System.Drawing.Point(299, 248);
            this.LoginRole.Name = "LoginRole";
            this.LoginRole.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LoginRole.Size = new System.Drawing.Size(229, 24);
            this.LoginRole.TabIndex = 0;
            this.LoginRole.SelectedIndexChanged += new System.EventHandler(this.cbLoginRole_SelectedIndexChanged);
            // 
            // LoginPassword
            // 
            this.LoginPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginPassword.Location = new System.Drawing.Point(299, 220);
            this.LoginPassword.Name = "LoginPassword";
            this.LoginPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LoginPassword.Size = new System.Drawing.Size(229, 22);
            this.LoginPassword.TabIndex = 1;
            this.LoginPassword.TextChanged += new System.EventHandler(this.tbLoginPassword_TextChanged);
            // 
            // LoginEmail
            // 
            this.LoginEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginEmail.Location = new System.Drawing.Point(299, 192);
            this.LoginEmail.Name = "LoginEmail";
            this.LoginEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LoginEmail.Size = new System.Drawing.Size(229, 22);
            this.LoginEmail.TabIndex = 2;
            this.LoginEmail.TextChanged += new System.EventHandler(this.tbLoginEmail_TextChanged);
            // 
            // EmailLabel
            // 
            this.EmailLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(242, 194);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EmailLabel.Size = new System.Drawing.Size(51, 20);
            this.EmailLabel.TabIndex = 3;
            this.EmailLabel.Text = "Email\r\n";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(210, 222);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PasswordLabel.Size = new System.Drawing.Size(83, 20);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password";
            // 
            // LoginTitle
            // 
            this.LoginTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginTitle.AutoSize = true;
            this.LoginTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginTitle.Location = new System.Drawing.Point(360, 125);
            this.LoginTitle.Name = "LoginTitle";
            this.LoginTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LoginTitle.Size = new System.Drawing.Size(101, 39);
            this.LoginTitle.TabIndex = 5;
            this.LoginTitle.Text = "Login";
            // 
            // RoleLabel
            // 
            this.RoleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RoleLabel.AutoSize = true;
            this.RoleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoleLabel.Location = new System.Drawing.Point(250, 252);
            this.RoleLabel.Name = "RoleLabel";
            this.RoleLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RoleLabel.Size = new System.Drawing.Size(43, 20);
            this.RoleLabel.TabIndex = 6;
            this.RoleLabel.Text = "Role";
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LoginButton.Location = new System.Drawing.Point(299, 278);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(229, 26);
            this.LoginButton.TabIndex = 7;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.RoleLabel);
            this.Controls.Add(this.LoginTitle);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.LoginEmail);
            this.Controls.Add(this.LoginPassword);
            this.Controls.Add(this.LoginRole);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox LoginRole;
        private System.Windows.Forms.TextBox LoginPassword;
        private System.Windows.Forms.TextBox LoginEmail;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label LoginTitle;
        private System.Windows.Forms.Label RoleLabel;
        private System.Windows.Forms.Button LoginButton;
    }
}