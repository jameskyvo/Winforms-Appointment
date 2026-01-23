namespace C969_Appointment_Scheduler
{
    partial class AddAppointment
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
            components = new System.ComponentModel.Container();
            CustomerLabel = new Label();
            TypeLabel = new Label();
            StartTimeLabel = new Label();
            EndTimeLabel = new Label();
            z = new Label();
            CustomerDropDown = new ComboBox();
            customerBindingSource = new BindingSource(components);
            TypeTextBox = new TextBox();
            StartTimePicker = new DateTimePicker();
            EndTimePicker = new DateTimePicker();
            UserDropDown = new ComboBox();
            userBindingSource = new BindingSource(components);
            AddButton = new Button();
            StartDateLabel = new Label();
            EndDateLabel = new Label();
            StartDatePicker = new DateTimePicker();
            EndDatePicker = new DateTimePicker();
            TitleTextBox = new TextBox();
            TextLabel = new Label();
            DescriptionTextBox = new TextBox();
            DescriptionLabel = new Label();
            LocationLabel = new Label();
            LocationBox = new TextBox();
            ContactLabel = new Label();
            UrlLabel = new Label();
            ContactTextBox = new TextBox();
            UrlTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            SuspendLayout();
            // 
            // CustomerLabel
            // 
            CustomerLabel.AutoSize = true;
            CustomerLabel.Location = new Point(27, 28);
            CustomerLabel.Name = "CustomerLabel";
            CustomerLabel.Size = new Size(62, 15);
            CustomerLabel.TabIndex = 0;
            CustomerLabel.Text = "Customer:";
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(29, 190);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(34, 15);
            TypeLabel.TabIndex = 1;
            TypeLabel.Text = "Type:";
            // 
            // StartTimeLabel
            // 
            StartTimeLabel.AutoSize = true;
            StartTimeLabel.Location = new Point(259, 126);
            StartTimeLabel.Name = "StartTimeLabel";
            StartTimeLabel.Size = new Size(63, 15);
            StartTimeLabel.TabIndex = 2;
            StartTimeLabel.Text = "Start Time:";
            // 
            // EndTimeLabel
            // 
            EndTimeLabel.AutoSize = true;
            EndTimeLabel.Location = new Point(259, 180);
            EndTimeLabel.Name = "EndTimeLabel";
            EndTimeLabel.Size = new Size(59, 15);
            EndTimeLabel.TabIndex = 3;
            EndTimeLabel.Text = "End Time:";
            // 
            // z
            // 
            z.AutoSize = true;
            z.Location = new Point(256, 231);
            z.Name = "z";
            z.Size = new Size(46, 15);
            z.TabIndex = 4;
            z.Text = "User Id:";
            // 
            // CustomerDropDown
            // 
            CustomerDropDown.DataSource = customerBindingSource;
            CustomerDropDown.DisplayMember = "Name";
            CustomerDropDown.FormattingEnabled = true;
            CustomerDropDown.Location = new Point(32, 51);
            CustomerDropDown.Name = "CustomerDropDown";
            CustomerDropDown.Size = new Size(200, 23);
            CustomerDropDown.TabIndex = 5;
            // 
            // customerBindingSource
            // 
            customerBindingSource.DataSource = typeof(Customer);
            // 
            // TypeTextBox
            // 
            TypeTextBox.Location = new Point(32, 208);
            TypeTextBox.Name = "TypeTextBox";
            TypeTextBox.Size = new Size(200, 23);
            TypeTextBox.TabIndex = 6;
            // 
            // StartTimePicker
            // 
            StartTimePicker.CustomFormat = "h:mm tt";
            StartTimePicker.Format = DateTimePickerFormat.Custom;
            StartTimePicker.Location = new Point(259, 149);
            StartTimePicker.Name = "StartTimePicker";
            StartTimePicker.ShowUpDown = true;
            StartTimePicker.Size = new Size(200, 23);
            StartTimePicker.TabIndex = 7;
            StartTimePicker.ValueChanged += StartTimePicker_ValueChanged;
            // 
            // EndTimePicker
            // 
            EndTimePicker.CustomFormat = "h:mm tt";
            EndTimePicker.Format = DateTimePickerFormat.Custom;
            EndTimePicker.Location = new Point(259, 203);
            EndTimePicker.Name = "EndTimePicker";
            EndTimePicker.ShowUpDown = true;
            EndTimePicker.Size = new Size(200, 23);
            EndTimePicker.TabIndex = 8;
            EndTimePicker.ValueChanged += EndTimePicker_ValueChanged;
            // 
            // UserDropDown
            // 
            UserDropDown.DataSource = userBindingSource;
            UserDropDown.DisplayMember = "UserName";
            UserDropDown.FormattingEnabled = true;
            UserDropDown.Location = new Point(258, 254);
            UserDropDown.Name = "UserDropDown";
            UserDropDown.Size = new Size(200, 23);
            UserDropDown.TabIndex = 9;
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(User);
            // 
            // AddButton
            // 
            AddButton.Location = new Point(29, 504);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 10;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // StartDateLabel
            // 
            StartDateLabel.AutoSize = true;
            StartDateLabel.Location = new Point(258, 33);
            StartDateLabel.Name = "StartDateLabel";
            StartDateLabel.Size = new Size(61, 15);
            StartDateLabel.TabIndex = 11;
            StartDateLabel.Text = "Start Date:";
            // 
            // EndDateLabel
            // 
            EndDateLabel.AutoSize = true;
            EndDateLabel.Location = new Point(259, 82);
            EndDateLabel.Name = "EndDateLabel";
            EndDateLabel.Size = new Size(57, 15);
            EndDateLabel.TabIndex = 12;
            EndDateLabel.Text = "End Date:";
            // 
            // StartDatePicker
            // 
            StartDatePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            StartDatePicker.Format = DateTimePickerFormat.Short;
            StartDatePicker.Location = new Point(259, 51);
            StartDatePicker.Name = "StartDatePicker";
            StartDatePicker.Size = new Size(200, 23);
            StartDatePicker.TabIndex = 13;
            StartDatePicker.ValueChanged += StartDatePicker_ValueChanged;
            // 
            // EndDatePicker
            // 
            EndDatePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            EndDatePicker.Format = DateTimePickerFormat.Short;
            EndDatePicker.Location = new Point(259, 100);
            EndDatePicker.Name = "EndDatePicker";
            EndDatePicker.Size = new Size(200, 23);
            EndDatePicker.TabIndex = 14;
            EndDatePicker.ValueChanged += EndDatePicker_ValueChanged;
            // 
            // TitleTextBox
            // 
            TitleTextBox.Location = new Point(32, 107);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(200, 23);
            TitleTextBox.TabIndex = 15;
            // 
            // TextLabel
            // 
            TextLabel.AutoSize = true;
            TextLabel.Location = new Point(32, 89);
            TextLabel.Name = "TextLabel";
            TextLabel.Size = new Size(29, 15);
            TextLabel.TabIndex = 16;
            TextLabel.Text = "Title";
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new Point(32, 164);
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(200, 23);
            DescriptionTextBox.TabIndex = 17;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(32, 146);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(67, 15);
            DescriptionLabel.TabIndex = 18;
            DescriptionLabel.Text = "Description";
            // 
            // LocationLabel
            // 
            LocationLabel.AutoSize = true;
            LocationLabel.Location = new Point(32, 234);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(53, 15);
            LocationLabel.TabIndex = 19;
            LocationLabel.Text = "Location";
            // 
            // LocationBox
            // 
            LocationBox.Location = new Point(32, 254);
            LocationBox.Name = "LocationBox";
            LocationBox.Size = new Size(200, 23);
            LocationBox.TabIndex = 20;
            // 
            // ContactLabel
            // 
            ContactLabel.AutoSize = true;
            ContactLabel.Location = new Point(32, 291);
            ContactLabel.Name = "ContactLabel";
            ContactLabel.Size = new Size(49, 15);
            ContactLabel.TabIndex = 21;
            ContactLabel.Text = "Contact";
            // 
            // UrlLabel
            // 
            UrlLabel.AutoSize = true;
            UrlLabel.Location = new Point(32, 337);
            UrlLabel.Name = "UrlLabel";
            UrlLabel.Size = new Size(22, 15);
            UrlLabel.TabIndex = 22;
            UrlLabel.Text = "Url";
            // 
            // ContactTextBox
            // 
            ContactTextBox.Location = new Point(32, 311);
            ContactTextBox.Name = "ContactTextBox";
            ContactTextBox.Size = new Size(200, 23);
            ContactTextBox.TabIndex = 23;
            // 
            // UrlTextBox
            // 
            UrlTextBox.Location = new Point(32, 355);
            UrlTextBox.Name = "UrlTextBox";
            UrlTextBox.Size = new Size(200, 23);
            UrlTextBox.TabIndex = 24;
            // 
            // AddAppointment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 558);
            Controls.Add(UrlTextBox);
            Controls.Add(ContactTextBox);
            Controls.Add(UrlLabel);
            Controls.Add(ContactLabel);
            Controls.Add(LocationBox);
            Controls.Add(LocationLabel);
            Controls.Add(DescriptionLabel);
            Controls.Add(DescriptionTextBox);
            Controls.Add(TextLabel);
            Controls.Add(TitleTextBox);
            Controls.Add(EndDatePicker);
            Controls.Add(StartDatePicker);
            Controls.Add(EndDateLabel);
            Controls.Add(StartDateLabel);
            Controls.Add(AddButton);
            Controls.Add(UserDropDown);
            Controls.Add(EndTimePicker);
            Controls.Add(StartTimePicker);
            Controls.Add(TypeTextBox);
            Controls.Add(CustomerDropDown);
            Controls.Add(z);
            Controls.Add(EndTimeLabel);
            Controls.Add(StartTimeLabel);
            Controls.Add(TypeLabel);
            Controls.Add(CustomerLabel);
            Name = "AddAppointment";
            Text = "AddAppointment";
            ((System.ComponentModel.ISupportInitialize)customerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CustomerLabel;
        private Label TypeLabel;
        private Label StartTimeLabel;
        private Label EndTimeLabel;
        private Label z;
        private ComboBox CustomerDropDown;
        private BindingSource customerBindingSource;
        private TextBox TypeTextBox;
        private DateTimePicker StartTimePicker;
        private DateTimePicker EndTimePicker;
        private ComboBox UserDropDown;
        private Button AddButton;
        private Button CancelAppointmentButton;
        private BindingSource userBindingSource;
        private Label StartDateLabel;
        private Label EndDateLabel;
        private DateTimePicker StartDatePicker;
        private DateTimePicker EndDatePicker;
        private TextBox TitleTextBox;
        private Label TextLabel;
        private TextBox DescriptionTextBox;
        private Label DescriptionLabel;
        private Label LocationLabel;
        private TextBox LocationBox;
        private Label ContactLabel;
        private Label UrlLabel;
        private TextBox ContactTextBox;
        private TextBox UrlTextBox;
    }
}