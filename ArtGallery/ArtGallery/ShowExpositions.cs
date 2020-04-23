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
            using (GalleryContext gc = new GalleryContext())
            {
                if (expoGridView.SelectedRows.Count > 0)
                {
                    int i = expoGridView.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(expoGridView["Id", i].Value.ToString(), out id);
                    if (converted == false)
                        return;
                    Exposition exposition = gc.Expositions.Where(w => w.Id == id).FirstOrDefault();

                    //gContext.Paintings.Where(pain => pain.Exposition_id == id).AsEnumerable().Select(pain =>
                    //{
                    //    pain.Exposition_id = null;
                    //    return pain;
                    //});

                    gc.Expositions.Remove(exposition);
                    gc.SaveChanges();
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
