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
			this.PropertiesComboBox = new System.Windows.Forms.ComboBox();
			this.ValuesComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SearchTextBox = new System.Windows.Forms.TextBox();
			this.AddArtist = new System.Windows.Forms.Button();
			this.AddGenre = new System.Windows.Forms.Button();
			this.AddPaintingTechnique = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.paintingDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// paintingDataGridView
			// 
			this.paintingDataGridView.AllowUserToAddRows = false;
			this.paintingDataGridView.AllowUserToDeleteRows = false;
			this.paintingDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.paintingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.paintingDataGridView.Location = new System.Drawing.Point(12, 65);
			this.paintingDataGridView.Name = "paintingDataGridView";
			this.paintingDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.paintingDataGridView.Size = new System.Drawing.Size(1306, 401);
			this.paintingDataGridView.TabIndex = 0;
			// 
			// AddPaintingButton
			// 
			this.AddPaintingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AddPaintingButton.Location = new System.Drawing.Point(381, 518);
			this.AddPaintingButton.Name = "AddPaintingButton";
			this.AddPaintingButton.Size = new System.Drawing.Size(183, 23);
			this.AddPaintingButton.TabIndex = 2;
			this.AddPaintingButton.Text = "Добавить картину";
			this.AddPaintingButton.UseVisualStyleBackColor = true;
			this.AddPaintingButton.Click += new System.EventHandler(this.AddPainting_Click);
			// 
			// RefreshListButton
			// 
			this.RefreshListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.RefreshListButton.Location = new System.Drawing.Point(570, 518);
			this.RefreshListButton.Name = "RefreshListButton";
			this.RefreshListButton.Size = new System.Drawing.Size(178, 23);
			this.RefreshListButton.TabIndex = 3;
			this.RefreshListButton.Text = "Обновить список картин";
			this.RefreshListButton.UseVisualStyleBackColor = true;
			this.RefreshListButton.Click += new System.EventHandler(this.RefreshListButton_Click);
			// 
			// DeletePaintingsButton
			// 
			this.DeletePaintingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.DeletePaintingsButton.Location = new System.Drawing.Point(12, 518);
			this.DeletePaintingsButton.Name = "DeletePaintingsButton";
			this.DeletePaintingsButton.Size = new System.Drawing.Size(193, 23);
			this.DeletePaintingsButton.TabIndex = 4;
			this.DeletePaintingsButton.Text = "Выбрать картины для удаления";
			this.DeletePaintingsButton.UseVisualStyleBackColor = true;
			this.DeletePaintingsButton.Click += new System.EventHandler(this.DeletePaintingsButton_Click);
			// 
			// Delete
			// 
			this.Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Delete.Location = new System.Drawing.Point(12, 472);
			this.Delete.Name = "Delete";
			this.Delete.Size = new System.Drawing.Size(193, 40);
			this.Delete.TabIndex = 5;
			this.Delete.Text = "УДАЛИТЬ";
			this.Delete.UseVisualStyleBackColor = true;
			this.Delete.Click += new System.EventHandler(this.Delete_Click);
			// 
			// EditPainting
			// 
			this.EditPainting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.EditPainting.Location = new System.Drawing.Point(211, 518);
			this.EditPainting.Name = "EditPainting";
			this.EditPainting.Size = new System.Drawing.Size(165, 23);
			this.EditPainting.TabIndex = 6;
			this.EditPainting.Text = "Редактировать картину";
			this.EditPainting.UseVisualStyleBackColor = true;
			this.EditPainting.Click += new System.EventHandler(this.EditPainting_Click);
			// 
			// PropertiesComboBox
			// 
			this.PropertiesComboBox.FormattingEnabled = true;
			this.PropertiesComboBox.Location = new System.Drawing.Point(74, 12);
			this.PropertiesComboBox.Name = "PropertiesComboBox";
			this.PropertiesComboBox.Size = new System.Drawing.Size(212, 21);
			this.PropertiesComboBox.TabIndex = 7;
			this.PropertiesComboBox.SelectedIndexChanged += new System.EventHandler(this.ValuesComboBoxFill);
			// 
			// ValuesComboBox
			// 
			this.ValuesComboBox.FormattingEnabled = true;
			this.ValuesComboBox.Location = new System.Drawing.Point(427, 12);
			this.ValuesComboBox.Name = "ValuesComboBox";
			this.ValuesComboBox.Size = new System.Drawing.Size(204, 21);
			this.ValuesComboBox.TabIndex = 8;
			this.ValuesComboBox.SelectedIndexChanged += new System.EventHandler(this.ValuesComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Найти по ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(301, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Возможные варианты";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(343, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Или по тексту";
			// 
			// SearchTextBox
			// 
			this.SearchTextBox.Location = new System.Drawing.Point(427, 39);
			this.SearchTextBox.Name = "SearchTextBox";
			this.SearchTextBox.Size = new System.Drawing.Size(204, 20);
			this.SearchTextBox.TabIndex = 12;
			this.SearchTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SearchTextBox_MouseClick);
			this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
			this.SearchTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchTextBox_KeyUp);
			// 
			// AddArtist
			// 
			this.AddArtist.Location = new System.Drawing.Point(754, 518);
			this.AddArtist.Name = "AddArtist";
			this.AddArtist.Size = new System.Drawing.Size(179, 23);
			this.AddArtist.TabIndex = 13;
			this.AddArtist.Text = "Добавить художника";
			this.AddArtist.UseVisualStyleBackColor = true;
			this.AddArtist.Click += new System.EventHandler(this.AddArtist_Click);
			// 
			// AddGenre
			// 
			this.AddGenre.Location = new System.Drawing.Point(939, 518);
			this.AddGenre.Name = "AddGenre";
			this.AddGenre.Size = new System.Drawing.Size(177, 23);
			this.AddGenre.TabIndex = 14;
			this.AddGenre.Text = "Добавить жанр";
			this.AddGenre.UseVisualStyleBackColor = true;
			this.AddGenre.Click += new System.EventHandler(this.AddGenre_Click);
			// 
			// AddPaintingTechnique
			// 
			this.AddPaintingTechnique.Location = new System.Drawing.Point(1128, 518);
			this.AddPaintingTechnique.Name = "AddPaintingTechnique";
			this.AddPaintingTechnique.Size = new System.Drawing.Size(190, 23);
			this.AddPaintingTechnique.TabIndex = 15;
			this.AddPaintingTechnique.Text = "Добавить технику живописи";
			this.AddPaintingTechnique.UseVisualStyleBackColor = true;
			this.AddPaintingTechnique.Click += new System.EventHandler(this.AddPaintingTechnique_Click);
			// 
			// PaintingsList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1330, 553);
			this.Controls.Add(this.AddPaintingTechnique);
			this.Controls.Add(this.AddGenre);
			this.Controls.Add(this.AddArtist);
			this.Controls.Add(this.SearchTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ValuesComboBox);
			this.Controls.Add(this.PropertiesComboBox);
			this.Controls.Add(this.EditPainting);
			this.Controls.Add(this.Delete);
			this.Controls.Add(this.DeletePaintingsButton);
			this.Controls.Add(this.RefreshListButton);
			this.Controls.Add(this.AddPaintingButton);
			this.Controls.Add(this.paintingDataGridView);
			this.MinimumSize = new System.Drawing.Size(800, 400);
			this.Name = "PaintingsList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PaintingsList";
			this.Load += new System.EventHandler(this.PaintingsList_Load);
			((System.ComponentModel.ISupportInitialize)(this.paintingDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView paintingDataGridView;
		private System.Windows.Forms.Button AddPaintingButton;
		private System.Windows.Forms.Button RefreshListButton;
		private System.Windows.Forms.Button DeletePaintingsButton;
		private System.Windows.Forms.Button Delete;
		private System.Windows.Forms.Button EditPainting;
		private System.Windows.Forms.ComboBox PropertiesComboBox;
		private System.Windows.Forms.ComboBox ValuesComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox SearchTextBox;
		private System.Windows.Forms.Button AddArtist;
		private System.Windows.Forms.Button AddGenre;
		private System.Windows.Forms.Button AddPaintingTechnique;
	}
}