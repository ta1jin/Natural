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
    public partial class ShowPaintingsMovement : Form
    {

        GalleryContext gc = new GalleryContext();
        public ShowPaintingsMovement()
        {
            InitializeComponent();
            RefreshList();

        }




        public void RefreshList()
        {
            var reports = from r in gc.Reports
                            select r;
            DataTable dt = new DataTable();



            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("ReportDate", typeof(DateTime));
            dt.Columns.Add("EmployeeId", typeof(string));
            dt.Columns.Add("PaintingId", typeof(string));
            //dt.Columns.Add("GalleryName", typeof(string));
            

            foreach (Report r in reports)
            {
                DataRow drow;
                drow = dt.NewRow();
                drow["Id"] = r.Id;
                drow["Title"] = r.Title;
                drow["Description"] = r.Description;
                drow["ReportDate"] = r.ReportDate;
                drow["EmployeeId"] = r.EmployeeId;
                drow["PaintingId"] = r.PaintingId;
                //drow["GalleryName"] = r.Gallery;
                dt.Rows.Add(drow);


            }



            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }

        private void ShowPaintingsMovement_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
