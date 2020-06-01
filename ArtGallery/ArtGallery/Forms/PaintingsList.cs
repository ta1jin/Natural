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
        private GalleryContext galleryContext;
        public string type { get; set; }
        public List<Painting> paintings { get; set; }

        public string[] messages = { "Выбрать картины для удаления", "Отменить выбор" };

        public PaintingsList()
        {
            InitializeComponent();
        }

        private void PaintingsList_Load(object sender, EventArgs e)
        {
            galleryContext = new GalleryContext();

            if (paintings != null)
                type = "Expo";

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Delete?";
            checkBoxColumn.Name = "Delete";
            checkBoxColumn.ValueType = typeof(bool);
            checkBoxColumn.Width = 60;
            paintingDataGridView.Columns.Add(checkBoxColumn);
            paintingDataGridView.Columns["Delete"].Visible = false;
            paintingDataGridView.Columns["Delete"].DisplayIndex = 0;

            switch (type)
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
                case "Expo":
                    HideButtons();
                    break;
                default:
                    break;
            }

            List<String> properties = new List<String>() { "Name", "Artist", "Genre", "PaintTechnique", "State", "Status" };
            PropertiesComboBox.Items.AddRange(properties.ToArray());

            RefreshList();
        }

        public void RefreshList()
        {
            galleryContext = new GalleryContext();
            //
            StatusChecker.CheckPaintingsForStatus(galleryContext);
            //
            if (type != "Expo")
            {
                paintings = galleryContext.Paintings.ToList();
            }
            FillDataGrid(paintings);
            setWidth();
        }

        private void FillDataGrid(List<Painting> paintings)
        {
            DataTable dataTable = new DataTable();
            dataTable.Reset();

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Название картины", typeof(string));
            dataTable.Columns.Add("Художник", typeof(string));
            dataTable.Columns.Add("Жанр", typeof(string));
            dataTable.Columns.Add("Техника живописи", typeof(string));
            dataTable.Columns.Add("Название галереи", typeof(string));
            dataTable.Columns.Add("Дата написания", typeof(DateTime));
            dataTable.Columns.Add("Цена", typeof(double));
            dataTable.Columns.Add("Состояние", typeof(state));
            dataTable.Columns.Add("Статус", typeof(status));

            if (galleryContext.Paintings.Any())
            {
                foreach (Painting painting in paintings)
                {
                    var Artist = galleryContext.Artists.Find(painting.ArtistId);
                    var Genre = galleryContext.Genres.Find(painting.GenreId);
                    var PaintingTechnique = galleryContext.PaintingTechniques.Find(painting.PaintingTechniqueId);
                    var Gallery = galleryContext.Gallerys.Find(painting.GalleryId);

                    DataRow dataRow;
                    dataRow = dataTable.NewRow();
                    dataRow["Id"] = painting.Id;
                    dataRow["Название картины"] = painting.Name;
                    dataRow["Художник"] = Artist.Name + " " + Artist.Patronymic + " " + Artist.Surname;
                    dataRow["Жанр"] = Genre.Name;
                    dataRow["Техника живописи"] = PaintingTechnique.Name;
                    dataRow["Название галереи"] = Gallery.Title;
                    dataRow["Дата написания"] = painting.DateOfPainting;
                    dataRow["Цена"] = painting.Price;
                    dataRow["Состояние"] = painting.State;
                    dataRow["Статус"] = painting.Status;
                    dataTable.Rows.Add(dataRow);
                }

                paintingDataGridView.Refresh();
                paintingDataGridView.DataSource = dataTable;
            }
        }

        private void AddPainting_Click(object sender, EventArgs e)
        {
            AddPainting aP = new AddPainting();
            //  aP.gc = gc;
            aP.ShowDialog();
            RefreshList();
            ValuesComboBox.Text = "";
            PropertiesComboBox.Text = "";
        }

        private void RefreshListButton_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void DeletePaintingsButton_Click(object sender, EventArgs e)
        {

            Delete.Visible = paintingDataGridView.Columns["Delete"].Visible = paintingDataGridView.Columns["Delete"].Visible == true ? false : true;
            DeletePaintingsButton.Text = messages[Convert.ToInt32(paintingDataGridView.Columns["Delete"].Visible)];
            ValuesComboBox.Text = "";
            PropertiesComboBox.Text = "";
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
            if (IDs.Count == 0)
                MessageBox.Show("Выберите картины, которые вы хотите удалить", "Ошибка");
            else
            {
                foreach (int i in IDs)
                {
                    Painting painting = galleryContext.Paintings
                     .Where(p => p.Id == i)
                    .FirstOrDefault();
                    galleryContext.Paintings.Remove(painting);
                }
                galleryContext.SaveChanges();
                RefreshList();
            }
            ValuesComboBox.Text = "";
            PropertiesComboBox.Text = "";
        }

        private void EditPainting_Click(object sender, EventArgs e)
        {
            if (paintingDataGridView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in paintingDataGridView.SelectedRows)
                {
                    int id = Convert.ToInt32(paintingDataGridView["Id", dr.Index].Value);
                    AddPainting ap = new AddPainting(id);
                    // ap.gc = gc;
                    ap.Show();
                    RefreshList();
                }
            }
            ValuesComboBox.Text = "";
            PropertiesComboBox.Text = "";
        }

        private void ValuesComboBoxFill(object sender, EventArgs e)
        {
            ValuesComboBox.Items.Clear();
            ValuesComboBox.Text = "";
            var values = from p in galleryContext.Paintings
                         select p.Name;
            var enumvalues = System.Enum.GetNames(typeof(state));
            bool IsEnum = false;
            switch (PropertiesComboBox.Text)
            {
                case "Name":
                    break;
                case "Artist":
                    values = from a in galleryContext.Artists
                             select a.Name;
                    break;
                case "Genre":
                    values = from g in galleryContext.Genres
                             select g.Name;
                    break;
                case "PaintTechnique":
                    values = from pT in galleryContext.PaintingTechniques
                             select pT.Name;
                    break;
                case "State":
                    IsEnum = true;
                    break;
                case "Status":
                    enumvalues = System.Enum.GetNames(typeof(status));
                    IsEnum = true;
                    break;
                default:
                    break;
            }

            if (IsEnum)
                ValuesComboBox.Items.AddRange(enumvalues);
            else
                ValuesComboBox.Items.AddRange(values.ToArray());
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (PropertiesComboBox.Text == "" && e.KeyCode != Keys.Enter)
            {
                MessageBox.Show("Сначала выберите свойство по которому будет производиться поиск", "Ошибка");
                SearchTextBox.Text = "";
            }

            else
            {
                var paintings = from p in galleryContext.Paintings
                                where p.Name.Contains(SearchTextBox.Text)
                                select p;
                switch (PropertiesComboBox.Text)
                {
                    case "Name":
                        break;
                    case "Artist":
                        paintings = from p in galleryContext.Paintings
                                    where p.Artist.Name.Contains(SearchTextBox.Text)
                                    select p;
                        break;
                    case "Genre":
                        paintings = from p in galleryContext.Paintings
                                    where p.Genre.Name.Contains(SearchTextBox.Text)
                                    select p;
                        break;
                    case "PaintTechnique":
                        paintings = from p in galleryContext.Paintings
                                    where p.PaintingTechnique.Name.Contains(SearchTextBox.Text)
                                    select p;
                        break;
                    case "State":
                        paintings = from p in galleryContext.Paintings
                                    where p.State.ToString().Contains(SearchTextBox.Text)
                                    select p;
                        break;
                    case "Status":
                        paintings = from p in galleryContext.Paintings
                                    where p.Status.ToString().Contains(SearchTextBox.Text)
                                    select p;

                        break;
                    default:
                        break;
                }

                RefreshList();
            }
        }

        private void ValuesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var paintings = from p in galleryContext.Paintings
                            where p.Name == ValuesComboBox.Text
                            select p;
            switch (PropertiesComboBox.Text)
            {
                case "Name":
                    break;
                case "Artist":
                    paintings = from p in galleryContext.Paintings
                                where p.Artist.Name == ValuesComboBox.Text
                                select p;
                    break;
                case "Genre":
                    paintings = from p in galleryContext.Paintings
                                where p.Genre.Name == ValuesComboBox.Text
                                select p;
                    break;
                case "PaintTechnique":
                    paintings = from p in galleryContext.Paintings
                                where p.PaintingTechnique.Name == ValuesComboBox.Text
                                select p;
                    break;
                case "State":
                    paintings = from p in galleryContext.Paintings
                                where p.State.ToString() == ValuesComboBox.Text
                                select p;
                    break;
                case "Status":
                    paintings = from p in galleryContext.Paintings
                                where p.Status.ToString() == ValuesComboBox.Text
                                select p;

                    break;
                default:
                    break;
            }
            RefreshList();
        }

        private void SearchTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            ValuesComboBox.Text = "";
        }

        public void HideButtons()
        {
            AddPaintingButton.Visible = false;
            EditPainting.Visible = false;
            RefreshListButton.Visible = false;
            DeletePaintingsButton.Visible = false;
            Delete.Visible = false;
        }

        public void setWidth()
        {
            paintingDataGridView.Columns[1].Width = 50;
            paintingDataGridView.Columns[2].Width = 120;
            paintingDataGridView.Columns[3].Width = 200;
            paintingDataGridView.Columns[4].Width = 150;
            paintingDataGridView.Columns[5].Width = 200;
            paintingDataGridView.Columns[6].Width = 120;
            paintingDataGridView.Columns[7].Width = 120;
            paintingDataGridView.Columns[8].Width = 100;
            paintingDataGridView.Columns[9].Width = 100;
            paintingDataGridView.Columns[10].Width = 100;
        }
    }
}

