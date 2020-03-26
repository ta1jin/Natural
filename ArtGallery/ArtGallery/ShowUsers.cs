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
        GalleryContext gContext = new GalleryContext();
        public ShowUsers()
        {
            InitializeComponent();
            usersData.DataSource = gContext.Employees.ToList();
        }

        private void usersData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            addUsers AddUser = new addUsers();
            AddUser.Show();
        }

        private void editUser_Click(object sender, EventArgs e)
        {
            if (usersData.SelectedRows.Count > 0)
            {
                int index = usersData.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(usersData[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                EditUsers edituser = new EditUsers(id);
                edituser.Show();
            }
        }
    }
}
