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
    public partial class addUsers : Form
    {
        GalleryContext gc = new GalleryContext();
        public addUsers()
        {
            InitializeComponent();
            string[] access = System.Enum.GetNames(typeof(Access));
            accessComboBox.Items.AddRange(access);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gallery = from g in gc.Gallerys
                          select g;



            Employee employee = new Employee();
            employee.Surname = SurnameText.Text;
            employee.Name = nameText.Text;
            employee.Patronymic = patronymicText.Text;
            employee.Birthday = dateTime.Value;
            employee.Access = (Access)accessComboBox.SelectedIndex;
            employee.Login = loginText.Text;
            employee.Password = passwordText.Text;
            employee.Position = positionText.Text;
            employee.Gallery = gallery.First();
            gc.Employees.Add(employee);
            gc.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addUsers_Load(object sender, EventArgs e)
        {

        }
    }
}
