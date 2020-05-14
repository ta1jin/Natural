namespace ArtGallery
{
    partial class ShowExpositions
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
            this.expoGridView = new System.Windows.Forms.DataGridView();
            this.addExpoBtn = new System.Windows.Forms.Button();
            this.глянутьКартиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelExpoBtn = new System.Windows.Forms.Button();
            this.editExpoBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.showPaintingsBtn = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.expoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // expoGridView
            // 
            this.expoGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expoGridView.Location = new System.Drawing.Point(12, 83);
            this.expoGridView.Name = "expoGridView";
            this.expoGridView.RowHeadersWidth = 51;
            this.expoGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.expoGridView.Size = new System.Drawing.Size(688, 336);
            this.expoGridView.TabIndex = 0;
            // 
            // addExpoBtn
            // 
            this.addExpoBtn.Location = new System.Drawing.Point(12, 12);
            this.addExpoBtn.Name = "addExpoBtn";
            this.addExpoBtn.Size = new System.Drawing.Size(142, 23);
            this.addExpoBtn.TabIndex = 2;
            this.addExpoBtn.Text = "Добавить экспозицию";
            this.addExpoBtn.UseVisualStyleBackColor = true;
            this.addExpoBtn.Click += new System.EventHandler(this.addExpoBtn_Click);
            // 
            // глянутьКартиныToolStripMenuItem
            // 
            this.глянутьКартиныToolStripMenuItem.Name = "глянутьКартиныToolStripMenuItem";
            this.глянутьКартиныToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // cancelExpoBtn
            // 
            this.cancelExpoBtn.Location = new System.Drawing.Point(160, 12);
            this.cancelExpoBtn.Name = "cancelExpoBtn";
            this.cancelExpoBtn.Size = new System.Drawing.Size(142, 23);
            this.cancelExpoBtn.TabIndex = 4;
            this.cancelExpoBtn.Text = "Отменить экспозицию";
            this.cancelExpoBtn.UseVisualStyleBackColor = true;
            this.cancelExpoBtn.Click += new System.EventHandler(this.cancelExpoBtn_Click);
            // 
            // editExpoBtn
            // 
            this.editExpoBtn.Location = new System.Drawing.Point(308, 12);
            this.editExpoBtn.Name = "editExpoBtn";
            this.editExpoBtn.Size = new System.Drawing.Size(142, 23);
            this.editExpoBtn.TabIndex = 5;
            this.editExpoBtn.Text = "Изменить экспозицию";
            this.editExpoBtn.UseVisualStyleBackColor = true;
            this.editExpoBtn.Click += new System.EventHandler(this.editExpoBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(625, 12);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 6;
            this.refreshBtn.Text = "Обновить";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // showPaintingsBtn
            // 
            this.showPaintingsBtn.Location = new System.Drawing.Point(12, 54);
            this.showPaintingsBtn.Name = "showPaintingsBtn";
            this.showPaintingsBtn.Size = new System.Drawing.Size(142, 23);
            this.showPaintingsBtn.TabIndex = 7;
            this.showPaintingsBtn.Text = "Глянуть картины";
            this.showPaintingsBtn.UseVisualStyleBackColor = true;
            this.showPaintingsBtn.Click += new System.EventHandler(this.showPaintingsBtn_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(625, 429);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ShowExpositions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 464);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.showPaintingsBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.editExpoBtn);
            this.Controls.Add(this.cancelExpoBtn);
            this.Controls.Add(this.addExpoBtn);
            this.Controls.Add(this.expoGridView);
            this.Name = "ShowExpositions";
            this.Text = "Список экспозиций";
            ((System.ComponentModel.ISupportInitialize)(this.expoGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView expoGridView;
        private System.Windows.Forms.Button addExpoBtn;
		private System.Windows.Forms.ToolStripMenuItem глянутьКартиныToolStripMenuItem;
        private System.Windows.Forms.Button cancelExpoBtn;
        private System.Windows.Forms.Button editExpoBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button showPaintingsBtn;
        private System.Windows.Forms.Button closeButton;
    }
}