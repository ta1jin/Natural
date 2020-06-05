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
    enum Mode { Insert, Update }
    public partial class SaveExposition : Form
    {
        private Mode mode;
        private int expoID = 0;
        private List<Painting> expoPaintings;
        public GalleryContext galleryContext { get; set; }
        public Exposition exposition { get; set; }

        public SaveExposition()
        {
            InitializeComponent();
        }

        private void SaveExposition_Load(object sender, EventArgs e)
        {
            if (exposition == null)
            {
                mode = Mode.Insert;
            }
            else
            {
                mode = Mode.Update;
                expoID = exposition.Id;
                expositionTitleTextBox.Text = exposition.Name;
                startDate.Value = exposition.StartDate;
                endDate.Value = exposition.EndDate;

                galleryContext.Entry(exposition).Collection(expo => expo.Paintings).Load();
                expoPaintings = exposition.Paintings.ToList();
            }

            ShowLeft();
        }

        private void ShowLeft()
        {
            Width = 331;
            Height = 199;

            HideRight();

            FormBorderStyle = FormBorderStyle.FixedSingle;

            label4.Visible = true;
            expositionTitleTextBox.Visible = true;
            label1.Visible = true;
            startDate.Visible = true;
            label2.Visible = true;
            endDate.Visible = true;
            confirmButton.Visible = true;
        }

        private void ShowRight()
        {
            Width = 800;
            Height = 352;

            HideLeft();

            MinimumSize = new Size(500, 250);
            FormBorderStyle = FormBorderStyle.Sizable;

            dataGridView1.Visible = true;
            closeButton.Visible = true;
            saveButton.Visible = true;
            label3.Visible = true;
            showroomComboBox.Visible = true;

            if (mode == Mode.Insert)
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
                label3.Location = new Point(13, 282);
                showroomComboBox.Location = new Point(127, 279);
                showroomComboBox.SelectedItem = galleryContext.Expositions.Find(expoID).Showroom.Title;
            }
        }

        private void HideLeft()
        {
            label4.Visible = false;
            expositionTitleTextBox.Visible = false;
            label1.Visible = false;
            startDate.Visible = false;
            label2.Visible = false;
            endDate.Visible = false;
            confirmButton.Visible = false;
            addSelectedPaintingsButton.Visible = false;
        }

        private void HideRight()
        {
            dataGridView1.Visible = false;
            closeButton.Visible = false;
            saveButton.Visible = false;
            addPaintingsToListButton.Visible = false;
            deletePaintingFromListButton.Visible = false;
            addSelectedPaintingsButton.Visible = false;
            label3.Visible = false;
            showroomComboBox.Visible = false;
        }

        private void GetShowrooms(int type) // 0: available;   1: available + involved;
        {
            List<Showroom> allShowrooms = null;
            List<Showroom> availShowrooms = new List<Showroom>();
            List<Showroom> unavailShowrooms = null;

            allShowrooms = galleryContext.Showrooms.ToList();
            if (galleryContext.Expositions.Any())
            {
                unavailShowrooms = galleryContext.Expositions.Where(expo =>
                expo.Status != ExpositionStatus.Cancelled &&
                ((startDate.Value.CompareTo(expo.StartDate) >= 0 && startDate.Value.CompareTo(expo.EndDate) <= 0) ||
                (endDate.Value.CompareTo(expo.StartDate) >= 0 && endDate.Value.CompareTo(expo.EndDate) <= 0)))
                    .Select(expo => expo.Showroom)
                    .ToList();

                for (int _i = 0; _i < allShowrooms.Count; _i++)
                {
                    int _k = 0;
                    for (int _j = 0; _j < unavailShowrooms.Count; _j++)
                        if (allShowrooms[_i].Id == unavailShowrooms[_j].Id) _k = 1;

                    if (_k == 0) availShowrooms.Add(allShowrooms[_i]);
                }
            }
            else
            {
                availShowrooms = allShowrooms;
            }

            if (type == 1 && expoID != 0)
            {
                availShowrooms.Add(galleryContext.Expositions.Find(expoID).Showroom);
            }

            string[] showrooms = availShowrooms.Select(sh => sh.Title).ToArray(); //galleryContext.Showrooms.Select(sh => sh.Title).ToArray();
            showroomComboBox.Items.AddRange(showrooms);

        }

        private List<Painting> GetPaintings(int type) // 0: available;   1: involved;    2: available - involed
        {
            List<Painting> paintings = null;
            List<Painting> allPaintings = null;
            List<Painting> unavailPaintings = new List<Painting>();
            List<Painting> availPaintings = new List<Painting>();

            allPaintings = galleryContext.Paintings.ToList();
            if (galleryContext.Expositions.Any())
            {
                var unavailPaintingsIQuer = galleryContext.Expositions.Where(expo =>
                expo.Status != ExpositionStatus.Cancelled &&
                ((startDate.Value.CompareTo(expo.StartDate) >= 0 && startDate.Value.CompareTo(expo.EndDate) <= 0) ||
                (endDate.Value.CompareTo(expo.StartDate) >= 0 && endDate.Value.CompareTo(expo.EndDate) <= 0)))
                    .Select(expo => expo.Paintings)
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
            dataTable.Columns.Add("Название", typeof(string));
            dataTable.Columns.Add("Художник", typeof(string));
            dataTable.Columns.Add("Жанр", typeof(string));
            dataTable.Columns.Add("Техника живописи", typeof(string));
            dataTable.Columns.Add("Галерея", typeof(string));
            dataTable.Columns.Add("Дата написания", typeof(DateTime));
            dataTable.Columns.Add("Стоимость", typeof(double));
            dataTable.Columns.Add("Состояние", typeof(state));

            foreach (Painting painting in paintings)
            {
                var Artist = galleryContext.Artists.Find(painting.ArtistId);
                var Genre = galleryContext.Genres.Find(painting.GenreId);
                var PaintingTechnique = galleryContext.PaintingTechniques.Find(painting.PaintingTechniqueId);
                var Gallery = galleryContext.Gallerys.Find(painting.GalleryId);

                DataRow dataRow;
                dataRow = dataTable.NewRow();
                dataRow["Id"] = painting.Id;
                dataRow["Название"] = painting.Name;
                dataRow["Художник"] = Artist.Name + " " + Artist.Patronymic + " " + Artist.Surname;
                dataRow["Жанр"] = Genre.Name;
                dataRow["Техника живописи"] = PaintingTechnique.Name;
                dataRow["Галерея"] = Gallery.Title;
                dataRow["Дата написания"] = painting.DateOfPainting;
                dataRow["Стоимость"] = painting.Price;
                dataRow["Состояние"] = painting.State;

                dataTable.Rows.Add(dataRow);
            }


            dataGridView1.Refresh();
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Id"].Visible = false;
            SetWidth();
        }

        private void SetWidth()
        {
            double gridViewWidth = dataGridView1.Width - 43;

            dataGridView1.Columns[1].Width = nwidth(120, 20);
            dataGridView1.Columns[2].Width = nwidth(160, 20);
            dataGridView1.Columns[3].Width = nwidth(76, 10);
            dataGridView1.Columns[4].Width = nwidth(170, 20);
            dataGridView1.Columns[5].Width = nwidth(92, 13);
            dataGridView1.Columns[6].Width = nwidth(68, 5);
            dataGridView1.Columns[7].Width = nwidth(68, 5);
            dataGridView1.Columns[8].Width = nwidth(92, 7);

            int columnsWidth
                = dataGridView1.Columns[1].Width
                + dataGridView1.Columns[2].Width
                + dataGridView1.Columns[3].Width
                + dataGridView1.Columns[4].Width
                + dataGridView1.Columns[5].Width
                + dataGridView1.Columns[6].Width
                + dataGridView1.Columns[7].Width
                + dataGridView1.Columns[8].Width;

            int www = dataGridView1.Columns[1].Width + (int)(gridViewWidth - columnsWidth);
            dataGridView1.Columns[1].Width = (120 - www) > 0 ? 120 : www;

            int nwidth(int minWidth, int percentage)
            {
                return (minWidth - Convert.ToInt32(gridViewWidth / 100 * percentage)) > 0
                    ? minWidth : Convert.ToInt32(gridViewWidth / 100 * percentage);
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (mode == Mode.Insert)
            {
                GetShowrooms(0);
                FillDataGrid(0);
            }
            else
            {
                GetShowrooms(1);
                FillDataGrid(1);
            }
            ShowRight();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var gallery = galleryContext.Gallerys.First();
            var showroom = galleryContext.Showrooms.First(sh => sh.Title == showroomComboBox.SelectedItem.ToString());

            if (mode == Mode.Insert)
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
                        Status = ExpositionStatus.Scheduled,
                        StartDate = startDate.Value.Subtract(new TimeSpan(0, 0, startDate.Value.Second)),
                        EndDate = endDate.Value.Subtract(new TimeSpan(0, 0, endDate.Value.Second)),
                        Showroom = showroom,
                        Gallery = gallery,
                        Paintings = paintings
                    };

                    galleryContext.Expositions.Add(exposition);
                }

            }
            else
            {
                List<Painting> galleryPaintings = galleryContext.Paintings.ToList();
                List<Painting> updatedExpoPaintings = new List<Painting>();

                foreach (Painting p in expoPaintings)
                {
                    updatedExpoPaintings.Add(galleryContext.Paintings.Find(p.Id));
                }

                galleryContext.Entry(exposition).Collection(expo => expo.Paintings).Load();
                exposition.Name = expositionTitleTextBox.Text;
                exposition.Showroom = showroom;
                exposition.StartDate = startDate.Value.Subtract(new TimeSpan(0, 0, startDate.Value.Second));
                exposition.EndDate = endDate.Value.Subtract(new TimeSpan(0, 0, endDate.Value.Second));
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
            }

            galleryContext.SaveChanges();
            //
            StatusChecker.CheckPaintingsForStatus(galleryContext);
            //
            StatusChecker.CheckExpositionsForStatus(galleryContext);
            //

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
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int id = int.Parse(dataGridView1["Id", row.Index].Value.ToString());
                    expoPaintings.Add(galleryContext.Paintings.Find(id));
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

        private void SaveExposition_SizeChanged(object sender, EventArgs e)
        {
            if (Width > 500)
                SetWidth();
        }
    }
}
