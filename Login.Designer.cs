namespace C969_Appointment_Scheduler
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
            UsernameLabel = new Label();
            PasswordLabel = new Label();
            UsernameBox = new TextBox();
            PasswordBox = new TextBox();
            LoginButton = new Button();
            UserLocationLabel = new Label();
            SuspendLayout();
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(17, 29);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(60, 15);
            UsernameLabel.TabIndex = 0;
            UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(17, 84);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(57, 15);
            PasswordLabel.TabIndex = 1;
            PasswordLabel.Text = "Password";
            // 
            // UsernameBox
            // 
            UsernameBox.Location = new Point(17, 47);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.Size = new Size(218, 23);
            UsernameBox.TabIndex = 2;
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(17, 102);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '*';
            PasswordBox.Size = new Size(218, 23);
            PasswordBox.TabIndex = 3;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(17, 147);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(94, 35);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "Log In";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // UserLocationLabel
            // 
            UserLocationLabel.AutoSize = true;
            UserLocationLabel.Location = new Point(128, 157);
            UserLocationLabel.Name = "UserLocationLabel";
            UserLocationLabel.Size = new Size(107, 15);
            UserLocationLabel.TabIndex = 5;
            UserLocationLabel.Text = "User's Location: XX";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 228);
            Controls.Add(UserLocationLabel);
            Controls.Add(LoginButton);
            Controls.Add(PasswordBox);
            Controls.Add(UsernameBox);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameLabel);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UsernameLabel;
        private Label PasswordLabel;
        private TextBox UsernameBox;
        private TextBox PasswordBox;
        private Button LoginButton;
        private Label UserLocationLabel;
    }
}