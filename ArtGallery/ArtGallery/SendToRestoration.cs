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
    public partial class SendToRestoration : Form
    {
        GalleryContext gc = new GalleryContext();

        public SendToRestoration()
        {
            InitializeComponent();
            RefreshList();

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Нуждается в реставрации?";
            checkBoxColumn.Name = "SendToRestoration";
            checkBoxColumn.ValueType = typeof(bool);
            checkBoxColumn.Width = 100;
            dataGridView1.Columns.Add(checkBoxColumn);
            dataGridView1.Columns["SendToRestoration"].DisplayIndex = 0;



        }



        public void RefreshList()
        {
            var paintings = from p in gc.Paintings
                            select p;
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();



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


            dt2.Columns.Add("Id", typeof(int));
            dt2.Columns.Add("Name", typeof(string));
            dt2.Columns.Add("ArtistName", typeof(string));
            dt2.Columns.Add("GenreName", typeof(string));
            dt2.Columns.Add("PaintingTechniqueName", typeof(string));
            dt2.Columns.Add("GalleryName", typeof(string));
            dt2.Columns.Add("DateOfPainting", typeof(DateTime));
            dt2.Columns.Add("Price", typeof(double));
            dt2.Columns.Add("State", typeof(state));
            dt2.Columns.Add("Status", typeof(status));
            foreach (Painting p in paintings)
            {
                // Status: NaRestavracii == 0 NaExposicii == 1 NaSklade == 2
                // State: Otlichnoe == 0 TrebuetRestavracii == 1 Util == 2 
                if (p.Status == status.NaSklade)
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

                if (p.State == state.TrebuetRestavracii)
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
                    drow = dt2.NewRow();
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
                    dt2.Rows.Add(drow);
                }
            }



            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt2;
            dataGridView1.Refresh();
            dataGridView2.Refresh();

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> IDs = new List<int>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["SendToRestoration"].Value))
                {
                    IDs.Add(Convert.ToInt32(dr.Cells["Id"].Value));
                }
            }
            foreach (int i in IDs)
            {
                var painting = gc.Paintings.Where(p => p.Id == i).FirstOrDefault();
                // NaRestavracii == 0 NaExposicii == 1 NaSklade == 2
                if (painting != null)
                {
                    painting.State = state.TrebuetRestavracii;
                    gc.SaveChanges();
                    //ShowExpositions.AddMovement
                }

            }
            
            RefreshList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> IDs = new List<int>();
            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                IDs.Add(Convert.ToInt32(dr.Cells["Id"].Value));
            }
            foreach (int i in IDs)
            {
                var painting = gc.Paintings.Where(p => p.Id == i).FirstOrDefault();
                // NaRestavracii == 0 NaExposicii == 1 NaSklade == 2
                if (painting != null)
                {
                    painting.Status = status.NaRestavracii;
                    gc.SaveChanges();
                    //ShowExpositions.AddMovement
                    
                }

            }

            RefreshList();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
