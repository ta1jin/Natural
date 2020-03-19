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
            this.startDate = new System.Windows.Forms.MaskedTextBox();
            this.endDate = new System.Windows.Forms.MaskedTextBox();
            this.paintingsDataGridView = new System.Windows.Forms.DataGridView();
            this.saveExpositionBtn = new System.Windows.Forms.Button();
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
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(12, 27);
            this.startDate.Mask = "00/00/0000 90:00";
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(100, 20);
            this.startDate.TabIndex = 5;
            this.startDate.ValidatingType = typeof(System.DateTime);
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(13, 71);
            this.endDate.Mask = "00/00/0000 90:00";
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(100, 20);
            this.endDate.TabIndex = 6;
            this.endDate.ValidatingType = typeof(System.DateTime);
            // 
            // paintingsDataGridView
            // 
            this.paintingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paintingsDataGridView.Location = new System.Drawing.Point(131, 12);
            this.paintingsDataGridView.Name = "paintingsDataGridView";
            this.paintingsDataGridView.Size = new System.Drawing.Size(306, 429);
            this.paintingsDataGridView.TabIndex = 7;
            // 
            // saveExpositionBtn
            // 
            this.saveExpositionBtn.Location = new System.Drawing.Point(362, 447);
            this.saveExpositionBtn.Name = "saveExpositionBtn";
            this.saveExpositionBtn.Size = new System.Drawing.Size(75, 23);
            this.saveExpositionBtn.TabIndex = 8;
            this.saveExpositionBtn.Text = "ОК";
            this.saveExpositionBtn.UseVisualStyleBackColor = true;
            this.saveExpositionBtn.Click += new System.EventHandler(this.saveExpositionBtn_Click);
            // 
            // AddExposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 481);
            this.Controls.Add(this.saveExpositionBtn);
            this.Controls.Add(this.paintingsDataGridView);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
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
        private System.Windows.Forms.MaskedTextBox startDate;
        private System.Windows.Forms.MaskedTextBox endDate;
        private System.Windows.Forms.DataGridView paintingsDataGridView;
        private System.Windows.Forms.Button saveExpositionBtn;
    }
}