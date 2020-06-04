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
            refreshList();
        }

        private void refreshList()
        {
            galleryContext = new GalleryContext();
            //
            StatusChecker.CheckExpositionsForStatus(galleryContext);
            //
            List<Exposition> expositions = galleryContext.Expositions.ToList();
            FillDataGrid(expositions);
            SetWidth();
        }

        private void FillDataGrid(List<Exposition> expositions)
        {
            DataTable dataTable = new DataTable();
            dataTable.Reset();

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Название", typeof(string));
            dataTable.Columns.Add("Статус", typeof(ExpositionStatus));
            dataTable.Columns.Add("Дата начала", typeof(DateTime));
            dataTable.Columns.Add("Дата окончания", typeof(DateTime));
            dataTable.Columns.Add("Выставочный зал", typeof(string));
            dataTable.Columns.Add("Галерея", typeof(string));

            if (galleryContext.Expositions.Any())
            {
                foreach (Exposition expo in expositions)
                {
                    var Showroom = galleryContext.Showrooms.Find(expo.ShowroomId);
                    var Gallery = galleryContext.Gallerys.Find(expo.GalleryId);

                    DataRow dataRow;
                    dataRow = dataTable.NewRow();
                    dataRow["Id"] = expo.Id;
                    dataRow["Название"] = expo.Name;
                    dataRow["Статус"] = expo.Status;
                    dataRow["Дата начала"] = expo.StartDate;
                    dataRow["Дата окончания"] = expo.EndDate;
                    dataRow["Выставочный зал"] = Showroom.Title;
                    dataRow["Галерея"] = Gallery.Title;

                    dataTable.Rows.Add(dataRow);
                }
            }

            expoGridView.Refresh();
            expoGridView.DataSource = dataTable;
            expoGridView.Columns["Id"].Visible = false;
        }

        private void SetWidth()
        {
            double w = expoGridView.Width - 53;

            expoGridView.Columns["Название"].Width = (100 - Convert.ToInt32(w / 100 * 25)) > 0 ? 100 : Convert.ToInt32(w / 100 * 25);
            expoGridView.Columns["Статус"].Width = (60 - Convert.ToInt32(w / 100 * 12)) > 0 ? 60 : Convert.ToInt32(w / 100 * 12);
            expoGridView.Columns["Дата начала"].Width = (92 - Convert.ToInt32(w / 100 * 16)) > 0 ? 92 : Convert.ToInt32(w / 100 * 16);
            expoGridView.Columns["Дата окончания"].Width = (92 - Convert.ToInt32(w / 100 * 16)) > 0 ? 92 : Convert.ToInt32(w / 100 * 16);
            expoGridView.Columns["Выставочный зал"].Width = (84 - Convert.ToInt32(w / 100 * 14)) > 0 ? 84 : Convert.ToInt32(w / 100 * 14);
            expoGridView.Columns["Галерея"].Width = (92 - Convert.ToInt32(w / 100 * 17)) > 0 ? 92 : Convert.ToInt32(w / 100 * 17);

            int ww
                = expoGridView.Columns["Название"].Width
                + expoGridView.Columns["Статус"].Width
                + expoGridView.Columns["Дата начала"].Width
                + expoGridView.Columns["Дата окончания"].Width
                + expoGridView.Columns["Выставочный зал"].Width
                + expoGridView.Columns["Галерея"].Width;

            expoGridView.Columns["Название"].Width += w > 573 ? w < ww ? -(int)Math.Abs(w - ww) : (int)Math.Abs(w - ww) : 0;
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
                refreshList();
            }
        }

        private void deleteExpositionBtn_Click(object sender, EventArgs e)
        {
            if (expoGridView.SelectedRows.Count > 0)
            {
                int expo_id = int.Parse(expoGridView["Id", expoGridView.SelectedRows[0].Index].Value.ToString());
                Exposition exposition = galleryContext.Expositions.Find(expo_id);

                galleryContext.Expositions.Remove(exposition);
                galleryContext.SaveChanges();
                //
                StatusChecker.CheckPaintingsForStatus(galleryContext);
                //
                refreshList();
            }
        }

        private void showPaintingsBtn_Click(object sender, EventArgs e)
        {
            if (expoGridView.SelectedRows.Count > 0)
            {
                int expo_id = int.Parse(expoGridView["Id", expoGridView.SelectedRows[0].Index].Value.ToString());
                Exposition exposition = galleryContext.Expositions.Find(expo_id);
                galleryContext.Entry(exposition).Collection(expo => expo.Paintings).Load();

                PaintingsList paintingsList = new PaintingsList();
                paintingsList.paintings = exposition.Paintings.ToList();
                paintingsList.Show();
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

        private void ShowExpositions_SizeChanged(object sender, EventArgs e)
        {
            SetWidth();
        }
    }
}
