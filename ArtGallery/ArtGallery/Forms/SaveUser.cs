using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ArtGallery
{
    public partial class SaveUser : Form
    {
        private Mode mode;
        private int userID = 0;
        public GalleryContext galleryContext { get; set; }
        public Employee employee { get; set; }
        public SaveUser()
        {
            InitializeComponent();
        }

        private void SaveUser_Load(object sender, EventArgs e)
        {
            GetData();

            if (employee == null)
            {
                mode = Mode.Insert;
            }
            else
            {
                mode = Mode.Update;
                userID = employee.Id;
                surnameTextBox.Text = employee.Surname;
                nameTextBox.Text = employee.Name;
                patronimycTextBox.Text = employee.Patronymic;
                birthdayMaskedTextBox.Text = employee.Birthday.ToString();
                positionsComboBox.SelectedItem = employee.Position.Name;

                User user = galleryContext.Users.Find(userID);
                accessComboBox.SelectedItem = user.Access.ToString();
                emailTextBox.Text = user.Email;
                loginTextBox.Text = user.Login;
                passwordTextBox.Text = user.Password;
            }
        }

        private void GetData()
        {
            string[] access = Enum.GetNames(typeof(Access));
            accessComboBox.Items.AddRange(access);

            var positions = from p in galleryContext.Positions
                            select p.Name;
            positionsComboBox.Items.AddRange(positions.ToArray());
        }

        private bool CheckControls()
        {
            int result = 0;
            bool allRight = false;
            Regex emailRegex = new Regex(@"^([a-z0-9]+([-_][a-z0-9]+)*)@(([a-z0-9]+(-[a-z0-9]+)*)\.)+[a-z]+$");
            Regex birthdayRegex = new Regex(@"\d\d\.\d\d\.\d\d\d\d");
            Regex nameRegex = new Regex(@"^[А-ЯЁ][а-яё]*$");
            Regex loginRegex = new Regex(@"^([a-z0-9])+(_([a-z0-9])+)*$");

            if (surnameTextBox.Text == "" || nameTextBox.Text == "" || patronimycTextBox.Text == ""
                || !birthdayRegex.IsMatch(birthdayMaskedTextBox.Text)
                || accessComboBox.SelectedItem == null || positionsComboBox.SelectedItem == null
                || emailTextBox.Text == "" || loginTextBox.Text == ""
                || passwordTextBox.Text == "" || confirmPasswordTextBox.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
                result++;
            }
            if (surnameTextBox.Text != "" && !nameRegex.IsMatch(surnameTextBox.Text))
            {
                surnameTextBox.BackColor = Color.Tomato;
                result++;
            }
            else
            {
                surnameTextBox.BackColor = Color.White;
            }
            if (nameTextBox.Text != "" && !nameRegex.IsMatch(nameTextBox.Text))
            {
                nameTextBox.BackColor = Color.Tomato;
                result++;
            }
            else
            {
                nameTextBox.BackColor = Color.White;
            }
            if (patronimycTextBox.Text != "" && !nameRegex.IsMatch(patronimycTextBox.Text))
            {
                patronimycTextBox.BackColor = Color.Tomato;
                result++;
            }
            else
            {
                patronimycTextBox.BackColor = Color.White;
            }
            if (loginTextBox.Text != "" && !loginRegex.IsMatch(loginTextBox.Text.ToLower()))
            {
                loginTextBox.BackColor = Color.Tomato;
                result++;
            }
            else
            {
                loginTextBox.BackColor = Color.White;
            }
            if (emailTextBox.Text != "" && !emailRegex.IsMatch(emailTextBox.Text.ToLower()))
            {
                emailTextBox.BackColor = Color.Tomato;
                emailLabel.Text = "Неправильно указан e-mail!";
                result++;
            }
            else
            {
                emailTextBox.BackColor = Color.White;
            }
            if (mode == Mode.Insert && passwordTextBox.Text != "" && passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                passwordTextBox.BackColor = Color.Tomato;
                confirmPasswordTextBox.BackColor = Color.Tomato;
                confirmPasswordLabel.Text = "Пароли не совпадают!";
                result++;
            }
            else
            {
                passwordTextBox.BackColor = Color.White;
                confirmPasswordTextBox.BackColor = Color.White;
            }
            if (result == 0)
            {
                allRight = true;

                emailLabel.Text = "";
                confirmPasswordLabel.Text = "";
            }
            return allRight;
        }

        private void SaveData()
        {
            CultureInfo culture = new CultureInfo("ru-RU");

            var gallery = galleryContext.Gallerys.First();


            var position = from p in galleryContext.Positions
                           where p.Name == positionsComboBox.SelectedItem.ToString()
                           select p;

            if (mode == Mode.Insert)
            {
                User user = new User
                {
                    Access = (Access)accessComboBox.SelectedIndex,
                    Email = emailTextBox.Text,
                    Login = loginTextBox.Text,
                    Password = passwordTextBox.Text
                };
                galleryContext.Users.Add(user);
                galleryContext.SaveChanges();

                Employee employee = new Employee
                {
                    Id = user.Id,
                    Name = nameTextBox.Text,
                    Surname = surnameTextBox.Text,
                    Patronymic = patronimycTextBox.Text,
                    Birthday = Convert.ToDateTime(birthdayMaskedTextBox.Text, culture),
                    Position = position.First(),
                    Gallery = gallery
                };
                galleryContext.Employees.Add(employee);
                galleryContext.SaveChanges();
            }
            else
            {
                User user = galleryContext.Users.Find(userID);
                user.Access = (Access)accessComboBox.SelectedIndex;
                user.Email = emailTextBox.Text;
                user.Login = loginTextBox.Text;
                user.Password = passwordTextBox.Text;
                galleryContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
                galleryContext.SaveChanges();

                Employee employee = galleryContext.Employees.First(empl => empl.User.Login == user.Login);
                employee.Id = user.Id;
                employee.Name = nameTextBox.Text;
                employee.Surname = surnameTextBox.Text;
                employee.Patronymic = patronimycTextBox.Text;
                employee.Birthday = Convert.ToDateTime(birthdayMaskedTextBox.Text, culture);
                employee.Position = position.First();
                employee.Gallery = gallery;
                galleryContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                galleryContext.SaveChanges();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (CheckControls())
            {
                SaveData();
                Close();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
