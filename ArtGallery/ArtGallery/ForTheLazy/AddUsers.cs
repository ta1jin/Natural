using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ArtGallery.ForTheLazy
{
    class AddUsers
    {
        public static void Fill(GalleryContext galleryContext)
        {
            if (!galleryContext.Users.Any())
            {
                CultureInfo culture = new CultureInfo("ru-RU");
                var gallery = galleryContext.Gallerys.First();
                var positions = galleryContext.Positions.ToList();

                User user1 = new User
                {
                    Access = Access.Admin,
                    Email = "admin@natural.ru",
                    Login = "admin",
                    Password = "admin"
                };
                User user2 = new User
                {
                    Access = Access.User,
                    Email = "director@natural.ru",
                    Login = "director",
                    Password = "1234"
                };
                User user3 = new User
                {
                    Access = Access.User,
                    Email = "manager@natural.ru",
                    Login = "manager",
                    Password = "1234"
                };
                User user4 = new User
                {
                    Access = Access.User,
                    Email = "restorer@natural.ru",
                    Login = "manager",
                    Password = "1234"
                };

                galleryContext.Users.AddRange(new List<User> { user1, user2, user3, user4 });
                galleryContext.SaveChanges();

                Employee employee1 = new Employee
                {
                    Id = user1.Id,
                    Surname = "Кузнецов",
                    Name = "Прохор",
                    Patronymic = "Адольфович",
                    Birthday = Convert.ToDateTime("12.07.1999", culture),
                    Position = positions.First(pos => pos.Name == "Системный Администратор"),
                    Gallery = gallery
                };
                Employee employee2 = new Employee
                {
                    Id = user2.Id,
                    Surname = "Беляков",
                    Name = "Ермолай",
                    Patronymic = "Федосеевич",
                    Birthday = Convert.ToDateTime("25.05.1989", culture),
                    Position = positions.First(pos => pos.Name == "Директор"),
                    Gallery = gallery
                };
                Employee employee3 = new Employee
                {
                    Id = user3.Id,
                    Surname = "Авдеев",
                    Name = "Оскар",
                    Patronymic = "Богданович",
                    Birthday = Convert.ToDateTime("18.09.1994", culture),
                    Position = positions.First(pos => pos.Name == "Менеджер"),
                    Gallery = gallery
                };
                Employee employee4 = new Employee
                {
                    Id = user4.Id,
                    Surname = "Корнилов",
                    Name = "Августин",
                    Patronymic = "Андреевич",
                    Birthday = Convert.ToDateTime("02.03.1982", culture),
                    Position = positions.First(pos => pos.Name == "Реставратор"),
                    Gallery = gallery
                };

                galleryContext.Employees.AddRange(new List<Employee> { employee1, employee2, employee3, employee4 });
                galleryContext.SaveChanges();
            }
        }
    }
}
