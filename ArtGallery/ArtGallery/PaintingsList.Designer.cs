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
			this.AddPaintingButton = new System.Windows.Forms.Button();
			this.RefreshListButton = new System.Windows.Forms.Button();
			this.DeletePaintingsButton = new System.Windows.Forms.Button();
			this.Delete = new System.Windows.Forms.Button();
			this.EditPainting = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.paintingDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// paintingDataGridView
			// 
			this.paintingDataGridView.AllowUserToAddRows = false;
			this.paintingDataGridView.AllowUserToDeleteRows = false;
			this.paintingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.paintingDataGridView.Location = new System.Drawing.Point(12, 24);
			this.paintingDataGridView.Name = "paintingDataGridView";
			this.paintingDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.paintingDataGridView.Size = new System.Drawing.Size(1226, 317);
			this.paintingDataGridView.TabIndex = 0;
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
			this.RefreshListButton.Location = new System.Drawing.Point(854, 415);
			this.RefreshListButton.Name = "RefreshListButton";
			this.RefreshListButton.Size = new System.Drawing.Size(184, 23);
			this.RefreshListButton.TabIndex = 3;
			this.RefreshListButton.Text = "Обновить список картин";
			this.RefreshListButton.UseVisualStyleBackColor = true;
			this.RefreshListButton.Click += new System.EventHandler(this.RefreshListButton_Click);
			// 
			// DeletePaintingsButton
			// 
			this.DeletePaintingsButton.Location = new System.Drawing.Point(484, 415);
			this.DeletePaintingsButton.Name = "DeletePaintingsButton";
			this.DeletePaintingsButton.Size = new System.Drawing.Size(193, 23);
			this.DeletePaintingsButton.TabIndex = 4;
			this.DeletePaintingsButton.Text = "Выбрать картины для удаления";
			this.DeletePaintingsButton.UseVisualStyleBackColor = true;
			this.DeletePaintingsButton.Click += new System.EventHandler(this.DeletePaintingsButton_Click);
			// 
			// Delete
			// 
			this.Delete.Location = new System.Drawing.Point(556, 347);
			this.Delete.Name = "Delete";
			this.Delete.Size = new System.Drawing.Size(167, 40);
			this.Delete.TabIndex = 5;
			this.Delete.Text = "УДАЛИТЬ";
			this.Delete.UseVisualStyleBackColor = true;
			this.Delete.Click += new System.EventHandler(this.Delete_Click);
			// 
			// EditPainting
			// 
			this.EditPainting.Location = new System.Drawing.Point(683, 415);
			this.EditPainting.Name = "EditPainting";
			this.EditPainting.Size = new System.Drawing.Size(165, 23);
			this.EditPainting.TabIndex = 6;
			this.EditPainting.Text = "Редактировать картину";
			this.EditPainting.UseVisualStyleBackColor = true;
			this.EditPainting.Click += new System.EventHandler(this.EditPainting_Click);
			// 
			// PaintingsList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1250, 450);
			this.Controls.Add(this.EditPainting);
			this.Controls.Add(this.Delete);
			this.Controls.Add(this.DeletePaintingsButton);
			this.Controls.Add(this.RefreshListButton);
			this.Controls.Add(this.AddPaintingButton);
			this.Controls.Add(this.paintingDataGridView);
			this.Name = "PaintingsList";
			this.Text = "PaintingsList";
			((System.ComponentModel.ISupportInitialize)(this.paintingDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView paintingDataGridView;
		private System.Windows.Forms.Button AddPaintingButton;
		private System.Windows.Forms.Button RefreshListButton;
		private System.Windows.Forms.Button DeletePaintingsButton;
		private System.Windows.Forms.Button Delete;
		private System.Windows.Forms.Button EditPainting;
	}
}