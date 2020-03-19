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
                var availPaintings = from gg in gContext.Expositions
                                     where (gg.StartDate.CompareTo(startDate) < 0 && gg.EndDate.CompareTo(endDate) > 0)
                                     select gg.Paintings;
                paintingsDataGridView.DataSource = availPaintings.ToList();
            }
            paintingsDataGridView.DataSource = gContext.Paintings.ToList();
        }

        private void saveExpositionBtn_Click(object sender, EventArgs e)
        {            
            List<Painting> paintings = new List<Painting>();
            foreach (DataGridViewRow row in paintingsDataGridView.Rows)
            {
                if (row.Selected)
                {
                    var p = from wp in gContext.Paintings
                            where wp.Id == Convert.ToInt32(row.Cells[0])
                            select wp;
                    paintings.Add(p.First());
                }
            }

            Exposition exposition = new Exposition();
            exposition.Name = expoName.Text;
            exposition.StartDate = startDate.Value;
            exposition.EndDate = endDate.Value;
            exposition.Location = expoLocation.Text;
            exposition.Paintings = paintings;
            gContext.Expositions.Add(exposition);
            gContext.SaveChanges();
        }

    }
}
