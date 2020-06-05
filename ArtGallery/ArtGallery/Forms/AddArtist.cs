using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ArtGallery.Forms
{
	public partial class AddArtist : Form
	{
        public GalleryContext gc = new GalleryContext();
        public AddArtist()
		{
			InitializeComponent();
		}

		private void addButton_Click(object sender, EventArgs e)
		{
            
            if (Check())
            {
                CultureInfo culture = new CultureInfo("ru-RU");
                Artist artist = new Artist
                {
                    Name = nameTextBox.Text,
                    Surname = surnameTextBox.Text,
                    Patronymic = patronimycTextBox.Text,
                    Birthday = Convert.ToDateTime(birthdayMaskedTextBox.Text, culture),
                    DateOfDeath = Convert.ToDateTime(dayOfDeathMaskedTextBox.Text, culture),
                    Biography = biographyRichTextBox.Text
                };

                gc.Artists.Add(artist);
                gc.SaveChanges();
            
            }
            MessageBox.Show("Художник " + surnameTextBox.Text+" "+nameTextBox.Text+" "+patronimycTextBox.Text + " успешно добавлен", "OK");
            this.Close();
		}

        public bool Check()
        {
            bool f = true;
            bool f2 = true;


            foreach (Control c in this.Controls)
            {
                if (!c.GetType().ToString().Contains("label") && !c.GetType().ToString().Contains("button"))
                {
                    if (c.Text.Length > 0)
                    { }
                    else
                    {
                        f2 = false;
                    }
                }


            }
            if (!f2) MessageBox.Show("Заполните все поля", "Ошибка");

            else
            {
                CultureInfo culture = new CultureInfo("ru-RU");
                DateTime Birthday = Convert.ToDateTime(birthdayMaskedTextBox.Text, culture);
                DateTime DayOfDeath = Convert.ToDateTime(dayOfDeathMaskedTextBox.Text, culture);
               
                if (DayOfDeath<Birthday)
                {
                    MessageBox.Show("Неверная дата: Дата рождения позже даты смерти...", "Ошибка");
                    f = false;
                }
            }

            return f && f2;


        }
    }
}
