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
	public partial class AddPaintingTechnique : Form
	{
		public GalleryContext gc = new GalleryContext();
		public AddPaintingTechnique()
		{
			InitializeComponent();
		}

        private void addButton_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                PaintingTechnique pT = new PaintingTechnique
                {
                    Name = nameTextBox.Text,
                    Description = descriptionRichTextBox.Text
                };

                gc.PaintingTechniques.Add(pT);
                gc.SaveChanges();

                MessageBox.Show("Техника живописи " + nameTextBox.Text + " успешно добавлена", "OK");
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
    }
}
