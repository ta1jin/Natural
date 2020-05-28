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
        private GalleryContext gc;

        public string[] messages= { "Выбрать картины для удаления" ,"Отменить выбор" };

        public PaintingsList(List<Painting> paintings)
        {
            InitializeComponent();         

            HideButtons();
            RefreshList(paintings);
            
        }


        public PaintingsList(string s)
		{
            gc = new GalleryContext();
            InitializeComponent();
           
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

            List < String > properties = new List<String>() { "Name", "Artist", "Genre", "PaintTechnique", "State", "Status" };
            
            PropertiesComboBox.Items.AddRange(properties.ToArray());
          
            RefreshList();


        }

        public void RefreshList(List<Painting> paintings = null)
        {
            
            
            DataTable dt = new DataTable();
            dt.Reset();
            StatusChecker.CheckPaintingsForStatus();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Название картины", typeof(string));
            dt.Columns.Add("Художник", typeof(string));
            dt.Columns.Add("Жанр", typeof(string));
            dt.Columns.Add("Техника живописи", typeof(string));
            dt.Columns.Add("Название галереи", typeof(string));
            dt.Columns.Add("Дата написания", typeof(DateTime));
            dt.Columns.Add("Цена", typeof(double));
            dt.Columns.Add("Состояние", typeof(state));
            dt.Columns.Add("Статус", typeof(status));
                  
            
            
            if (paintings == null)
            {
                var paints = from p in gc.Paintings
                             select p;
                paintings = paints.ToList();
            }
            foreach (Painting p in paintings)
            {
                var ArtistName = from a in gc.Artists
                                 where p.ArtistId == a.Id
                                 select (a.Surname + " " + a.Name + " " + a.Patronymic).ToString();

                var GenreName = from g in gc.Genres
                                where p.GenreId == g.Id
                                select g.Name.ToString();

                var PaintingTechniqueName = from pT in gc.PaintingTechniques
                                            where p.PaintingTechniqueId == pT.Id
                                            select pT.Name.ToString();
                var GalleryName = from g in gc.Gallerys
                                  where p.GalleryId == g.Id
                                  select g.Title
                                  .ToString();
                string s = GenreName.First();
                DataRow drow;
                drow = dt.NewRow();
                drow["Id"] = p.Id;
                drow["Название картины"] = p.Name;
                drow["Художник"] = ArtistName.First();
                drow["Жанр"] = s;
                drow["Техника живописи"] = PaintingTechniqueName.First();
                drow["Название галереи"] = GalleryName.First();
                drow["Дата написания"] = p.DateOfPainting;
                drow["Цена"] = p.Price;
                drow["Состояние"] = p.State;
                drow["Статус"] = p.Status;
                dt.Rows.Add(drow);
                
            }



            //gc.
            // paintingDataGridView.Refresh();
            gc.SaveChanges();          
            paintingDataGridView.Refresh();
            paintingDataGridView.DataSource = dt;

            setWidth();

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
            PaintingsList PL = new PaintingsList("JustList");
            PL.Show();
            this.Close();
        }

        private void DeletePaintingsButton_Click(object sender, EventArgs e)
        {

            Delete.Visible=paintingDataGridView.Columns["Delete"].Visible = paintingDataGridView.Columns["Delete"].Visible == true ? false : true;
            DeletePaintingsButton.Text = messages[Convert.ToInt32( paintingDataGridView.Columns["Delete"].Visible)];
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
                    Painting painting = gc.Paintings
                     .Where(p => p.Id == i)
                    .FirstOrDefault();
                    gc.Paintings.Remove(painting);
                }
                gc.SaveChanges();
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
            var values = from p in gc.Paintings
                         select p.Name;
            var enumvalues = System.Enum.GetNames(typeof(state));
            bool IsEnum = false;
            switch (PropertiesComboBox.Text)
            {
                case "Name":
                    break ;
                case "Artist":
                    values = from a in gc.Artists
                                 select a.Name;
                    break;
                case "Genre":
                    values = from g in gc.Genres
                             select g.Name;
                    break;
                case "PaintTechnique":
                    values= from pT in gc.PaintingTechniques
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
                var paintings = from p in gc.Paintings
                                where p.Name.Contains(SearchTextBox.Text)
                                select p;
                switch (PropertiesComboBox.Text)
                {
                    case "Name":
                        break;
                    case "Artist":
                        paintings = from p in gc.Paintings
                                    where p.Artist.Name.Contains(SearchTextBox.Text)
                                    select p;
                        break;
                    case "Genre":
                        paintings = from p in gc.Paintings
                                    where p.Genre.Name.Contains(SearchTextBox.Text)
                                    select p;
                        break;
                    case "PaintTechnique":
                        paintings = from p in gc.Paintings
                                    where p.PaintingTechnique.Name.Contains(SearchTextBox.Text)
                                    select p;
                        break;
                    case "State":
                        paintings = from p in gc.Paintings
                                    where p.State.ToString().Contains(SearchTextBox.Text)
                                    select p;
                        break;
                    case "Status":
                        paintings = from p in gc.Paintings
                                    where p.Status.ToString().Contains(SearchTextBox.Text)
                                    select p;

                        break;
                    default:
                        break;
                }

                RefreshList(paintings.ToList());
            }
        }

        private void ValuesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var paintings = from p in gc.Paintings
                            where p.Name == ValuesComboBox.Text
                            select p;
            switch (PropertiesComboBox.Text)
            {
                case "Name":
                    break;
                case "Artist":
                    paintings = from p in gc.Paintings
                                where p.Artist.Name == ValuesComboBox.Text
                                select p;
                    break;
                case "Genre":
                    paintings = from p in gc.Paintings
                                where p.Genre.Name == ValuesComboBox.Text
                                select p;
                    break;
                case "PaintTechnique":
                    paintings = from p in gc.Paintings
                                where p.PaintingTechnique.Name == ValuesComboBox.Text
                                select p;
                    break;
                case "State":
                    paintings = from p in gc.Paintings
                                where p.State.ToString() == ValuesComboBox.Text
                                select p;
                    break;
                case "Status":
                    paintings = from p in gc.Paintings
                                where p.Status.ToString() == ValuesComboBox.Text
                                select p;

                    break;
                default:
                    break;
            }
            RefreshList(paintings.ToList());
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

