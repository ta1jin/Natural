namespace ArtGallery
{
	partial class PaintingsList
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
			this.paintingDataGridView = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.глянутьЭкспозицииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AddPaintingButton = new System.Windows.Forms.Button();
			this.RefreshListButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.paintingDataGridView)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// paintingDataGridView
			// 
			this.paintingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.paintingDataGridView.Location = new System.Drawing.Point(12, 24);
			this.paintingDataGridView.Name = "paintingDataGridView";
			this.paintingDataGridView.Size = new System.Drawing.Size(1226, 317);
			this.paintingDataGridView.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.глянутьЭкспозицииToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1250, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// глянутьЭкспозицииToolStripMenuItem
			// 
			this.глянутьЭкспозицииToolStripMenuItem.Name = "глянутьЭкспозицииToolStripMenuItem";
			this.глянутьЭкспозицииToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
			this.глянутьЭкспозицииToolStripMenuItem.Text = "Глянуть экспозиции";
			this.глянутьЭкспозицииToolStripMenuItem.Click += new System.EventHandler(this.глянутьЭкспозицииToolStripMenuItem_Click);
			// 
			// AddPaintingButton
			// 
			this.AddPaintingButton.Location = new System.Drawing.Point(1044, 415);
			this.AddPaintingButton.Name = "AddPaintingButton";
			this.AddPaintingButton.Size = new System.Drawing.Size(194, 23);
			this.AddPaintingButton.TabIndex = 2;
			this.AddPaintingButton.Text = "Добавить картину";
			this.AddPaintingButton.UseVisualStyleBackColor = true;
			this.AddPaintingButton.Click += new System.EventHandler(this.AddPainting_Click);
			// 
			// RefreshListButton
			// 
			this.RefreshListButton.Location = new System.Drawing.Point(895, 415);
			this.RefreshListButton.Name = "RefreshListButton";
			this.RefreshListButton.Size = new System.Drawing.Size(143, 23);
			this.RefreshListButton.TabIndex = 3;
			this.RefreshListButton.Text = "Обновить список";
			this.RefreshListButton.UseVisualStyleBackColor = true;
			this.RefreshListButton.Click += new System.EventHandler(this.RefreshListButton_Click);
			// 
			// PaintingsList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1250, 450);
			this.Controls.Add(this.RefreshListButton);
			this.Controls.Add(this.AddPaintingButton);
			this.Controls.Add(this.paintingDataGridView);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "PaintingsList";
			this.Text = "PaintingsList";
			((System.ComponentModel.ISupportInitialize)(this.paintingDataGridView)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView paintingDataGridView;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem глянутьЭкспозицииToolStripMenuItem;
		private System.Windows.Forms.Button AddPaintingButton;
		private System.Windows.Forms.Button RefreshListButton;
	}
}