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
           /* Fill_Database fd = new Fill_Database();
            fd.fill();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPainting addPainting = new AddPainting();
            addPainting.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AddExposition addExposition = new AddExposition();
            //addExposition.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
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
            showUsers.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PaintingsList paintingsList = new PaintingsList("JustList");
            paintingsList.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PaintingsList paintingsList = new PaintingsList("Delete");
            paintingsList.Show();
            


        }

        private void button9_Click(object sender, EventArgs e)
        {
            SendToRestoration sendToRestoration = new SendToRestoration();
            sendToRestoration.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
        }
    }
}
