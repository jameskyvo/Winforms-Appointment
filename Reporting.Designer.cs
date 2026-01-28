namespace C969_Appointment_Scheduler
{
    partial class Reporting
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
            ReportingLabel = new Label();
            UserDropdownBox = new ComboBox();
            userBindingSource = new BindingSource(components);
            ConsultantLabel = new Label();
            CheckUserScheduleButton = new Button();
            NumberOfTypesByMonthButton = new Button();
            NumberOfFutureAppointmentsButton = new Button();
            UserScheduleDGV = new DataGridView();
            FutureAppointmentsLabel = new Label();
            MonthPicker = new DateTimePicker();
            TypesListBox = new ListBox();
            NumberOfTypesLabel = new Label();
            ExitButton = new Button();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UserScheduleDGV).BeginInit();
            SuspendLayout();
            // 
            // ReportingLabel
            // 
            ReportingLabel.AutoSize = true;
            ReportingLabel.Location = new Point(12, 15);
            ReportingLabel.Name = "ReportingLabel";
            ReportingLabel.Size = new Size(76, 15);
            ReportingLabel.TabIndex = 3;
            ReportingLabel.Text = "Select Report";
            // 
            // UserDropdownBox
            // 
            UserDropdownBox.DataSource = userBindingSource;
            UserDropdownBox.DisplayMember = "UserName";
            UserDropdownBox.FormattingEnabled = true;
            UserDropdownBox.Location = new Point(559, 67);
            UserDropdownBox.Name = "UserDropdownBox";
            UserDropdownBox.Size = new Size(229, 23);
            UserDropdownBox.TabIndex = 9;
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(User);
            // 
            // ConsultantLabel
            // 
            ConsultantLabel.AutoSize = true;
            ConsultantLabel.Location = new Point(559, 49);
            ConsultantLabel.Name = "ConsultantLabel";
            ConsultantLabel.Size = new Size(70, 15);
            ConsultantLabel.TabIndex = 10;
            ConsultantLabel.Text = "Consultants";
            // 
            // CheckUserScheduleButton
            // 
            CheckUserScheduleButton.Location = new Point(559, 262);
            CheckUserScheduleButton.Name = "CheckUserScheduleButton";
            CheckUserScheduleButton.Size = new Size(229, 23);
            CheckUserScheduleButton.TabIndex = 11;
            CheckUserScheduleButton.Text = "Check User Schedule";
            CheckUserScheduleButton.UseVisualStyleBackColor = true;
            CheckUserScheduleButton.Click += CheckUserScheduleButton_Click;
            // 
            // NumberOfTypesByMonthButton
            // 
            NumberOfTypesByMonthButton.Location = new Point(284, 262);
            NumberOfTypesByMonthButton.Name = "NumberOfTypesByMonthButton";
            NumberOfTypesByMonthButton.Size = new Size(229, 23);
            NumberOfTypesByMonthButton.TabIndex = 12;
            NumberOfTypesByMonthButton.Text = "Check Number of Types By Month";
            NumberOfTypesByMonthButton.UseVisualStyleBackColor = true;
            NumberOfTypesByMonthButton.Click += NumberOfTypesByMonthButton_Click;
            // 
            // NumberOfFutureAppointmentsButton
            // 
            NumberOfFutureAppointmentsButton.Location = new Point(12, 67);
            NumberOfFutureAppointmentsButton.Name = "NumberOfFutureAppointmentsButton";
            NumberOfFutureAppointmentsButton.Size = new Size(229, 23);
            NumberOfFutureAppointmentsButton.TabIndex = 13;
            NumberOfFutureAppointmentsButton.Text = "Check Total Future Appointments";
            NumberOfFutureAppointmentsButton.UseVisualStyleBackColor = true;
            NumberOfFutureAppointmentsButton.Click += NumberOfFutureAppointmentsButton_Click;
            // 
            // UserScheduleDGV
            // 
            UserScheduleDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UserScheduleDGV.Location = new Point(559, 103);
            UserScheduleDGV.Name = "UserScheduleDGV";
            UserScheduleDGV.Size = new Size(229, 150);
            UserScheduleDGV.TabIndex = 14;
            // 
            // FutureAppointmentsLabel
            // 
            FutureAppointmentsLabel.AutoSize = true;
            FutureAppointmentsLabel.Location = new Point(12, 49);
            FutureAppointmentsLabel.Name = "FutureAppointmentsLabel";
            FutureAppointmentsLabel.Size = new Size(154, 15);
            FutureAppointmentsLabel.TabIndex = 16;
            FutureAppointmentsLabel.Text = "Total Future Appointments: ";
            // 
            // MonthPicker
            // 
            MonthPicker.CustomFormat = "MMM";
            MonthPicker.Format = DateTimePickerFormat.Custom;
            MonthPicker.Location = new Point(284, 67);
            MonthPicker.Name = "MonthPicker";
            MonthPicker.Size = new Size(229, 23);
            MonthPicker.TabIndex = 17;
            // 
            // TypesListBox
            // 
            TypesListBox.FormattingEnabled = true;
            TypesListBox.ItemHeight = 15;
            TypesListBox.Location = new Point(284, 99);
            TypesListBox.Name = "TypesListBox";
            TypesListBox.Size = new Size(229, 154);
            TypesListBox.TabIndex = 18;
            // 
            // NumberOfTypesLabel
            // 
            NumberOfTypesLabel.AutoSize = true;
            NumberOfTypesLabel.Location = new Point(284, 49);
            NumberOfTypesLabel.Name = "NumberOfTypesLabel";
            NumberOfTypesLabel.Size = new Size(152, 15);
            NumberOfTypesLabel.TabIndex = 19;
            NumberOfTypesLabel.Text = "Number of Types By Month";
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(713, 350);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(75, 23);
            ExitButton.TabIndex = 20;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // Reporting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 385);
            Controls.Add(ExitButton);
            Controls.Add(NumberOfTypesLabel);
            Controls.Add(TypesListBox);
            Controls.Add(MonthPicker);
            Controls.Add(FutureAppointmentsLabel);
            Controls.Add(UserScheduleDGV);
            Controls.Add(NumberOfFutureAppointmentsButton);
            Controls.Add(NumberOfTypesByMonthButton);
            Controls.Add(CheckUserScheduleButton);
            Controls.Add(ConsultantLabel);
            Controls.Add(UserDropdownBox);
            Controls.Add(ReportingLabel);
            Name = "Reporting";
            Text = "Reporting";
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)UserScheduleDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label ReportingLabel;
        private ComboBox UserDropdownBox;
        private Label ConsultantLabel;
        private BindingSource userBindingSource;
        private Button CheckUserScheduleButton;
        private Button NumberOfTypesByMonthButton;
        private Button NumberOfFutureAppointmentsButton;
        private DataGridView UserScheduleDGV;
        private Label FutureAppointmentsLabel;
        private DateTimePicker MonthPicker;
        private ListBox TypesListBox;
        private Label NumberOfTypesLabel;
        private Button ExitButton;
    }
}