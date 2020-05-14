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
    public partial class AddExposition : Form
    {
        public AddExposition()
        {
            InitializeComponent();
        }

        private void confirmDateBtn_Click(object sender, EventArgs e)
        {
            using (GalleryContext galleryContext = new GalleryContext())
            {

                List<Painting> paintings = null;

                var allPaintings = galleryContext.Paintings.ToList();

                DataTable dataTable = new DataTable();
                dataTable.Reset();

                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Name", typeof(string));
                dataTable.Columns.Add("ArtistName", typeof(string));
                dataTable.Columns.Add("GenreName", typeof(string));
                dataTable.Columns.Add("PaintingTechniqueName", typeof(string));
                dataTable.Columns.Add("GalleryName", typeof(string));
                dataTable.Columns.Add("DateOfPainting", typeof(DateTime));
                dataTable.Columns.Add("Price", typeof(double));
                dataTable.Columns.Add("Status", typeof(status));
                dataTable.Columns.Add("Condition", typeof(state));

                if (galleryContext.Expositions.Any())
                {
                    var nonAvailPaintingsEnum = galleryContext.Expositions.Where(expo =>
                    (startDate.Value.CompareTo(expo.StartDate) > 0 && startDate.Value.CompareTo(expo.EndDate) < 0) ||
                    (endDate.Value.CompareTo(expo.StartDate) > 0 && endDate.Value.CompareTo(expo.EndDate) < 0))
                        .Select(p => p.Paintings)
                        .ToList();

                    List<Painting> nonAvailPaintings = new List<Painting>();
                    for (int _i = 0; _i < nonAvailPaintingsEnum.Count; _i++)
                    {
                        for (int _j = 0; _j < nonAvailPaintingsEnum[_i].Count; _j++)
                        {
                            nonAvailPaintings.Add(nonAvailPaintingsEnum[_i].ToList()[_j]);
                        }
                    }

                    List<Painting> availPaintings = new List<Painting>();
                    for (int _i = 0; _i < allPaintings.Count; _i++)
                    {
                        int _k = 0;
                        for (int _j = 0; _j < nonAvailPaintings.Count; _j++)
                        {
                            if (allPaintings[_i].Id == nonAvailPaintings[_j].Id) _k = 1;
                        }
                        if (_k == 0) availPaintings.Add(allPaintings[_i]);
                    }
                    paintings = availPaintings;
                }
                if (paintings == null)
                {
                    var paints = from p in galleryContext.Paintings
                                 select p;
                    paintings = paints.ToList();
                }
                foreach (Painting p in paintings)
                {
                    var ArtistName = from a in galleryContext.Artists
                                     where p.ArtistId == a.Id
                                     select (a.Surname + " " + a.Name + " " + a.Patronymic).ToString();

                    var GenreName = from g in galleryContext.Genres
                                    where p.GenreId == g.Id
                                    select g.Name.ToString();

                    var PaintingTechniqueName = from pT in galleryContext.PaintingTechniques
                                                where p.GenreId == pT.Id
                                                select pT.Name.ToString();

                    var GalleryName = from g in galleryContext.Gallerys
                                      where p.GalleryId == g.Id
                                      select g.Title.ToString();

                    string s = GenreName.First();
                    DataRow dataRow;
                    dataRow = dataTable.NewRow();
                    dataRow["Id"] = p.Id;
                    dataRow["Name"] = p.Name;
                    dataRow["ArtistName"] = ArtistName.First();
                    dataRow["GenreName"] = s;
                    dataRow["PaintingTechniqueName"] = PaintingTechniqueName.First();
                    dataRow["GalleryName"] = GalleryName.First();
                    dataRow["DateOfPainting"] = p.DateOfPainting;
                    dataRow["Price"] = p.Price;
                    dataRow["Status"] = p.Status;
                    dataRow["Condition"] = p.State;
                    dataTable.Rows.Add(dataRow);
                }
                paintingsDataGridView.Refresh();
                paintingsDataGridView.DataSource = dataTable;
                paintingsDataGridView.Columns["Id"].Visible = false;
            }
        }

        private void saveExpositionBtn_Click(object sender, EventArgs e)
        {
            using (GalleryContext gContext = new GalleryContext())
            {
                if (paintingsDataGridView.SelectedRows.Count > 0)
                {
                    List<Painting> paintings = new List<Painting>();
                    List<IEnumerable<Painting>> p = new List<IEnumerable<Painting>>();

                    foreach (DataGridViewRow row in paintingsDataGridView.SelectedRows)
                    {
                        int id = int.Parse(row.Cells[0].Value.ToString());
                        paintings.Add(gContext.Paintings.Where(pain => pain.Id == id).SingleOrDefault());

                        p.Add(gContext.Paintings.Where(pain => pain.Id == id).AsEnumerable().Select(pain =>
                        {
                            pain.Status = status.NaExposicii;
                            return pain;
                        }));
                    }

                    for (int _i = 0; _i < p.Count; _i++)
                    {
                        foreach (Painting painting in p[_i])
                        {
                            gContext.Entry(painting).State = System.Data.Entity.EntityState.Modified;
                        }
                    }

                    var gallery = from g in gContext.Gallerys select g;

                    Exposition exposition = new Exposition();
                    exposition.Name = expoName.Text;
                    exposition.StartDate = startDate.Value;
                    exposition.EndDate = endDate.Value;
                    exposition.Location = expoLocation.Text;
                    exposition.Paintings = paintings;
                    exposition.Gallery = gallery.First();

                    for (int i = 0; i < exposition.Paintings.Count; i++)
                    {
                        MessageBox.Show(exposition.Paintings.ToList()[i].Name.ToString());

                    }
                        gContext.Expositions.Add(exposition);
                    gContext.SaveChanges();
                }

                Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
