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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.глянутьКартиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelExpoBtn = new System.Windows.Forms.Button();
            this.editExpoBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.expoGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // expoGridView
            // 
            this.expoGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expoGridView.Location = new System.Drawing.Point(14, 83);
            this.expoGridView.Name = "expoGridView";
            this.expoGridView.RowHeadersWidth = 51;
            this.expoGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.expoGridView.Size = new System.Drawing.Size(688, 328);
            this.expoGridView.TabIndex = 0;
            // 
            // addExpoBtn
            // 
            this.addExpoBtn.Location = new System.Drawing.Point(14, 27);
            this.addExpoBtn.Name = "addExpoBtn";
            this.addExpoBtn.Size = new System.Drawing.Size(142, 23);
            this.addExpoBtn.TabIndex = 2;
            this.addExpoBtn.Text = "Добавить экспозицию";
            this.addExpoBtn.UseVisualStyleBackColor = true;
            this.addExpoBtn.Click += new System.EventHandler(this.addExpoBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.глянутьКартиныToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(712, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // глянутьКартиныToolStripMenuItem
            // 
            this.глянутьКартиныToolStripMenuItem.Name = "глянутьКартиныToolStripMenuItem";
            this.глянутьКартиныToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.глянутьКартиныToolStripMenuItem.Text = "Глянуть картины";
            // 
            // cancelExpoBtn
            // 
            this.cancelExpoBtn.Location = new System.Drawing.Point(162, 27);
            this.cancelExpoBtn.Name = "cancelExpoBtn";
            this.cancelExpoBtn.Size = new System.Drawing.Size(142, 23);
            this.cancelExpoBtn.TabIndex = 4;
            this.cancelExpoBtn.Text = "Отменить экспозицию";
            this.cancelExpoBtn.UseVisualStyleBackColor = true;
            this.cancelExpoBtn.Click += new System.EventHandler(this.cancelExpoBtn_Click);
            // 
            // editExpoBtn
            // 
            this.editExpoBtn.Location = new System.Drawing.Point(310, 27);
            this.editExpoBtn.Name = "editExpoBtn";
            this.editExpoBtn.Size = new System.Drawing.Size(142, 23);
            this.editExpoBtn.TabIndex = 5;
            this.editExpoBtn.Text = "Изменить экспозицию";
            this.editExpoBtn.UseVisualStyleBackColor = true;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(625, 54);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 6;
            this.refreshBtn.Text = "Обновить";
            this.refreshBtn.UseVisualStyleBackColor = true;
            // 
            // ShowExpositions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 423);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.editExpoBtn);
            this.Controls.Add(this.cancelExpoBtn);
            this.Controls.Add(this.addExpoBtn);
            this.Controls.Add(this.expoGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ShowExpositions";
            this.Text = "Список экспозиций";
            ((System.ComponentModel.ISupportInitialize)(this.expoGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView expoGridView;
        private System.Windows.Forms.Button addExpoBtn;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem глянутьКартиныToolStripMenuItem;
        private System.Windows.Forms.Button cancelExpoBtn;
        private System.Windows.Forms.Button editExpoBtn;
        private System.Windows.Forms.Button refreshBtn;
    }
}