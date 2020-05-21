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
    enum Mode { Add, Edit }
    public partial class SaveExposition : Form
    {
        private Mode mode;
        private int expoID = 0;
        private List<Painting> expoPaintings;

        public SaveExposition()
        {
            mode = Mode.Add;
            InitializeComponent();
            ShowLeft();
        }

        public SaveExposition(Exposition exposition)
        {
            mode = Mode.Edit;
            InitializeComponent();
            ShowLeft();

            expoID = exposition.Id;
            expositionTitleTextBox.Text = exposition.Name;
            startDate.Value = exposition.StartDate;
            endDate.Value = exposition.EndDate;
            locationTextBox.Text = exposition.Location;

            expoPaintings = new List<Painting>();
            using (GalleryContext galleryContext = new GalleryContext())
            {
                var involvedPaintingsIQuer = galleryContext.Expositions.Where(expo => expo.Id == expoID)
                    .Select(expo => expo.Paintings).ToList();
                for (int _i = 0; _i < involvedPaintingsIQuer.Count; _i++)
                    for (int _j = 0; _j < involvedPaintingsIQuer[_i].Count; _j++)
                        expoPaintings.Add(involvedPaintingsIQuer[_i].ToList()[_j]);
            }
        }

        private void ShowLeft()
        {
            Width = 330;
            Height = 225;

            label4.Visible = true;
            expositionTitleTextBox.Visible = true;
            label3.Visible = true;
            locationTextBox.Visible = true;
            label1.Visible = true;
            startDate.Visible = true;
            label2.Visible = true;
            endDate.Visible = true;
            confirmButton.Visible = true;

            dataGridView1.Visible = false;
            closeButton.Visible = false;
            saveButton.Visible = false;
            addPaintingsToListButton.Visible = false;
            deletePaintingFromListButton.Visible = false;
            addSelectedPaintingsButton.Visible = false;
        }

        private void ShowRight()
        {
            Width = 700;
            Height = 340;

            label4.Visible = false;
            expositionTitleTextBox.Visible = false;
            label3.Visible = false;
            locationTextBox.Visible = false;
            label1.Visible = false;
            startDate.Visible = false;
            label2.Visible = false;
            endDate.Visible = false;
            confirmButton.Visible = false;
            addSelectedPaintingsButton.Visible = false;

            dataGridView1.Visible = true;
            closeButton.Visible = true;
            saveButton.Visible = true;

            if (mode == Mode.Add)
            {
                paintingsListLabel.Text = "Список свободных картин:";
                addPaintingsToListButton.Visible = false;
                deletePaintingFromListButton.Visible = false;
            }
            else
            {
                paintingsListLabel.Text = "Список задействованных картин:";
                addPaintingsToListButton.Visible = true;
                deletePaintingFromListButton.Visible = true;
            }
        }

        private List<Painting> GetPaintings(int type) // 0: available;   1: involved;    2: available - involed
        {
            List<Painting> paintings = null;
            List<Painting> allPaintings = null;
            List<Painting> unavailPaintings = new List<Painting>();
            List<Painting> availPaintings = new List<Painting>();

            using (GalleryContext galleryContext = new GalleryContext())
            {
                allPaintings = galleryContext.Paintings.ToList();
                if (galleryContext.Expositions.Any())
                {
                    var unavailPaintingsIQuer = galleryContext.Expositions.Where(expo =>
                    (startDate.Value.CompareTo(expo.StartDate) > 0 && startDate.Value.CompareTo(expo.EndDate) < 0) ||
                    (endDate.Value.CompareTo(expo.StartDate) > 0 && endDate.Value.CompareTo(expo.EndDate) < 0))
                        .Select(p => p.Paintings)
                        .ToList();

                    for (int _i = 0; _i < unavailPaintingsIQuer.Count; _i++)
                        for (int _j = 0; _j < unavailPaintingsIQuer[_i].Count; _j++)
                            unavailPaintings.Add(unavailPaintingsIQuer[_i].ToList()[_j]);

                    for (int _i = 0; _i < allPaintings.Count; _i++)
                    {
                        int _k = 0;
                        for (int _j = 0; _j < unavailPaintings.Count; _j++)
                            if (allPaintings[_i].Id == unavailPaintings[_j].Id) _k = 1;

                        if (_k == 0) availPaintings.Add(allPaintings[_i]);
                    }
                }
                else
                {
                    availPaintings = allPaintings;
                }

                switch (type)
                {
                    case 0:
                        paintings = availPaintings;
                        break;
                    case 1:
                        if (expoID != 0)
                            paintings = expoPaintings;
                        break;
                    case 2:
                        if (expoID != 0)
                        {
                            List<Painting> paintingsToAdd = new List<Painting>();
                            for (int _i = 0; _i < availPaintings.Count; _i++)
                            {
                                int _k = 0;
                                for (int _j = 0; _j < expoPaintings.Count; _j++)
                                    if (availPaintings[_i].Id == expoPaintings[_j].Id) _k = 1;

                                if (_k == 0) paintingsToAdd.Add(availPaintings[_i]);
                            }
                            paintings = paintingsToAdd;
                        }
                        break;
                }
            }

            return paintings;
        }

        private void FillDataGrid(int type) // 0: available;   1: involved;    2: available - (involed + unavailable)
        {
            List<Painting> paintings = GetPaintings(type);
            FillDataGrid(paintings);
        }
        private void FillDataGrid(List<Painting> paintings)
        {
            DataTable dataTable = new DataTable();
            dataTable.Reset();

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Artist", typeof(string));
            dataTable.Columns.Add("Genre", typeof(string));
            dataTable.Columns.Add("PaintingTechnique", typeof(string));
            dataTable.Columns.Add("Gallery", typeof(string));
            dataTable.Columns.Add("DateOfPainting", typeof(DateTime));
            dataTable.Columns.Add("Price", typeof(double));
            dataTable.Columns.Add("Condition", typeof(state));

            using (GalleryContext galleryContext = new GalleryContext())
            {
                foreach (Painting painting in paintings)
                {
                    var Artist = galleryContext.Artists.Find(painting.ArtistId);
                    var Genre = galleryContext.Genres.Find(painting.GenreId);
                    var PaintingTechnique = galleryContext.PaintingTechniques.Find(painting.PaintingTehniqueId);
                    var Gallery = galleryContext.Gallerys.Find(painting.GalleryId);

                    DataRow dataRow;
                    dataRow = dataTable.NewRow();
                    dataRow["Id"] = painting.Id;
                    dataRow["Name"] = painting.Name;
                    dataRow["Artist"] = Artist.Name + " " + Artist.Patronymic + " " + Artist.Surname;
                    dataRow["Genre"] = Genre.Name;
                    dataRow["PaintingTechnique"] = PaintingTechnique.Name;
                    dataRow["Gallery"] = Gallery.Title;
                    dataRow["DateOfPainting"] = painting.DateOfPainting;
                    dataRow["Price"] = painting.Price;
                    dataRow["Condition"] = painting.State;

                    dataTable.Rows.Add(dataRow);
                }
            }

            dataGridView1.Refresh();
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (mode == Mode.Add) FillDataGrid(0);
            else FillDataGrid(1);
            ShowRight();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (GalleryContext galleryContext = new GalleryContext())
            {
                var gallery = galleryContext.Gallerys.First();
                if (mode == Mode.Add)
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        List<Painting> paintings = new List<Painting>();
                        List<IEnumerable<Painting>> paintingsToChange = new List<IEnumerable<Painting>>();

                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            int id = int.Parse(dataGridView1["Id", row.Index].Value.ToString());
                            paintings.Add(galleryContext.Paintings.Find(id));
                        }

                        Exposition exposition = new Exposition
                        {
                            Name = expositionTitleTextBox.Text,
                            StartDate = startDate.Value,
                            EndDate = endDate.Value,
                            Location = locationTextBox.Text,
                            Gallery = gallery,
                            Paintings = paintings
                        };
                        galleryContext.Expositions.Add(exposition);
                    }

                }
                else
                {
                    /*
                     * 
                     *  СДЕЛАТЬ ПРОВЕРКУ СТАТУСОВ КАРТИН
                     * 
                     */

                    List<Painting> galleryPaintings = galleryContext.Paintings.ToList();
                    List<Painting> updatedExpoPaintings = new List<Painting>();
                    Exposition exposition = galleryContext.Expositions.Find(expoID);

                    foreach (Painting p in expoPaintings)
                    {
                        updatedExpoPaintings.Add(galleryContext.Paintings.Find(p.Id));
                    }

                    galleryContext.Entry(exposition).Collection(expo => expo.Paintings).Load();
                    exposition.Name = expositionTitleTextBox.Text;
                    exposition.StartDate = startDate.Value;
                    exposition.EndDate = endDate.Value;
                    exposition.Location = locationTextBox.Text;
                    exposition.Gallery = gallery;

                    foreach (Painting p in galleryPaintings)
                        if (updatedExpoPaintings.Contains(p))
                        {
                            if (!exposition.Paintings.Contains(p))
                                exposition.Paintings.Add(p);
                        }
                        else
                        {
                            if (exposition.Paintings.Contains(p))
                                exposition.Paintings.Remove(p);
                        }

                    galleryContext.Entry(exposition).State = System.Data.Entity.EntityState.Modified;
                }

                galleryContext.SaveChanges();
            }

            Close();
        }

        private void addPaintingsToListButton_Click(object sender, EventArgs e)
        {
            saveButton.Enabled = false;
            addPaintingsToListButton.Visible = false;
            deletePaintingFromListButton.Visible = false;
            addSelectedPaintingsButton.Visible = true;

            paintingsListLabel.Text = "Список свободных картин:";
            FillDataGrid(2);
        }

        private void deletePaintingFromListButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = int.Parse(dataGridView1["Id", dataGridView1.SelectedRows[0].Index].Value.ToString());
                for (int _i = 0; _i < expoPaintings.Count; _i++)
                    if (expoPaintings[_i].Id == id)
                        expoPaintings.RemoveAt(_i);
            }
            FillDataGrid(expoPaintings);
        }

        private void addSelectedPaintingsButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                using (GalleryContext galleryContext = new GalleryContext())
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int id = int.Parse(dataGridView1["Id", row.Index].Value.ToString());
                        expoPaintings.Add(galleryContext.Paintings.Find(id));
                    }
                }
            }

            saveButton.Enabled = true;
            addPaintingsToListButton.Visible = true;
            deletePaintingFromListButton.Visible = true;
            addSelectedPaintingsButton.Visible = false;

            paintingsListLabel.Text = "Список задействованных картин:";
            FillDataGrid(expoPaintings);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
