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
    public partial class AddUsers : Form
    {
        GalleryContext gc = new GalleryContext();
        public AddUsers()
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
            if (SurnameText.Text == "" || nameText.Text == "" || patronymicText.Text == "" || dateTime.Text == "" || accessComboBox.Text == "" || loginText.Text == "" || passwordText.Text == "" || positionText.Text == "")
            {
                if (SurnameText.Text == "") SurnameText.BackColor = Color.LightCoral;
                else SurnameText.BackColor = Color.White;
                if (nameText.Text == "") nameText.BackColor = Color.LightCoral;
                else nameText.BackColor = Color.White;
                if (patronymicText.Text == "") patronymicText.BackColor = Color.LightCoral;
                else patronymicText.BackColor = Color.White;
                if (dateTime.Text == "") dateTime.BackColor = Color.LightCoral;
                else dateTime.BackColor = Color.White;
                if (accessComboBox.Text == "") accessComboBox.BackColor = Color.LightCoral;
                else accessComboBox.BackColor = Color.White;
                if (loginText.Text == "") loginText.BackColor = Color.LightCoral;
                else loginText.BackColor = Color.White;
                if (passwordText.Text == "") passwordText.BackColor = Color.LightCoral;
                else passwordText.BackColor = Color.White;
                if (positionText.Text == "") positionText.BackColor = Color.LightCoral;
                else positionText.BackColor = Color.White;
            }
            else
            {
                //Employee employee = new Employee();

                //employee.Surname = SurnameText.Text;
                //employee.Name = nameText.Text;
                //employee.Patronymic = patronymicText.Text;
                //employee.Birthday = dateTime.Value;
                //employee.Access = (Access)accessComboBox.SelectedIndex;
                //employee.Login = loginText.Text;
                //employee.Password = passwordText.Text;
                //employee.Position = positionText.Text;
                //employee.Gallery = gallery.First();
                //gc.Employees.Add(employee);
                //gc.SaveChanges();
                //this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addUsers_Load(object sender, EventArgs e)
        {

        }
    }
}
