namespace ArtGallery.Forms
{
	partial class AddArtist
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
			this.birthdayMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.patronimycTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.surnameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.dayOfDeathMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.addButton = new System.Windows.Forms.Button();
			this.label = new System.Windows.Forms.Label();
			this.biographyRichTextBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// birthdayMaskedTextBox
			// 
			this.birthdayMaskedTextBox.Location = new System.Drawing.Point(148, 85);
			this.birthdayMaskedTextBox.Mask = "00/00/0000";
			this.birthdayMaskedTextBox.Name = "birthdayMaskedTextBox";
			this.birthdayMaskedTextBox.Size = new System.Drawing.Size(215, 20);
			this.birthdayMaskedTextBox.TabIndex = 63;
			this.birthdayMaskedTextBox.ValidatingType = typeof(System.DateTime);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 13);
			this.label4.TabIndex = 62;
			this.label4.Text = "Дата рождения:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 60;
			this.label3.Text = "Отчество:";
			// 
			// patronimycTextBox
			// 
			this.patronimycTextBox.Location = new System.Drawing.Point(148, 58);
			this.patronimycTextBox.MaxLength = 15;
			this.patronimycTextBox.Name = "patronimycTextBox";
			this.patronimycTextBox.Size = new System.Drawing.Size(215, 20);
			this.patronimycTextBox.TabIndex = 61;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 56;
			this.label2.Text = "Фамилия:";
			// 
			// surnameTextBox
			// 
			this.surnameTextBox.Location = new System.Drawing.Point(148, 6);
			this.surnameTextBox.MaxLength = 15;
			this.surnameTextBox.Name = "surnameTextBox";
			this.surnameTextBox.Size = new System.Drawing.Size(215, 20);
			this.surnameTextBox.TabIndex = 58;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 57;
			this.label1.Text = "Имя:";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(148, 32);
			this.nameTextBox.MaxLength = 15;
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(215, 20);
			this.nameTextBox.TabIndex = 59;
			// 
			// dayOfDeathMaskedTextBox
			// 
			this.dayOfDeathMaskedTextBox.Location = new System.Drawing.Point(148, 111);
			this.dayOfDeathMaskedTextBox.Mask = "00/00/0000";
			this.dayOfDeathMaskedTextBox.Name = "dayOfDeathMaskedTextBox";
			this.dayOfDeathMaskedTextBox.Size = new System.Drawing.Size(215, 20);
			this.dayOfDeathMaskedTextBox.TabIndex = 65;
			this.dayOfDeathMaskedTextBox.ValidatingType = typeof(System.DateTime);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 113);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 13);
			this.label5.TabIndex = 64;
			this.label5.Text = "Дата смерти:";
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(148, 242);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(75, 23);
			this.addButton.TabIndex = 66;
			this.addButton.Text = "Добавить";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// label
			// 
			this.label.AutoSize = true;
			this.label.Location = new System.Drawing.Point(12, 140);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(63, 13);
			this.label.TabIndex = 68;
			this.label.Text = "Биография";
			// 
			// biographyRichTextBox
			// 
			this.biographyRichTextBox.Location = new System.Drawing.Point(148, 140);
			this.biographyRichTextBox.Name = "biographyRichTextBox";
			this.biographyRichTextBox.Size = new System.Drawing.Size(215, 96);
			this.biographyRichTextBox.TabIndex = 69;
			this.biographyRichTextBox.Text = "";
			// 
			// AddArtist
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(375, 322);
			this.Controls.Add(this.biographyRichTextBox);
			this.Controls.Add(this.label);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.dayOfDeathMaskedTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.birthdayMaskedTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.patronimycTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.surnameTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nameTextBox);
			this.Name = "AddArtist";
			this.Text = "AddArtist";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MaskedTextBox birthdayMaskedTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox patronimycTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox surnameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.MaskedTextBox dayOfDeathMaskedTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.RichTextBox biographyRichTextBox;
	}
}