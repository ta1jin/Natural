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

            Employee employer = new Employee();
            employer.Surname = SurnameText.Text;
            employer.Name = nameText.Text;
            employer.Patronymic = patronymicText.Text;
            employer.Birthday = dateTime.Value;
            employer.Access = (Access)accessComboBox.SelectedIndex;
            employer.Login = loginText.Text;
            employer.Password = passwordText.Text;
            gc.Employees.Add(employer);
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
