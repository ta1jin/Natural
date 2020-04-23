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
    public partial class AddReport : Form
    {

        GalleryContext gc = new GalleryContext();
        public AddReport()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void paintingName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TitleTextBox.Text != "")
            {
                var gallery = from g in gc.Gallerys
                              select g;

                Report report = new Report();
                // Title Description ReportDate EmployeeId Employee PaintingId Paintings GalleryId Gallery
                report.Title = TitleTextBox.Text;
                report.Description = DescriptionTextBox.Text;
                report.ReportDate = DateTime.Now;
                //report.EmployeeId
                //report.Employee
                //report.GalleryId
                //report.PaintingId
                //report.Paintings
                report.Gallery = gallery.First();


                gc.Reports.Add(report);
                gc.SaveChanges();

                //поменять на сплывающее окно позже или оставить так?
                TitleTextBox.Text = "Ваш отчет успешно отправлен!";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
