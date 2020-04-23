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
        public AddExposition()
        {
            InitializeComponent();
        }

        private void confirmDateBtn_Click(object sender, EventArgs e)
        {
            using (GalleryContext gContext = new GalleryContext())
            {
                var allPaintings = gContext.Paintings.ToList();
                if (gContext.Expositions.Any())
                {
                    var nap = gContext.Expositions.Where(expo =>
                    (startDate.Value.CompareTo(expo.StartDate) > 0 && startDate.Value.CompareTo(expo.EndDate) < 0) ||
                    (endDate.Value.CompareTo(expo.StartDate) > 0 && endDate.Value.CompareTo(expo.EndDate) < 0))
                        .Select(p => p.Paintings)
                        .ToList();

                    List<Painting> nonAvailPaintings = new List<Painting>();
                    for (int _i = 0; _i < nap.Count; _i++)
                    {
                        for (int _j = 0; _j < nap[_i].Count; _j++)
                        {
                            nonAvailPaintings.Add(nap[_i].ToList()[_j]);
                        }
                    }

                    List<Painting> availPaintings = new List<Painting>();
                    for (int _i = 0; _i < allPaintings.Count; _i++)
                    {
                        int _k = 0;
                        for (int _j = 0; _j < nonAvailPaintings.Count; _j++)
                        {
                            if (allPaintings[_i].Id == nonAvailPaintings[_j].Id) _k = 1;
                        }
                        if (_k == 0) availPaintings.Add(allPaintings[_i]);
                    }

                    paintingsDataGridView.DataSource = availPaintings;
                }
                else paintingsDataGridView.DataSource = allPaintings;

                paintingsDataGridView.Columns["ArtistId"].Visible = false;
                paintingsDataGridView.Columns["GenreId"].Visible = false;
                paintingsDataGridView.Columns["PaintingTehniqueId"].Visible = false;
                paintingsDataGridView.Columns["GalleryId"].Visible = false;
                paintingsDataGridView.Columns["Gallery"].Visible = false;
                paintingsDataGridView.Columns["Reports"].Visible = false;
            }
        }

        private void saveExpositionBtn_Click(object sender, EventArgs e)
        {
            using (GalleryContext gContext = new GalleryContext())
            {
                if (paintingsDataGridView.SelectedRows.Count > 0)
                {
                    List<Painting> paintings = new List<Painting>();
                    List<IEnumerable<Painting>> p = new List<IEnumerable<Painting>>();

                    foreach (DataGridViewRow row in paintingsDataGridView.SelectedRows)
                    {
                        int id = int.Parse(row.Cells[0].Value.ToString());
                        paintings.Add(gContext.Paintings.Where(pain => pain.Id == id).SingleOrDefault());

                        p.Add(gContext.Paintings.Where(pain => pain.Id == id).AsEnumerable().Select(pain =>
                        {
                            pain.Status = status.NaExposicii;
                            return pain;
                        }));
                    }

                    for (int _i = 0; _i < p.Count; _i++)
                    {
                        foreach (Painting painting in p[_i])
                        {
                            gContext.Entry(painting).State = System.Data.Entity.EntityState.Modified;
                        }
                    }

                    var gallery = from g in gContext.Gallerys select g;

                    Exposition exposition = new Exposition();
                    exposition.Name = expoName.Text;
                    exposition.StartDate = startDate.Value;
                    exposition.EndDate = endDate.Value;
                    exposition.Location = expoLocation.Text;
                    exposition.Paintings = paintings;
                    exposition.Gallery = gallery.First();
                    gContext.Expositions.Add(exposition);
                    gContext.SaveChanges();
                }

                Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
