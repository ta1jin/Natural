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
            refreshList();
        }

        private void refreshList()
        {
            galleryContext = new GalleryContext();
            List<Employee> employees = galleryContext.Employees.ToList();
            FillDataGrid(employees);
            SetWidth();
        }

        private void FillDataGrid(List<Employee> employees)
        {
            DataTable dataTable = new DataTable();
            dataTable.Reset();

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Имя", typeof(string));
            dataTable.Columns.Add("Отчество", typeof(string));
            dataTable.Columns.Add("Фамилия", typeof(string));
            dataTable.Columns.Add("e-mail", typeof(string));
            dataTable.Columns.Add("Должность", typeof(string));
            dataTable.Columns.Add("Дата рождения", typeof(DateTime));
            dataTable.Columns.Add("Галерея", typeof(string));

            if (galleryContext.Employees.Any())
            {
                foreach (Employee empl in employees)
                {
                    var Position = galleryContext.Positions.Find(empl.PositionId);
                    var Gallery = galleryContext.Gallerys.Find(empl.GalleryId);

                    DataRow dataRow;
                    dataRow = dataTable.NewRow();
                    dataRow["Id"] = empl.Id;
                    dataRow["Фамилия"] = empl.Surname;
                    dataRow["Имя"] = empl.Name;
                    dataRow["Отчество"] = empl.Patronymic;
                    dataRow["e-mail"] = empl.User.Email;
                    dataRow["Должность"] = Position.Name;
                    dataRow["Дата рождения"] = empl.Birthday;
                    dataRow["Галерея"] = Gallery.Title;

                    dataTable.Rows.Add(dataRow);
                }
            }

            dataGridView1.Refresh();
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void SetWidth()
        {
            double gridViewWidth = dataGridView1.Width - 45;

            dataGridView1.Columns[1].Width = nwidth(110, 15);
            dataGridView1.Columns[2].Width = nwidth(110, 15);
            dataGridView1.Columns[3].Width = nwidth(110, 15);
            dataGridView1.Columns[4].Width = nwidth(120, 15);
            dataGridView1.Columns[5].Width = nwidth(160, 20);
            dataGridView1.Columns[6].Width = nwidth(68, 10);
            dataGridView1.Columns[7].Width = nwidth(92, 10);

            int columnsWidth
                = dataGridView1.Columns[1].Width
                + dataGridView1.Columns[2].Width
                + dataGridView1.Columns[3].Width
                + dataGridView1.Columns[4].Width
                + dataGridView1.Columns[5].Width
                + dataGridView1.Columns[6].Width
                + dataGridView1.Columns[7].Width;

            int www = dataGridView1.Columns[1].Width + (int)(gridViewWidth - columnsWidth);
            dataGridView1.Columns[1].Width = (110 - www) > 0 ? 110 : www;

            int nwidth(int minWidth, int percentage)
            {
                return (minWidth - Convert.ToInt32(gridViewWidth / 100 * percentage)) > 0
                    ? minWidth : Convert.ToInt32(gridViewWidth / 100 * percentage);
            }
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

        private void ShowUsers_SizeChanged(object sender, EventArgs e)
        {
            SetWidth();
        }
    }
}
