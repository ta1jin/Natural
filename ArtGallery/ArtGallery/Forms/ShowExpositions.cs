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
    public partial class ShowExpositions : Form
    {
        private GalleryContext galleryContext;
        public ShowExpositions()
        {
            InitializeComponent();
        }

        private void ShowExpositions_Load(object sender, EventArgs e)
        {
            galleryContext = new GalleryContext();
            refreshList();
        }

        private void refreshList()
        {
            //
            //StatusChecker.CheckExpositionsForStatus();
            //
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            DataTable dataTable = new DataTable();
            dataTable.Reset();

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Status", typeof(ExpositionStatus));
            dataTable.Columns.Add("Start date", typeof(DateTime));
            dataTable.Columns.Add("End date", typeof(DateTime));
            dataTable.Columns.Add("Showroom", typeof(string));
            dataTable.Columns.Add("Gallery", typeof(string));

            if (galleryContext.Expositions.Any())
            {
                List<Exposition> expositions = null;

                if (expositions == null)
                {
                    expositions = galleryContext.Expositions.ToList();
                }

                foreach (Exposition expo in expositions)
                {
                    var Showroom = galleryContext.Showrooms.Find(expo.ShowroomId);
                    var Gallery = galleryContext.Gallerys.Find(expo.GalleryId);

                    DataRow dataRow;
                    dataRow = dataTable.NewRow();
                    dataRow["Id"] = expo.Id;
                    dataRow["Title"] = expo.Name;
                    dataRow["Status"] = expo.Status;
                    dataRow["Start date"] = expo.StartDate;
                    dataRow["End date"] = expo.EndDate;
                    dataRow["Showroom"] = Showroom.Title;
                    dataRow["Gallery"] = Gallery.Title;

                    dataTable.Rows.Add(dataRow);
                }
            }

            expoGridView.Refresh();
            expoGridView.DataSource = dataTable;
            expoGridView.Columns["Id"].Visible = false;
        }

        private void addExpoBtn_Click(object sender, EventArgs e)
        {
            SaveExposition saveExposition = new SaveExposition();
            saveExposition.galleryContext = galleryContext;
            saveExposition.ShowDialog();
            refreshList();
        }

        private void cancelExpoBtn_Click(object sender, EventArgs e)
        {
            if (expoGridView.SelectedRows.Count > 0)
            {
                int expo_id = int.Parse(expoGridView["Id", expoGridView.SelectedRows[0].Index].Value.ToString());
                Exposition exposition = galleryContext.Expositions.Find(expo_id);

                exposition.Status = ExpositionStatus.Cancelled;

                galleryContext.SaveChanges();
                //
                //StatusChecker.CheckPaintingsForStatus();
                //
            }
        }

        private void showPaintingsBtn_Click(object sender, EventArgs e)
        {
            using (GalleryContext galleryContext = new GalleryContext())
            {
                /* 
                1.
                   if (expoGridView.SelectedRows.Count > 0)
                   {
                     int expo_id = int.Parse(expoGridView["Id", expoGridView.SelectedRows[0].Index].Value.ToString());
                     Exposition exposition = galleryContext.Expositions.Find(expo_id);

                     PaintingsList showPaintings = new PaintingsList(exposition, galleryContext);
                     showPaintings.Show();
                   }
                
                2.
                   if (expoGridView.SelectedRows.Count > 0)
                   {
                     int expo_id = int.Parse(expoGridView["Id", expoGridView.SelectedRows[0].Index].Value.ToString());
                     Exposition exposition = galleryContext.Expositions.Find(expo_id);

                     galleryContext.Entry(exposition).Collection(expo => expo.Paintings).Load();
                     List<Painting> paintings = exposition.Paintings.ToList();

                     PaintingsList showPaintings = new PaintingsList(paintings);
                     showPaintings.Show();
                   }
                
                 */
                if (expoGridView.SelectedRows.Count > 0)
                {
                    int expo_id = int.Parse(expoGridView["Id", expoGridView.SelectedRows[0].Index].Value.ToString());

                    List<Painting> lp = new List<Painting>();
                    Exposition exposition = galleryContext.Expositions.Where(ex => ex.Id == expo_id).FirstOrDefault();
                    var list = galleryContext.Expositions.Where(expo => expo.Id == expo_id).Select(expo => expo.Paintings).ToList();

                    for (int i = 0; i < list.Count; i++)
                    {
                        for (int j = 0; j < list[i].Count; j++)
                        {
                            lp.Add(list[i].ToList()[j]);
                            //   MessageBox.Show(lp[j].Name.ToString());
                        }
                    }


                    PaintingsList showPaintings = new PaintingsList(lp);
                    showPaintings.Show();

                }

            }
        }

        private void editExpoBtn_Click(object sender, EventArgs e)
        {
            if (expoGridView.SelectedRows.Count > 0)
            {
                int expo_id = int.Parse(expoGridView["Id", expoGridView.SelectedRows[0].Index].Value.ToString());
                Exposition exposition = galleryContext.Expositions.Find(expo_id);

                if (exposition.Status != ExpositionStatus.Cancelled)
                {
                    SaveExposition saveExposition = new SaveExposition();
                    saveExposition.galleryContext = galleryContext;
                    saveExposition.exposition = exposition;
                    saveExposition.ShowDialog();
                    refreshList();
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
