using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtGallery
{

    public partial class AddPainting : Form
    {
        GalleryContext gc = new GalleryContext();
        public bool IsEdit = false;
        public int PaintingId;
        public AddPainting(int id = -1)
        {
            InitializeComponent();
            DateOfPainting.Enabled = false;
            Fill_Database fd = new Fill_Database();
            //fd.fill();

            var artistNames = from a in gc.Artists
                              select (a.Surname + " " + a.Name + " " + a.Patronymic).ToString();
            var genresNames = from g in gc.Genres
                              select g.Name;
            var paintingTechniqueNames = from pT in gc.PaintingTechniques
                                         select pT.Name;

            artistsComboBox.Items.AddRange(artistNames.ToArray());
            genresComboBox.Items.AddRange(genresNames.ToArray());
            paintingTechniqueComboBox.Items.AddRange(paintingTechniqueNames.ToArray());
            string[] states = System.Enum.GetNames(typeof(state));
            stateComboBox.Items.AddRange(states);


            if (id >= 0)
            {
                this.Text = "Редактирование картины";
                IsEdit = true;
                PaintingId = id;
                Fill(id);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {

            if (Check())

            {


                var artist = from a in gc.Artists
                             where (a.Surname + " " + a.Name + " " + a.Patronymic).ToString() == artistsComboBox.SelectedItem.ToString()
                             select a;
                var genre = from g in gc.Genres
                            where g.Name == genresComboBox.SelectedItem.ToString()
                            select g;
                var paintingTechinque = from pT in gc.PaintingTechniques
                                        where pT.Name == paintingTechniqueComboBox.SelectedItem.ToString()
                                        select pT;
                var gallery = from g in gc.Gallerys
                              select g;

                if (IsEdit)
                {


                    var p = gc.Paintings.First(x => x.Id == PaintingId);
                    p.Name = paintingName.Text;
                    p.State = (state)stateComboBox.SelectedIndex;
                    p.Artist = artist.First();
                    p.Genre = genre.First();
                    p.PaintingTechnique = paintingTechinque.First();
                    p.DateOfPainting = DateOfPainting.Value;
                    p.Price = Convert.ToDouble(priceTextBox.Text);
                }

                else
                {
                    Painting painting = new Painting();
                    painting.Name = paintingName.Text;
                    painting.State = (state)stateComboBox.SelectedIndex;
                    painting.Artist = artist.First();
                    painting.Genre = genre.First();
                    painting.PaintingTechnique = paintingTechinque.First();
                    painting.DateOfPainting = DateOfPainting.Value;
                    painting.Price = Convert.ToDouble(priceTextBox.Text);
                    painting.Status = status.NaSklade;
                    painting.Gallery = gallery.First();
                    gc.Paintings.Add(painting);
                }


                gc.SaveChanges();
                this.Close();
            }

        }

        private void AddPainting_Load(object sender, EventArgs e)
        {


        }

        private void глянутьСписокКартинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingsList paintingsList = new PaintingsList();
            paintingsList.type = "JustList";
            paintingsList.Show();
            Hide();
        }

        public void Fill(int id)
        {
            var painting = from p in gc.Paintings
                           where p.Id == id
                           select p;
            Painting paint = painting.First();
            paintingName.Text = paint.Name;
            stateComboBox.Text = paint.State.ToString();
            artistsComboBox.Text = (paint.Artist.Surname + " " + paint.Artist.Name + " " + paint.Artist.Patronymic).ToString(); ;
            genresComboBox.Text = paint.Genre.Name.ToString();
            paintingTechniqueComboBox.Text = paint.PaintingTechnique.Name.ToString();
            DateOfPainting.Value = paint.DateOfPainting;
            priceTextBox.Text = paint.Price.ToString();


        }

        private void DateOfPainting_ValueChanged(object sender, EventArgs e)
        {
            Artist artist = gc.Artists.First(art => (art.Surname + " " + art.Name + " " + art.Patronymic) == artistsComboBox.Text);
            if (DateOfPainting.Value > artist.DateOfDeath || DateOfPainting.Value < artist.Birthday)
            {
                MessageBox.Show("Неверная дата:\nДата рождения художника - " + artist.Birthday.ToShortDateString() + " \nДата смерти художника - " + artist.DateOfDeath.ToShortDateString() + "", "Ошибка");
            }

        }

        private void artistsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateOfPainting.Enabled = true;
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
                Artist artist = gc.Artists.First(art => (art.Surname + " " + art.Name + " " + art.Patronymic) == artistsComboBox.Text);
                if (DateOfPainting.Value > artist.DateOfDeath || DateOfPainting.Value < artist.Birthday)
                {
                    MessageBox.Show("Неверная дата:\nДата рождения художника - " + artist.Birthday.ToShortDateString() + " \nДата смерти художника - " + artist.DateOfDeath.ToShortDateString() + "", "Ошибка");
                    f = false;
                }
            }

            return f && f2;


        }




    }
}
