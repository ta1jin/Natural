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
	public partial class PaintingsList : Form
	{
        GalleryContext gc = new GalleryContext();

        public string[] messages= { "Выбрать картины для удаления" ,"Отменить выбор" };
        
        public PaintingsList(string s)
		{

            InitializeComponent();
            RefreshList();
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Delete?";
            checkBoxColumn.Name = "Delete";
            checkBoxColumn.ValueType = typeof(bool);
            checkBoxColumn.Width = 60;
            paintingDataGridView.Columns.Add(checkBoxColumn);
            paintingDataGridView.Columns["Delete"].Visible = false;
            paintingDataGridView.Columns["Delete"].DisplayIndex = 0;
            switch (s)
            {
                case "Delete":
                    paintingDataGridView.Columns["Delete"].Visible = true;
                    Delete.Visible = true;
                    DeletePaintingsButton.Text = messages[1];
                    break;
                case "JustList":
                    paintingDataGridView.Columns["Delete"].Visible = false;
                    Delete.Visible = false;
                    break;
                default:
                    break;    
            }
			
           
        }

        public void RefreshList()
        {
            var paintings = from p in gc.Paintings
                            select p;
            DataTable dt = new DataTable();
           
            

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ArtistName", typeof(string));
            dt.Columns.Add("GenreName", typeof(string));
            dt.Columns.Add("PaintingTechniqueName", typeof(string));
            dt.Columns.Add("GalleryName", typeof(string));
            dt.Columns.Add("DateOfPainting", typeof(DateTime));
            dt.Columns.Add("Price", typeof(double));
            dt.Columns.Add("State", typeof(state));
            dt.Columns.Add("Status", typeof(status));
            foreach (Painting p in paintings)
            {
                var ArtistName = from a in gc.Artists
                                 where p.ArtistId == a.Id
                                 select (a.Surname + " " + a.Name + " " + a.Patronymic).ToString();

                var GenreName = from g in gc.Genres
                                where p.GenreId == g.Id
                                select g.Name.ToString();

                var PaintingTechniqueName = from pT in gc.PaintingTechniques
                                            where p.GenreId == pT.Id
                                            select pT.Name.ToString();
                var GalleryName = from g in gc.Gallerys
                                  where p.GenreId == g.Id
                                  select g.Title
                                  .ToString();
                string s = GenreName.First();
                DataRow drow;
                drow = dt.NewRow();
                drow["Id"] = p.Id;
                drow["Name"] = p.Name;
                drow["ArtistName"] = ArtistName.First();
                drow["GenreName"] = s;
                drow["PaintingTechniqueName"] = PaintingTechniqueName.First();
                drow["GalleryName"] = GalleryName.First();
                drow["DateOfPainting"] = p.DateOfPainting;
                drow["Price"] = p.Price;
                drow["State"] = p.State;
                drow["Status"] = p.Status;
                dt.Rows.Add(drow);
                
            }

            

            paintingDataGridView.DataSource = dt;
            paintingDataGridView.Refresh();

        }

      

        private void AddPainting_Click(object sender, EventArgs e)
        {
            AddPainting aP = new AddPainting();
            aP.Show();
            RefreshList();
        }

        private void RefreshListButton_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void DeletePaintingsButton_Click(object sender, EventArgs e)
        {

            Delete.Visible=paintingDataGridView.Columns["Delete"].Visible = paintingDataGridView.Columns["Delete"].Visible == true ? false : true;
            DeletePaintingsButton.Text = messages[Convert.ToInt32( paintingDataGridView.Columns["Delete"].Visible)];

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            List<int> IDs = new List<int>();
            foreach (DataGridViewRow dr in paintingDataGridView.Rows)
            {

                if (Convert.ToBoolean(dr.Cells["Delete"].Value))
                {
                    IDs.Add(Convert.ToInt32(dr.Cells["Id"].Value));
                }
            }
            foreach (int i in IDs)
            {
                Painting painting = gc.Paintings
                 .Where(p => p.Id == i)
                .FirstOrDefault();
                gc.Paintings.Remove(painting);
            }
            gc.SaveChanges();
            RefreshList();
        }
    }
}

