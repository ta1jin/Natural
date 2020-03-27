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
    public partial class AddExposition : Form
    {
        GalleryContext gContext = new GalleryContext();

        public AddExposition()
        {
            InitializeComponent();
        }

        private void confirmDateBtn_Click(object sender, EventArgs e)
        {
            var allp = gContext.Paintings.ToList();
            if (gContext.Expositions.Any())
            {
                var nonavailp = gContext.Expositions.Where(gg =>
                (startDate.Value.CompareTo(gg.StartDate) > 0 || startDate.Value.CompareTo(gg.EndDate) < 0) &&
                (endDate.Value.CompareTo(gg.StartDate) > 0 || endDate.Value.CompareTo(gg.EndDate) < 0))
                    .Select(p => p.Paintings).ToList();

                List<Painting> nap = new List<Painting>();
                for (int _i = 0; _i < nonavailp.Count; _i++)
                {
                    for (int _j = 0; _j < nonavailp[_i].Count; _j++)
                    {
                        nap.Add(nonavailp[_i].ToList()[_j]);
                    }
                }

                List<Painting> ap = new List<Painting>(); 
                for (int _i = 0; _i < allp.Count; _i++)
                {
                    int _k = 0;
                    for (int _j = 0; _j < nap.Count; _j++)
                    {
                        if (allp[_i].Id == nap[_j].Id) _k = 1;
                    }
                    if (_k == 0) ap.Add(allp[_i]);
                }

                paintingsDataGridView.DataSource = ap;

            }
            else paintingsDataGridView.DataSource = allp;

            //paintingsDataGridView.Columns["ArtistId"].Visible = false;
            //paintingsDataGridView.Columns["GenreId"].Visible = false;
            //paintingsDataGridView.Columns["PaintingTehniqueId"].Visible = false;
            //paintingsDataGridView.Columns["GalleryId"].Visible = false;
            //paintingsDataGridView.Columns["Gallery"].Visible = false;
            //paintingsDataGridView.Columns["Reports"].Visible = false;
        }

        private void saveExpositionBtn_Click(object sender, EventArgs e)
        {
            List<Painting> paintings = new List<Painting>();
            foreach (DataGridViewRow row in paintingsDataGridView.Rows)
            {
                if (row.Selected)
                {
                    int i = (int.Parse(row.Cells[0].Value.ToString()));
                    var p = from wp in gContext.Paintings
                            where wp.Id == i
                            select wp;
                    paintings.Add(p.SingleOrDefault());
                }
            }

            var gallery = from g in gContext.Gallerys
                          select g;

            Exposition exposition = new Exposition();
            exposition.Name = expoName.Text;
            exposition.StartDate = startDate.Value;
            exposition.EndDate = endDate.Value;
            exposition.Location = expoLocation.Text;
            exposition.Paintings = paintings;
            exposition.Gallery = gallery.First();
            gContext.Expositions.Add(exposition);
            gContext.SaveChanges();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
