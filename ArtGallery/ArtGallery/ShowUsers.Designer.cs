namespace ArtGallery
{
    partial class ShowUsers
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
            this.usersData = new System.Windows.Forms.DataGridView();
            this.addUser = new System.Windows.Forms.Button();
            this.editUser = new System.Windows.Forms.Button();
            this.deleteUser = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersData)).BeginInit();
            this.SuspendLayout();
            // 
            // usersData
            // 
            this.usersData.AllowUserToAddRows = false;
            this.usersData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.usersData.Location = new System.Drawing.Point(12, 71);
            this.usersData.Name = "usersData";
            this.usersData.RowHeadersWidth = 51;
            this.usersData.RowTemplate.Height = 24;
            this.usersData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersData.Size = new System.Drawing.Size(776, 367);
            this.usersData.TabIndex = 0;
            this.usersData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.usersData_CellContentClick);
            // 
            // addUser
            // 
            this.addUser.Location = new System.Drawing.Point(12, 12);
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(200, 53);
            this.addUser.TabIndex = 1;
            this.addUser.Text = "Добавить Пользователя";
            this.addUser.UseVisualStyleBackColor = true;
            this.addUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // editUser
            // 
            this.editUser.Location = new System.Drawing.Point(218, 12);
            this.editUser.Name = "editUser";
            this.editUser.Size = new System.Drawing.Size(200, 53);
            this.editUser.TabIndex = 2;
            this.editUser.Text = "Редактировать пользователя";
            this.editUser.UseVisualStyleBackColor = true;
            this.editUser.Click += new System.EventHandler(this.editUser_Click);
            // 
            // deleteUser
            // 
            this.deleteUser.Location = new System.Drawing.Point(424, 12);
            this.deleteUser.Name = "deleteUser";
            this.deleteUser.Size = new System.Drawing.Size(200, 53);
            this.deleteUser.TabIndex = 3;
            this.deleteUser.Text = "Удалить пользователя";
            this.deleteUser.UseVisualStyleBackColor = true;
            this.deleteUser.Click += new System.EventHandler(this.deleteUser_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(713, 29);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(37, 36);
            this.update.TabIndex = 4;
            this.update.Text = "⟳";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // ShowUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.update);
            this.Controls.Add(this.deleteUser);
            this.Controls.Add(this.editUser);
            this.Controls.Add(this.addUser);
            this.Controls.Add(this.usersData);
            this.Name = "ShowUsers";
            this.Text = "ShowUsers";
            ((System.ComponentModel.ISupportInitialize)(this.usersData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView usersData;
        private System.Windows.Forms.Button addUser;
        private System.Windows.Forms.Button editUser;
        private System.Windows.Forms.Button deleteUser;
        private System.Windows.Forms.Button update;
    }
}