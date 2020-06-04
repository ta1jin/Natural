namespace ArtGallery
{
    partial class SaveExposition
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
            this.addSelectedPaintingsButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.deletePaintingFromListButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.addPaintingsToListButton = new System.Windows.Forms.Button();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.paintingsListLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.expositionTitleTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.showroomComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // addSelectedPaintingsButton
            // 
            this.addSelectedPaintingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addSelectedPaintingsButton.Location = new System.Drawing.Point(15, 251);
            this.addSelectedPaintingsButton.Name = "addSelectedPaintingsButton";
            this.addSelectedPaintingsButton.Size = new System.Drawing.Size(75, 23);
            this.addSelectedPaintingsButton.TabIndex = 44;
            this.addSelectedPaintingsButton.Text = "Добавить";
            this.addSelectedPaintingsButton.UseVisualStyleBackColor = true;
            this.addSelectedPaintingsButton.Click += new System.EventHandler(this.addSelectedPaintingsButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(547, 278);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 35;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Название экспозиции:";
            // 
            // deletePaintingFromListButton
            // 
            this.deletePaintingFromListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deletePaintingFromListButton.Location = new System.Drawing.Point(149, 251);
            this.deletePaintingFromListButton.Name = "deletePaintingFromListButton";
            this.deletePaintingFromListButton.Size = new System.Drawing.Size(128, 23);
            this.deletePaintingFromListButton.TabIndex = 43;
            this.deletePaintingFromListButton.Text = "Удалить картину";
            this.deletePaintingFromListButton.UseVisualStyleBackColor = true;
            this.deletePaintingFromListButton.Click += new System.EventHandler(this.deletePaintingFromListButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Дата начала:";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(466, 278);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 36;
            this.closeButton.Text = "Отмена";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // addPaintingsToListButton
            // 
            this.addPaintingsToListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addPaintingsToListButton.Location = new System.Drawing.Point(15, 251);
            this.addPaintingsToListButton.Name = "addPaintingsToListButton";
            this.addPaintingsToListButton.Size = new System.Drawing.Size(128, 23);
            this.addPaintingsToListButton.TabIndex = 42;
            this.addPaintingsToListButton.Text = "Добавить картины";
            this.addPaintingsToListButton.UseVisualStyleBackColor = true;
            this.addPaintingsToListButton.Click += new System.EventHandler(this.addPaintingsToListButton_Click);
            // 
            // startDate
            // 
            this.startDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(153, 35);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(150, 20);
            this.startDate.TabIndex = 30;
            // 
            // paintingsListLabel
            // 
            this.paintingsListLabel.AutoSize = true;
            this.paintingsListLabel.Location = new System.Drawing.Point(12, 9);
            this.paintingsListLabel.Name = "paintingsListLabel";
            this.paintingsListLabel.Size = new System.Drawing.Size(35, 13);
            this.paintingsListLabel.TabIndex = 41;
            this.paintingsListLabel.Text = "label5";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Выставочный зал:";
            // 
            // expositionTitleTextBox
            // 
            this.expositionTitleTextBox.Location = new System.Drawing.Point(153, 9);
            this.expositionTitleTextBox.Name = "expositionTitleTextBox";
            this.expositionTitleTextBox.Size = new System.Drawing.Size(150, 20);
            this.expositionTitleTextBox.TabIndex = 40;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(228, 125);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 33;
            this.confirmButton.Text = "ОК";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Дата окончания:";
            // 
            // endDate
            // 
            this.endDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDate.Location = new System.Drawing.Point(153, 61);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(150, 20);
            this.endDate.TabIndex = 32;
            // 
            // showroomComboBox
            // 
            this.showroomComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showroomComboBox.FormattingEnabled = true;
            this.showroomComboBox.Location = new System.Drawing.Point(127, 253);
            this.showroomComboBox.Name = "showroomComboBox";
            this.showroomComboBox.Size = new System.Drawing.Size(150, 21);
            this.showroomComboBox.TabIndex = 39;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(607, 220);
            this.dataGridView1.TabIndex = 34;
            // 
            // SaveExposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 313);
            this.Controls.Add(this.addSelectedPaintingsButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deletePaintingFromListButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.addPaintingsToListButton);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.paintingsListLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.expositionTitleTextBox);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.showroomComboBox);
            this.Controls.Add(this.dataGridView1);
            this.MinimizeBox = false;
            this.Name = "SaveExposition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaveExposition";
            this.Load += new System.EventHandler(this.SaveExposition_Load);
            this.SizeChanged += new System.EventHandler(this.SaveExposition_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addSelectedPaintingsButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button deletePaintingFromListButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button addPaintingsToListButton;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label paintingsListLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox expositionTitleTextBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.ComboBox showroomComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}