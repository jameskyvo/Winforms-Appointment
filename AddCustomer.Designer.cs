namespace C969_Appointment_Scheduler
{
    partial class AddCustomer
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
            NameLabel = new Label();
            AddressLabel = new Label();
            PhoneNumberLabel = new Label();
            NameTextBox = new TextBox();
            AddressTextBox = new TextBox();
            activeBox = new CheckBox();
            AddButton = new Button();
            CancelButton = new Button();
            PhoneNumberBox = new MaskedTextBox();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(16, 28);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(53, 15);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "* Name: ";
            // 
            // AddressLabel
            // 
            AddressLabel.AutoSize = true;
            AddressLabel.Location = new Point(16, 72);
            AddressLabel.Name = "AddressLabel";
            AddressLabel.Size = new Size(63, 15);
            AddressLabel.TabIndex = 1;
            AddressLabel.Text = "* Address: ";
            // 
            // PhoneNumberLabel
            // 
            PhoneNumberLabel.AutoSize = true;
            PhoneNumberLabel.Location = new Point(16, 115);
            PhoneNumberLabel.Name = "PhoneNumberLabel";
            PhoneNumberLabel.Size = new Size(102, 15);
            PhoneNumberLabel.TabIndex = 2;
            PhoneNumberLabel.Text = "* Phone Number: ";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(120, 25);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(135, 23);
            NameTextBox.TabIndex = 3;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(120, 69);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(135, 23);
            AddressTextBox.TabIndex = 4;
            // 
            // activeBox
            // 
            activeBox.AutoSize = true;
            activeBox.CheckAlign = ContentAlignment.TopRight;
            activeBox.Location = new Point(20, 149);
            activeBox.Name = "activeBox";
            activeBox.Size = new Size(59, 19);
            activeBox.TabIndex = 6;
            activeBox.Text = "Active";
            activeBox.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(20, 215);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 7;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(120, 215);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 8;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // PhoneNumberBox
            // 
            PhoneNumberBox.Location = new Point(120, 112);
            PhoneNumberBox.Mask = "999-000-0000";
            PhoneNumberBox.Name = "PhoneNumberBox";
            PhoneNumberBox.Size = new Size(135, 23);
            PhoneNumberBox.TabIndex = 9;
            // 
            // AddCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 286);
            Controls.Add(PhoneNumberBox);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Controls.Add(activeBox);
            Controls.Add(AddressTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(PhoneNumberLabel);
            Controls.Add(AddressLabel);
            Controls.Add(NameLabel);
            Name = "AddCustomer";
            Text = "New Customer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameLabel;
        private Label AddressLabel;
        private Label PhoneNumberLabel;
        private TextBox NameTextBox;
        private TextBox AddressTextBox;
        private CheckBox activeBox;
        private Button AddButton;
        private Button CancelButton;
        private MaskedTextBox PhoneNumberBox;
    }
}