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
            CustomersList = new ListBox();
            CustomersLabel = new Label();
            AddButton = new Button();
            UpdateButton = new Button();
            DeleteButton = new Button();
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
            CustomersList.SelectedIndexChanged += CustomersList_SelectedIndexChanged;
            // 
            // CustomersLabel
            // 
            CustomersLabel.AutoSize = true;
            CustomersLabel.Location = new Point(33, 19);
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
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(174, 95);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 4;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // CalendarView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DeleteButton);
            Controls.Add(UpdateButton);
            Controls.Add(AddButton);
            Controls.Add(CustomersLabel);
            Controls.Add(CustomersList);
            Name = "CalendarView";
            Text = "CalendarView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox CustomersList;
        private Label CustomersLabel;
        private Button AddButton;
        private Button UpdateButton;
        private Button DeleteButton;
    }
}