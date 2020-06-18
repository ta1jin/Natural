using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtGallery.Forms
{
	public partial class AddGenre : Form
    {
        public GalleryContext gc = new GalleryContext();
        public AddGenre()
		{
			InitializeComponent();
		}

        private void addButton_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                Genre genre = new Genre
                {
                    Name = nameTextBox.Text,
                    Description = descriptionRichTextBox.Text
                };

                gc.Genres.Add(genre);
                gc.SaveChanges();

                MessageBox.Show("Жанр " + nameTextBox.Text + " успешно добавлен", "OK");
                this.Close();

            }
        }




        public bool Check()
        {
            bool f = true;       


            foreach (Control c in this.Controls)
            {
                if (!c.GetType().ToString().Contains("label") && !c.GetType().ToString().Contains("button"))
                {
                    if (c.Text.Length > 0)
                    { }
                    else
                    {
                        f = false;
                    }
                }


            }
            if (!f) MessageBox.Show("Заполните все поля", "Ошибка");
            return f;


        }

        private void descriptionRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
