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
            if (gContext.Expositions.Any())
            {
                var nonAvailPaintings = from gg in gContext.Expositions
                                        where (gg.StartDate.CompareTo(startDate.Value) > 0 && gg.EndDate.CompareTo(endDate.Value) < 0)
                                     select gg.Paintings;
                paintingsDataGridView.DataSource = nonAvailPaintings.ToList();
            }
            else paintingsDataGridView.DataSource = gContext.Paintings.ToList();
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
    }
}
