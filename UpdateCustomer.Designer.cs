namespace C969_Appointment_Scheduler
{
    partial class UpdateCustomer
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
            UpdateButton = new Button();
            CancelButton = new Button();
            PhoneNumberBox = new MaskedTextBox();
            CountryLabel = new Label();
            CityLabel = new Label();
            Address2TextBox = new TextBox();
            Address2Label = new Label();
            PostalCodeLabel = new Label();
            PostalCodeTextBox = new MaskedTextBox();
            CountryDropDown = new ComboBox();
            CityDropDown = new ComboBox();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(16, 29);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(53, 15);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "Name: * ";
            // 
            // AddressLabel
            // 
            AddressLabel.AutoSize = true;
            AddressLabel.Location = new Point(16, 158);
            AddressLabel.Name = "AddressLabel";
            AddressLabel.Size = new Size(60, 15);
            AddressLabel.TabIndex = 1;
            AddressLabel.Text = "Address: *";
            // 
            // PhoneNumberLabel
            // 
            PhoneNumberLabel.AutoSize = true;
            PhoneNumberLabel.Location = new Point(16, 287);
            PhoneNumberLabel.Name = "PhoneNumberLabel";
            PhoneNumberLabel.Size = new Size(102, 15);
            PhoneNumberLabel.TabIndex = 2;
            PhoneNumberLabel.Text = "Phone Number:  *";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(138, 25);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(190, 23);
            NameTextBox.TabIndex = 0;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(138, 154);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(190, 23);
            AddressTextBox.TabIndex = 3;
            // 
            // activeBox
            // 
            activeBox.AutoSize = true;
            activeBox.CheckAlign = ContentAlignment.TopRight;
            activeBox.Location = new Point(16, 322);
            activeBox.Name = "activeBox";
            activeBox.Size = new Size(59, 19);
            activeBox.TabIndex = 7;
            activeBox.Text = "Active";
            activeBox.UseVisualStyleBackColor = true;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(16, 358);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(75, 23);
            UpdateButton.TabIndex = 8;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(116, 358);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 9;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // PhoneNumberBox
            // 
            PhoneNumberBox.Location = new Point(138, 283);
            PhoneNumberBox.Mask = "999-000-0000";
            PhoneNumberBox.Name = "PhoneNumberBox";
            PhoneNumberBox.Size = new Size(190, 23);
            PhoneNumberBox.TabIndex = 6;
            // 
            // CountryLabel
            // 
            CountryLabel.AutoSize = true;
            CountryLabel.Location = new Point(16, 72);
            CountryLabel.Name = "CountryLabel";
            CountryLabel.Size = new Size(56, 15);
            CountryLabel.TabIndex = 10;
            CountryLabel.Text = "Country: ";
            // 
            // CityLabel
            // 
            CityLabel.AutoSize = true;
            CityLabel.Location = new Point(16, 115);
            CityLabel.Name = "CityLabel";
            CityLabel.Size = new Size(34, 15);
            CityLabel.TabIndex = 11;
            CityLabel.Text = "City: ";
            // 
            // Address2TextBox
            // 
            Address2TextBox.Location = new Point(138, 197);
            Address2TextBox.Name = "Address2TextBox";
            Address2TextBox.Size = new Size(190, 23);
            Address2TextBox.TabIndex = 4;
            // 
            // Address2Label
            // 
            Address2Label.AutoSize = true;
            Address2Label.Location = new Point(16, 201);
            Address2Label.Name = "Address2Label";
            Address2Label.Size = new Size(64, 15);
            Address2Label.TabIndex = 12;
            Address2Label.Text = "Address 2: ";
            // 
            // PostalCodeLabel
            // 
            PostalCodeLabel.AutoSize = true;
            PostalCodeLabel.Location = new Point(16, 244);
            PostalCodeLabel.Name = "PostalCodeLabel";
            PostalCodeLabel.Size = new Size(67, 15);
            PostalCodeLabel.TabIndex = 14;
            PostalCodeLabel.Text = "PostalCode";
            // 
            // PostalCodeTextBox
            // 
            PostalCodeTextBox.Location = new Point(138, 240);
            PostalCodeTextBox.Mask = "00000-9999";
            PostalCodeTextBox.Name = "PostalCodeTextBox";
            PostalCodeTextBox.Size = new Size(190, 23);
            PostalCodeTextBox.TabIndex = 5;
            // 
            // CountryDropDown
            // 
            CountryDropDown.FormattingEnabled = true;
            CountryDropDown.Location = new Point(138, 68);
            CountryDropDown.Name = "CountryDropDown";
            CountryDropDown.Size = new Size(190, 23);
            CountryDropDown.TabIndex = 1;
            CountryDropDown.SelectedIndexChanged += CountryDropDown_SelectedIndexChanged;
            // 
            // CityDropDown
            // 
            CityDropDown.FormattingEnabled = true;
            CityDropDown.Location = new Point(138, 111);
            CityDropDown.Name = "CityDropDown";
            CityDropDown.Size = new Size(190, 23);
            CityDropDown.TabIndex = 2;
            // 
            // UpdateCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 418);
            Controls.Add(CityDropDown);
            Controls.Add(CountryDropDown);
            Controls.Add(PostalCodeTextBox);
            Controls.Add(PostalCodeLabel);
            Controls.Add(Address2TextBox);
            Controls.Add(Address2Label);
            Controls.Add(CityLabel);
            Controls.Add(CountryLabel);
            Controls.Add(PhoneNumberBox);
            Controls.Add(CancelButton);
            Controls.Add(UpdateButton);
            Controls.Add(activeBox);
            Controls.Add(AddressTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(PhoneNumberLabel);
            Controls.Add(AddressLabel);
            Controls.Add(NameLabel);
            Name = "UpdateCustomer";
            Text = "Update Customer";
            Load += UpdateCustomer_Load;
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
        private Button UpdateButton;
        private Button CancelButton;
        private MaskedTextBox PhoneNumberBox;
        private Label CountryLabel;
        private Label CityLabel;
        private TextBox Address2TextBox;
        private Label Address2Label;
        private Label PostalCodeLabel;
        private MaskedTextBox PostalCodeTextBox;
        private ComboBox CountryDropDown;
        private ComboBox CityDropDown;
    }
}