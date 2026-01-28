namespace C969_Appointment_Scheduler
{
    partial class CalendarView
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
            CustomersList = new ListBox();
            CustomersLabel = new Label();
            AddButton = new Button();
            UpdateButton = new Button();
            DeleteButton = new Button();
            AppointmentsGridView = new DataGridView();
            appointmentIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customerIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            userIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            titleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            locationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            contactDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            urlDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            startDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            endDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdByDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastUpdateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastUpdateByDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            appointmentBindingSource = new BindingSource(components);
            StartRangePicker = new DateTimePicker();
            AppointmentsLabel = new Label();
            StartRangeLabel = new Label();
            AddAppointmentButton = new Button();
            UpdateAppointmentButton = new Button();
            DeleteAppButton = new Button();
            EndRangePicker = new DateTimePicker();
            EndRangeLabel = new Label();
            ViewAllAppointmentsButton = new Button();
            customerBindingSource = new BindingSource(components);
            customerBindingSource1 = new BindingSource(components);
            ViewRangeButton = new Button();
            TimeZoneLabel = new Label();
            ReportingButton = new Button();
            ((System.ComponentModel.ISupportInitialize)AppointmentsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)appointmentBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // CustomersList
            // 
            CustomersList.FormattingEnabled = true;
            CustomersList.ItemHeight = 15;
            CustomersList.Location = new Point(12, 37);
            CustomersList.Name = "CustomersList";
            CustomersList.Size = new Size(156, 349);
            CustomersList.TabIndex = 0;
            // 
            // CustomersLabel
            // 
            CustomersLabel.AutoSize = true;
            CustomersLabel.Location = new Point(12, 19);
            CustomersLabel.Name = "CustomersLabel";
            CustomersLabel.Size = new Size(64, 15);
            CustomersLabel.TabIndex = 1;
            CustomersLabel.Text = "Customers";
            // 
            // AddButton
            // 
            AddButton.Location = new Point(174, 37);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 2;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(174, 66);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(75, 23);
            UpdateButton.TabIndex = 3;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(174, 95);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 4;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // AppointmentsGridView
            // 
            AppointmentsGridView.AllowUserToAddRows = false;
            AppointmentsGridView.AllowUserToDeleteRows = false;
            AppointmentsGridView.AutoGenerateColumns = false;
            AppointmentsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AppointmentsGridView.Columns.AddRange(new DataGridViewColumn[] { appointmentIdDataGridViewTextBoxColumn, customerIdDataGridViewTextBoxColumn, userIdDataGridViewTextBoxColumn, titleDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, locationDataGridViewTextBoxColumn, contactDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, urlDataGridViewTextBoxColumn, startDataGridViewTextBoxColumn, endDataGridViewTextBoxColumn, createDateDataGridViewTextBoxColumn, createdByDataGridViewTextBoxColumn, lastUpdateDataGridViewTextBoxColumn, lastUpdateByDataGridViewTextBoxColumn });
            AppointmentsGridView.DataSource = appointmentBindingSource;
            AppointmentsGridView.Location = new Point(305, 37);
            AppointmentsGridView.MultiSelect = false;
            AppointmentsGridView.Name = "AppointmentsGridView";
            AppointmentsGridView.ReadOnly = true;
            AppointmentsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AppointmentsGridView.Size = new Size(517, 349);
            AppointmentsGridView.TabIndex = 5;
            // 
            // appointmentIdDataGridViewTextBoxColumn
            // 
            appointmentIdDataGridViewTextBoxColumn.DataPropertyName = "AppointmentId";
            appointmentIdDataGridViewTextBoxColumn.HeaderText = "AppointmentId";
            appointmentIdDataGridViewTextBoxColumn.Name = "appointmentIdDataGridViewTextBoxColumn";
            appointmentIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
            customerIdDataGridViewTextBoxColumn.HeaderText = "CustomerId";
            customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            customerIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userIdDataGridViewTextBoxColumn
            // 
            userIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            userIdDataGridViewTextBoxColumn.HeaderText = "UserId";
            userIdDataGridViewTextBoxColumn.Name = "userIdDataGridViewTextBoxColumn";
            userIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            titleDataGridViewTextBoxColumn.HeaderText = "Title";
            titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            locationDataGridViewTextBoxColumn.HeaderText = "Location";
            locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            locationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contactDataGridViewTextBoxColumn
            // 
            contactDataGridViewTextBoxColumn.DataPropertyName = "Contact";
            contactDataGridViewTextBoxColumn.HeaderText = "Contact";
            contactDataGridViewTextBoxColumn.Name = "contactDataGridViewTextBoxColumn";
            contactDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            typeDataGridViewTextBoxColumn.HeaderText = "Type";
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // urlDataGridViewTextBoxColumn
            // 
            urlDataGridViewTextBoxColumn.DataPropertyName = "Url";
            urlDataGridViewTextBoxColumn.HeaderText = "Url";
            urlDataGridViewTextBoxColumn.Name = "urlDataGridViewTextBoxColumn";
            urlDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startDataGridViewTextBoxColumn
            // 
            startDataGridViewTextBoxColumn.DataPropertyName = "Start";
            startDataGridViewTextBoxColumn.HeaderText = "Start";
            startDataGridViewTextBoxColumn.Name = "startDataGridViewTextBoxColumn";
            startDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endDataGridViewTextBoxColumn
            // 
            endDataGridViewTextBoxColumn.DataPropertyName = "End";
            endDataGridViewTextBoxColumn.HeaderText = "End";
            endDataGridViewTextBoxColumn.Name = "endDataGridViewTextBoxColumn";
            endDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            createDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate";
            createDateDataGridViewTextBoxColumn.HeaderText = "CreateDate";
            createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            createDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdByDataGridViewTextBoxColumn
            // 
            createdByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy";
            createdByDataGridViewTextBoxColumn.HeaderText = "CreatedBy";
            createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
            createdByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastUpdateDataGridViewTextBoxColumn
            // 
            lastUpdateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdate";
            lastUpdateDataGridViewTextBoxColumn.HeaderText = "LastUpdate";
            lastUpdateDataGridViewTextBoxColumn.Name = "lastUpdateDataGridViewTextBoxColumn";
            lastUpdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastUpdateByDataGridViewTextBoxColumn
            // 
            lastUpdateByDataGridViewTextBoxColumn.DataPropertyName = "LastUpdateBy";
            lastUpdateByDataGridViewTextBoxColumn.HeaderText = "LastUpdateBy";
            lastUpdateByDataGridViewTextBoxColumn.Name = "lastUpdateByDataGridViewTextBoxColumn";
            lastUpdateByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // appointmentBindingSource
            // 
            appointmentBindingSource.DataSource = typeof(Appointment);
            // 
            // StartRangePicker
            // 
            StartRangePicker.Location = new Point(456, 406);
            StartRangePicker.Name = "StartRangePicker";
            StartRangePicker.Size = new Size(200, 23);
            StartRangePicker.TabIndex = 6;
            // 
            // AppointmentsLabel
            // 
            AppointmentsLabel.AutoSize = true;
            AppointmentsLabel.Location = new Point(305, 19);
            AppointmentsLabel.Name = "AppointmentsLabel";
            AppointmentsLabel.Size = new Size(83, 15);
            AppointmentsLabel.TabIndex = 7;
            AppointmentsLabel.Text = "Appointments";
            // 
            // StartRangeLabel
            // 
            StartRangeLabel.AutoSize = true;
            StartRangeLabel.Location = new Point(456, 389);
            StartRangeLabel.Name = "StartRangeLabel";
            StartRangeLabel.Size = new Size(67, 15);
            StartRangeLabel.TabIndex = 8;
            StartRangeLabel.Text = "Start Range";
            // 
            // AddAppointmentButton
            // 
            AddAppointmentButton.Location = new Point(828, 37);
            AddAppointmentButton.Name = "AddAppointmentButton";
            AddAppointmentButton.Size = new Size(75, 23);
            AddAppointmentButton.TabIndex = 9;
            AddAppointmentButton.Text = "Add";
            AddAppointmentButton.UseVisualStyleBackColor = true;
            AddAppointmentButton.Click += AddAppointmentButton_Click;
            // 
            // UpdateAppointmentButton
            // 
            UpdateAppointmentButton.Location = new Point(828, 66);
            UpdateAppointmentButton.Name = "UpdateAppointmentButton";
            UpdateAppointmentButton.Size = new Size(75, 23);
            UpdateAppointmentButton.TabIndex = 10;
            UpdateAppointmentButton.Text = "Update";
            UpdateAppointmentButton.UseVisualStyleBackColor = true;
            UpdateAppointmentButton.Click += UpdateAppointmentButton_Click;
            // 
            // DeleteAppButton
            // 
            DeleteAppButton.Location = new Point(828, 95);
            DeleteAppButton.Name = "DeleteAppButton";
            DeleteAppButton.Size = new Size(75, 23);
            DeleteAppButton.TabIndex = 11;
            DeleteAppButton.Text = "Delete";
            DeleteAppButton.UseVisualStyleBackColor = true;
            DeleteAppButton.Click += DeleteAppButton_Click;
            // 
            // EndRangePicker
            // 
            EndRangePicker.Location = new Point(455, 448);
            EndRangePicker.Name = "EndRangePicker";
            EndRangePicker.Size = new Size(200, 23);
            EndRangePicker.TabIndex = 12;
            // 
            // EndRangeLabel
            // 
            EndRangeLabel.AutoSize = true;
            EndRangeLabel.Location = new Point(456, 431);
            EndRangeLabel.Name = "EndRangeLabel";
            EndRangeLabel.Size = new Size(63, 15);
            EndRangeLabel.TabIndex = 13;
            EndRangeLabel.Text = "End Range";
            // 
            // ViewAllAppointmentsButton
            // 
            ViewAllAppointmentsButton.Location = new Point(684, 448);
            ViewAllAppointmentsButton.Name = "ViewAllAppointmentsButton";
            ViewAllAppointmentsButton.Size = new Size(137, 23);
            ViewAllAppointmentsButton.TabIndex = 14;
            ViewAllAppointmentsButton.Text = "View All Appointments";
            ViewAllAppointmentsButton.UseVisualStyleBackColor = true;
            ViewAllAppointmentsButton.Click += ViewAllAppointmentsButton_Click;
            // 
            // customerBindingSource
            // 
            customerBindingSource.DataSource = typeof(Customer);
            // 
            // customerBindingSource1
            // 
            customerBindingSource1.DataSource = typeof(Customer);
            // 
            // ViewRangeButton
            // 
            ViewRangeButton.Location = new Point(685, 406);
            ViewRangeButton.Name = "ViewRangeButton";
            ViewRangeButton.Size = new Size(136, 23);
            ViewRangeButton.TabIndex = 15;
            ViewRangeButton.Text = "View In Range";
            ViewRangeButton.UseVisualStyleBackColor = true;
            ViewRangeButton.Click += ViewRangeButton_Click;
            // 
            // TimeZoneLabel
            // 
            TimeZoneLabel.AutoSize = true;
            TimeZoneLabel.Location = new Point(456, 474);
            TimeZoneLabel.Name = "TimeZoneLabel";
            TimeZoneLabel.Size = new Size(90, 15);
            TimeZoneLabel.TabIndex = 16;
            TimeZoneLabel.Text = "Time Zone: XXX";
            // 
            // ReportingButton
            // 
            ReportingButton.Location = new Point(305, 406);
            ReportingButton.Name = "ReportingButton";
            ReportingButton.Size = new Size(100, 23);
            ReportingButton.TabIndex = 17;
            ReportingButton.Text = "Reports";
            ReportingButton.UseVisualStyleBackColor = true;
            ReportingButton.Click += ReportingButton_Click;
            // 
            // CalendarView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 507);
            Controls.Add(ReportingButton);
            Controls.Add(TimeZoneLabel);
            Controls.Add(ViewRangeButton);
            Controls.Add(ViewAllAppointmentsButton);
            Controls.Add(EndRangeLabel);
            Controls.Add(EndRangePicker);
            Controls.Add(DeleteAppButton);
            Controls.Add(UpdateAppointmentButton);
            Controls.Add(AddAppointmentButton);
            Controls.Add(StartRangeLabel);
            Controls.Add(AppointmentsLabel);
            Controls.Add(StartRangePicker);
            Controls.Add(AppointmentsGridView);
            Controls.Add(DeleteButton);
            Controls.Add(UpdateButton);
            Controls.Add(AddButton);
            Controls.Add(CustomersLabel);
            Controls.Add(CustomersList);
            Name = "CalendarView";
            Text = "CalendarView";
            Load += CalendarView_Load;
            ((System.ComponentModel.ISupportInitialize)AppointmentsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)appointmentBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox CustomersList;
        private Label CustomersLabel;
        private Button AddButton;
        private Button UpdateButton;
        private Button DeleteButton;
        private DataGridView AppointmentsGridView;
        private DateTimePicker StartRangePicker;
        private Label AppointmentsLabel;
        private Label StartRangeLabel;
        private Button AddAppointmentButton;
        private Button UpdateAppointmentButton;
        private Button DeleteAppButton;
        private DateTimePicker EndRangePicker;
        private Label EndRangeLabel;
        private Button ViewAllAppointmentsButton;
        private BindingSource customerBindingSource;
        private BindingSource customerBindingSource1;
        private DataGridViewTextBoxColumn appointmentIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn contactDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn endDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastUpdateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastUpdateByDataGridViewTextBoxColumn;
        private BindingSource appointmentBindingSource;
        private Button ViewRangeButton;
        private Label TimeZoneLabel;
        private Button ReportingButton;
    }
}