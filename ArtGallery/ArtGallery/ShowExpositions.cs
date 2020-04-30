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
    public partial class ShowExpositions : Form
    {
        GalleryContext gContext = new GalleryContext();
        public ShowExpositions()
        {
            InitializeComponent();
            expoGridView.DataSource = gContext.Expositions.ToList();
            expoGridView.Columns["Paintings"].Visible = false;
            expoGridView.Columns["GalleryId"].Visible = false;
            expoGridView.Columns["Gallery"].Visible = false;
        }

        private void addExpoBtn_Click(object sender, EventArgs e)
        {
            AddExposition addExposition = new AddExposition();
            addExposition.Show();
        }

        private void cancelExpoBtn_Click(object sender, EventArgs e)
        {
            using (GalleryContext galleryContext = new GalleryContext())
            {
                if (expoGridView.SelectedRows.Count > 0)
                {
                    int index = expoGridView.SelectedRows[0].Index;
                    int expo_id = 0;
                    bool converted = Int32.TryParse(expoGridView["Id", index].Value.ToString(), out expo_id);
                    if (converted == false)
                        return;
                    Exposition exposition = galleryContext.Expositions.Where(w => w.Id == expo_id).FirstOrDefault();

                    var ePain = galleryContext.Expositions.Where(expo => expo.Id == expo_id).Select(p => p.Paintings)
                        .ToList();

                    List<IEnumerable<Painting>> paintingsToChange = new List<IEnumerable<Painting>>();

                    for (int _i = 0; _i < ePain.Count; _i++)
                    {
                        for (int _j = 0; _j < ePain[_i].Count; _j++)
                        {
                            int pain_id = ePain[_i].ToList()[_j].Id;
                            paintingsToChange.Add(galleryContext.Paintings.Where(pain => pain.Id == pain_id)
                                .AsEnumerable()
                                .Select(pain =>
                                {
                                    pain.Status = status.NaSklade;
                                    return pain;
                                }));
                        }
                    }

                    for (int _i = 0; _i < paintingsToChange.Count; _i++)
                    {
                        foreach (Painting painting in paintingsToChange[_i])
                        {
                            galleryContext.Entry(painting).State = System.Data.Entity.EntityState.Modified;
                        }
                    }

                    galleryContext.Expositions.Remove(exposition);
                    galleryContext.SaveChanges();
                }
            }
        }

        private void showPaintingsBtn_Click(object sender, EventArgs e)
        {
            using (GalleryContext gc = new GalleryContext())
            {
                if (expoGridView.SelectedRows.Count == 1)
                {
                    int i = expoGridView.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(expoGridView["Id", i].Value.ToString(), out id);
                    if (converted == false)
                        return;
                    Exposition exposition = gc.Expositions.Where(w => w.Id == id).FirstOrDefault();
                    List<Painting> paintings = new List<Painting>();
                }
            }
        }
    }
}
