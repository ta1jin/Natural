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

        IEnumerable<Painting> GetPaintingList()
        {
            GalleryContext context = new GalleryContext();

            return context.Paintings.AsEnumerable();
        }

        private void confirmDateBtn_Click(object sender, EventArgs e)
        {
            //painting = GetPaintingList();
        }

        private void saveExpositionBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
