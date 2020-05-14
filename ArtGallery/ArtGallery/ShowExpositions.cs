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
        public ShowExpositions()
        {
            InitializeComponent();
            refreshList();
        }

        private void refreshList()
        {
            using (GalleryContext galleryContext = new GalleryContext())
            {
                DataTable dataTable = new DataTable();
                dataTable.Reset();

                if (galleryContext.Expositions.Any())
                {
                    List<Exposition> expositions = null;


                    dataTable.Columns.Add("Id", typeof(int));
                    dataTable.Columns.Add("Title", typeof(string));
                    dataTable.Columns.Add("Start date", typeof(DateTime));
                    dataTable.Columns.Add("End date", typeof(DateTime));
                    dataTable.Columns.Add("Showroom", typeof(string));
                    dataTable.Columns.Add("GalleryName", typeof(string));

                    if (expositions == null)
                    {
                        var expos = from exp in galleryContext.Expositions
                                    select exp;
                        expositions = expos.ToList();
                    }
                    foreach (Exposition expo in expositions)
                    {
                        var GalleryName = from g in galleryContext.Gallerys
                                          where expo.GalleryId == g.Id
                                          select g.Title.ToString();
                        DataRow dataRow;
                        dataRow = dataTable.NewRow();
                        dataRow["Id"] = expo.Id;
                        dataRow["Title"] = expo.Name;
                        dataRow["Start date"] = expo.StartDate;
                        dataRow["End date"] = expo.EndDate;
                        dataRow["Showroom"] = expo.Location;
                        dataRow["GalleryName"] = GalleryName.First();
                        dataTable.Rows.Add(dataRow);
                    }
                    expoGridView.Refresh();
                    expoGridView.DataSource = dataTable;
                    expoGridView.Columns["Id"].Visible = false;
                }
                else
                {
                    expoGridView.Refresh();
                    expoGridView.DataSource = dataTable;
                }
            }
        }

        private void addExpoBtn_Click(object sender, EventArgs e)
        {
            SaveExposition saveExposition = new SaveExposition();
            saveExposition.Show();
        }

        private void cancelExpoBtn_Click(object sender, EventArgs e)
        {
            using (GalleryContext galleryContext = new GalleryContext())
            {
                if (expoGridView.SelectedRows.Count > 0)
                {
                    int expo_id = int.Parse(expoGridView["Id", expoGridView.SelectedRows[0].Index].Value.ToString());
                    Exposition exposition = galleryContext.Expositions.Find(expo_id);

                    //var ePain = galleryContext.Expositions.Where(expo => expo.Id == expo_id).Select(p => p.Paintings)
                    //    .ToList();

                    //List<IEnumerable<Painting>> paintingsToChange = new List<IEnumerable<Painting>>();

                    //for (int _i = 0; _i < ePain.Count; _i++)
                    //{
                    //    for (int _j = 0; _j < ePain[_i].Count; _j++)
                    //    {
                    //        int pain_id = ePain[_i].ToList()[_j].Id;
                    //        paintingsToChange.Add(galleryContext.Paintings.Where(pain => pain.Id == pain_id)
                    //            .AsEnumerable()
                    //            .Select(pain =>
                    //            {
                    //                pain.Status = status.NaSklade;
                    //                return pain;
                    //            }));
                    //    }
                    //}

                    //for (int _i = 0; _i < paintingsToChange.Count; _i++)
                    //{
                    //    foreach (Painting painting in paintingsToChange[_i])
                    //    {
                    //        galleryContext.Entry(painting).State = System.Data.Entity.EntityState.Modified;
                    //    }
                    //}

                    galleryContext.Expositions.Remove(exposition);
                    galleryContext.SaveChanges();
                }
            }
        }

        private void showPaintingsBtn_Click(object sender, EventArgs e)
        {
            using (GalleryContext galleryContext = new GalleryContext())
            {
                //if (expoGridView.SelectedRows.Count == 1)
                //{
                //    int i = expoGridView.SelectedRows[0].Index;
                //    int id = 0;
                //    bool converted = Int32.TryParse(expoGridView["Id", i].Value.ToString(), out id);
                //    if (converted == false)
                //        return;
                //    Exposition exposition = galleryContext.Expositions.Where(w => w.Id == id).FirstOrDefault();
                //    List<Painting> paintings = new List<Painting>();
                //}


                /* if (expoGridView.SelectedRows.Count > 0)
                 {
                     int expo_id = int.Parse(expoGridView["Id", expoGridView.SelectedRows[0].Index].Value.ToString());
                     Exposition exposition = galleryContext.Expositions.Where(ex => ex.Id == expo_id).FirstOrDefault();
                     PaintingsList showPaintings = new PaintingsList(exposition);
                     showPaintings.Show();*/
                if (expoGridView.SelectedRows.Count > 0)
            {
                int expo_id = int.Parse(expoGridView["Id", expoGridView.SelectedRows[0].Index].Value.ToString());

                    List<Painting> lp = new List<Painting>();
                    Exposition exposition = galleryContext.Expositions.Where(ex => ex.Id == expo_id).FirstOrDefault();
                    var list = galleryContext.Expositions.Where(expo => expo.Id == expo_id).Select(expo => expo.Paintings).ToList();
                    
                    for (int i = 0; i <list.Count; i++)
                    {
                        for (int j = 0; j < list[i].Count; j++)
                        { lp.Add(list[i].ToList()[j]);
                         //   MessageBox.Show(lp[j].Name.ToString());
                        }
                    }


                    PaintingsList showPaintings = new PaintingsList(lp);
                showPaintings.Show();

            }

        }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void editExpoBtn_Click(object sender, EventArgs e)
        {
            using (GalleryContext galleryContext = new GalleryContext())
            {
                if (expoGridView.SelectedRows.Count > 0)
                {
                    int expo_id = int.Parse(expoGridView["Id", expoGridView.SelectedRows[0].Index].Value.ToString());
                    Exposition exposition = galleryContext.Expositions.Find(expo_id);

                    SaveExposition saveExposition = new SaveExposition(exposition);
                    saveExposition.Show();
                }
            }
        }
    }
}
