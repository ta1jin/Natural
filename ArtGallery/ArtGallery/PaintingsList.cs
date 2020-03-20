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
       
        
        
        public PaintingsList()
		{
			InitializeComponent();
            RefreshList();

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

        private void глянутьЭкспозицииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowExpositions sE = new ShowExpositions();
            sE.Show();
            Hide();
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
    }
}

