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
    public partial class ShowUsers : Form
    {
        private GalleryContext galleryContext;
        public ShowUsers()
        {
            InitializeComponent();
        }

        private void ShowUsers_Load(object sender, EventArgs e)
        {
            galleryContext = new GalleryContext();
            refreshList();
        }

        private void refreshList()
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            DataTable dataTable = new DataTable();
            dataTable.Reset();

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Patronymic", typeof(string));
            dataTable.Columns.Add("Surname", typeof(string));
            dataTable.Columns.Add("e-mail", typeof(string));
            dataTable.Columns.Add("Position", typeof(string));
            dataTable.Columns.Add("Birthday", typeof(DateTime));
            dataTable.Columns.Add("GalleryName", typeof(string));

            if (galleryContext.Employees.Any())
            {
                List<Employee> employees = null;

                if (employees == null)
                {
                    employees = galleryContext.Employees.ToList();
                }

                foreach (Employee empl in employees)
                {
                    var Position = galleryContext.Positions.Find(empl.PositionId);
                    var Gallery = galleryContext.Gallerys.Find(empl.GalleryId);

                    DataRow dataRow;
                    dataRow = dataTable.NewRow();
                    dataRow["Id"] = empl.Id;
                    dataRow["Surname"] = empl.Surname;
                    dataRow["Name"] = empl.Name;
                    dataRow["Patronymic"] = empl.Patronymic;
                    dataRow["e-mail"] = empl.User.Email;
                    dataRow["Position"] = Position.Name;
                    dataRow["Birthday"] = empl.Birthday;
                    dataRow["GalleryName"] = Gallery.Title;

                    dataTable.Rows.Add(dataRow);
                }
            }

            dataGridView1.Refresh();
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            SaveUser saveUser = new SaveUser();
            saveUser.galleryContext = galleryContext;
            saveUser.ShowDialog();
            refreshList();
        }

        private void editEmployeeButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int user_id = int.Parse(dataGridView1["Id", dataGridView1.SelectedRows[0].Index].Value.ToString());
                Employee employee = galleryContext.Employees.Find(user_id);

                SaveUser saveUser = new SaveUser();
                saveUser.galleryContext = galleryContext;
                saveUser.employee = employee;
                saveUser.ShowDialog();
                refreshList();
            }
        }

        private void deleteEmployeeButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int user_id = int.Parse(dataGridView1["Id", dataGridView1.SelectedRows[0].Index].Value.ToString());
                User user = galleryContext.Users.Find(user_id);
                Employee employee = galleryContext.Employees.First(empl => empl.User.Login == user.Login);

                galleryContext.Employees.Remove(employee);
                galleryContext.SaveChanges();

                galleryContext.Users.Remove(user);
                galleryContext.SaveChanges();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
