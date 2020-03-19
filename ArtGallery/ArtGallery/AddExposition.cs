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
        GalleryContext context = new GalleryContext();
        //DataSet ds = new DataSet();

        public AddExposition()
        {
            InitializeComponent();
        }

        IEnumerable<Painting> GetPaintingList(DateTime startDate, DateTime endDate)
        {
            var nonAvailPaintings = from gg in context.Expositions
                              where (gg.StartDate == startDate && gg.EndDate == endDate)
                              select gg.Paintings;

            var allPaintings = from a in context.Paintings
                   select a;

            return null;
        }

        private void confirmDateBtn_Click(object sender, EventArgs e)
        {
            paintingsDataGridView.DataSource = context.Paintings.ToList();
        }

        private void saveExpositionBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
