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
    public partial class ShowReports : Form
    {
        GalleryContext gc = new GalleryContext();
        public ShowReports()
        {
            InitializeComponent();
            RefreshList();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void RefreshList()
        {
            var reports = from p in gc.Reports
                            select p;
            DataTable dt = new DataTable();



            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("ReportDate", typeof(DateTime));
            dt.Columns.Add("EmployeeId", typeof(int));
            //TODO
            //PaintingId
            dt.Columns.Add("GalleryName", typeof(Gallery));


            foreach (Report r in reports)
            {
                var GalleryName = from g in gc.Gallerys
                                  where r.GalleryId == g.Id
                                  select g.Title
                                  .ToString();
                DataRow drow;
                drow = dt.NewRow();
                drow["Id"] = r.Id;
                drow["Title"] = r.Title;
                drow["Description"] = r.Description;
                drow["ReportDate"] = r.ReportDate;
                drow["EmployeeId"] = r.EmployeeId;
                //TODO
                //PaintingId
                drow["GalleryName"] = GalleryName.First();
               
                dt.Rows.Add(drow);


            }



            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }
    }
}
