﻿using System;
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
        GalleryContext gContext = new GalleryContext();
        public ShowUsers()
        {
            InitializeComponent();
            usersData.DataSource = gContext.Employees.ToList();
            usersData.Columns["GalleryId"].Visible = false;
            usersData.Columns["Gallery"].Visible = false;
            usersData.Columns["Position"].Visible = false;
            usersData.Columns["Reports"].Visible = false;
        }

        private void usersData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            AddUsers AddUser = new AddUsers();
            
            AddUser.ShowDialog();
        }

        private void editUser_Click(object sender, EventArgs e)
        {
            if (usersData.SelectedRows.Count > 0)
            {
                int index = usersData.SelectedRows[0].Index;
                int id=0;
                bool converted = Int32.TryParse(usersData["Id", index].Value.ToString(), out id);
                if (converted == false)
                    return;
                EditUsers edituser = new EditUsers(id);
                edituser.ShowDialog();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            using (GalleryContext gc = new GalleryContext())
            {
                usersData.DataSource = gContext.Employees.ToList();
            }
        }

        private void deleteUser_Click(object sender, EventArgs e)
        {
            using (GalleryContext gc = new GalleryContext())
            {
                if (usersData.SelectedRows.Count > 0)
                {
                    int index = usersData.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(usersData["Id", index].Value.ToString(), out id);
                    if (converted == false)
                        return;
                    Employee employee = gc.Employees.Where(w => w.Id == id).FirstOrDefault();
                    gc.Employees.Remove(employee);
                    gc.SaveChanges();
                }
            }
        }

     private void ShowUsers_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.F1)
            {
                MessageBox.Show("Combination pressed");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gallery = from g in gContext.Gallerys
                          select g;
            Employee employee = new Employee();
            employee.Surname = "Добрынин";
            employee.Name = "Никита";
            employee.Patronymic = "Сергеевич";
            employee.Login = "Admin";
            employee.Password = "Admin";
            employee.Position = "Admin";
            employee.Gallery = gallery.First();
            gContext.Employees.Add(employee);
            gContext.SaveChanges();
            this.Close();
        }
    }
}
