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
    enum Mode { Add, Edit }
    public partial class SaveExposition : Form
    {
        private Mode mode;
        private int expoID = 0;
        private List<Painting> expoPaintings;

        public SaveExposition()
        {
            InitializeComponent();
        }
    }
}
