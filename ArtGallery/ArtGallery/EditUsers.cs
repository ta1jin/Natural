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
    public partial class EditUsers : Form
    {
        private int _id;
        public EditUsers(int id)
        {
            InitializeComponent();
            //string[] access = System.Enum.GetNames(typeof(Access));
            //accessComboBox.Items.AddRange(access);
            //_id = id;
            //using (var gc = new GalleryContext())
            //{
            //    var Employee = gc.Employees.First(x => x.Id == id);
            //    nameText.Text = Employee.Name;
            //    surnameText.Text = Employee.Surname;
            //    patronymicText.Text = Employee.Patronymic;
            //    dateTime.Value = Employee.Birthday;
            //    accessComboBox.SelectedItem = Employee.Access;
            //    loginText.Text = Employee.Login;
            //    passwordText.Text = Employee.Password;
            //    positionText.Text = Employee.Position;
                
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //using (var gc = new GalleryContext())
            //{
            //    if (surnameText.Text == "" || nameText.Text == "" || patronymicText.Text == "" || dateTime.Text == "" || accessComboBox.Text == "" || loginText.Text == "" || passwordText.Text == "" || positionText.Text == "")
            //    {
            //        if (surnameText.Text == "") surnameText.BackColor = Color.LightCoral;
            //        else surnameText.BackColor = Color.White;
            //        if (nameText.Text == "") nameText.BackColor = Color.LightCoral;
            //        else nameText.BackColor = Color.White;
            //        if (patronymicText.Text == "") patronymicText.BackColor = Color.LightCoral;
            //        else patronymicText.BackColor = Color.White;
            //        if (dateTime.Text == "") dateTime.BackColor = Color.LightCoral;
            //        else dateTime.BackColor = Color.White;
            //        if (accessComboBox.Text == "") accessComboBox.BackColor = Color.LightCoral;
            //        else accessComboBox.BackColor = Color.White;
            //        if (loginText.Text == "") loginText.BackColor = Color.LightCoral;
            //        else loginText.BackColor = Color.White;
            //        if (passwordText.Text == "") passwordText.BackColor = Color.LightCoral;
            //        else passwordText.BackColor = Color.White;
            //        if (positionText.Text == "") positionText.BackColor = Color.LightCoral;
            //        else positionText.BackColor = Color.White;
            //    }
            //    else
            //    {
            //        var Employee = gc.Employees.First(x => x.Id == _id);
            //        Employee.Surname = surnameText.Text;
            //        Employee.Name = nameText.Text;
            //        Employee.Patronymic = patronymicText.Text;
            //        Employee.Birthday = dateTime.Value;
            //        Employee.Access = (Access)accessComboBox.SelectedIndex;
            //        Employee.Login = loginText.Text;
            //        Employee.Password = passwordText.Text;
            //        Employee.Position = positionText.Text;
            //        gc.SaveChanges();
            //        this.Close();
            //    }
            //}
        }
    }
}
