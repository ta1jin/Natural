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

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddExposition aE = new AddExposition();
            aE.Show();

        }

        private void глянутьКартиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintingsList pL = new PaintingsList("JustList");
            pL.Show();
            this.Close();
        }
    }
}
