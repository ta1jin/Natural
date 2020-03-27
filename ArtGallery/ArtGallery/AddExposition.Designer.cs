namespace ArtGallery
{
    partial class AddExposition
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
            this.confirmDateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paintingsDataGridView = new System.Windows.Forms.DataGridView();
            this.saveExpositionBtn = new System.Windows.Forms.Button();
            this.expoName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.expoLocation = new System.Windows.Forms.TextBox();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.paintingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // confirmDateBtn
            // 
            this.confirmDateBtn.Location = new System.Drawing.Point(12, 97);
            this.confirmDateBtn.Name = "confirmDateBtn";
            this.confirmDateBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmDateBtn.TabIndex = 2;
            this.confirmDateBtn.Text = "ОК";
            this.confirmDateBtn.UseVisualStyleBackColor = true;
            this.confirmDateBtn.Click += new System.EventHandler(this.confirmDateBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Дата начала";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Дата окончания";
            // 
            // paintingsDataGridView
            // 
            this.paintingsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paintingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paintingsDataGridView.Location = new System.Drawing.Point(219, 12);
            this.paintingsDataGridView.Name = "paintingsDataGridView";
            this.paintingsDataGridView.Size = new System.Drawing.Size(636, 209);
            this.paintingsDataGridView.TabIndex = 7;
            // 
            // saveExpositionBtn
            // 
            this.saveExpositionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveExpositionBtn.Location = new System.Drawing.Point(780, 447);
            this.saveExpositionBtn.Name = "saveExpositionBtn";
            this.saveExpositionBtn.Size = new System.Drawing.Size(75, 23);
            this.saveExpositionBtn.TabIndex = 8;
            this.saveExpositionBtn.Text = "ОК";
            this.saveExpositionBtn.UseVisualStyleBackColor = true;
            this.saveExpositionBtn.Click += new System.EventHandler(this.saveExpositionBtn_Click);
            // 
            // expoName
            // 
            this.expoName.Location = new System.Drawing.Point(219, 247);
            this.expoName.Name = "expoName";
            this.expoName.Size = new System.Drawing.Size(176, 20);
            this.expoName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Название экспозиции";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Место проведения";
            // 
            // expoLocation
            // 
            this.expoLocation.Location = new System.Drawing.Point(219, 296);
            this.expoLocation.Name = "expoLocation";
            this.expoLocation.Size = new System.Drawing.Size(176, 20);
            this.expoLocation.TabIndex = 12;
            // 
            // startDate
            // 
            this.startDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(13, 27);
            this.startDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.startDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(200, 20);
            this.startDate.TabIndex = 13;
            this.startDate.TabStop = false;
            // 
            // endDate
            // 
            this.endDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDate.Location = new System.Drawing.Point(13, 71);
            this.endDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.endDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(200, 20);
            this.endDate.TabIndex = 14;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(699, 447);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // AddExposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 481);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.expoLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.expoName);
            this.Controls.Add(this.saveExpositionBtn);
            this.Controls.Add(this.paintingsDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmDateBtn);
            this.Name = "AddExposition";
            this.Text = "Добавление экспозиции";
            ((System.ComponentModel.ISupportInitialize)(this.paintingsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmDateBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView paintingsDataGridView;
        private System.Windows.Forms.Button saveExpositionBtn;
        private System.Windows.Forms.TextBox expoName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox expoLocation;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Button cancelBtn;
    }
}