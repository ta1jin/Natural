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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPainting addPainting = new AddPainting();
            addPainting.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddExposition addExposition = new AddExposition();
            addExposition.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddUsers addUsers = new AddUsers();
            addUsers.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddReport addReport = new AddReport();
            addReport.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowExpositions showExpositions = new ShowExpositions();
            showExpositions.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowUsers showUsers = new ShowUsers();
            showUsers.Show();
        }
    }
}
