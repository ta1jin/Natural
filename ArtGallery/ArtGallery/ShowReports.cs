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
        string DescriptionColumnName = "Description";
        string TitleColumnName = "Title"; 
        public ShowReports()
        {
            InitializeComponent();
            RefreshList();

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Посмотреть содержимое отчета подробнее";
            checkBoxColumn.Name = "CheckReport";
            checkBoxColumn.ValueType = typeof(bool);
            checkBoxColumn.Width = 100;
            dataGridView1.Columns.Add(checkBoxColumn);
            dataGridView1.Columns["CheckReport"].DisplayIndex = 0;
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
                drow[TitleColumnName] = r.Title;
                drow[DescriptionColumnName] = r.Description;
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = 0;
            if (e.ColumnIndex == columnIndex)
            {
                bool isChecked = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (isChecked)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells[columnIndex].Value = !isChecked;
                        }
                        else
                        {
                            for (int i = 0;i< dataGridView1.Columns.Count; i++)
                            {
                                if (dataGridView1.Columns[i].Name == DescriptionColumnName)
                                {
                                    DescriptionTextBox.Text = row.Cells[i].Value.ToString();
                                }
                                else if (dataGridView1.Columns[i].Name == TitleColumnName)
                                {
                                    textBox1.Text = row.Cells[i].Value.ToString();
                                }
                            }
                            
                            
                        }
                    }
                }
            }

            
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
