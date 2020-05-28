using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.NecessaryTables
{
    class AddArtists
    {
        public static void Fill(GalleryContext galleryContext)
        {
            if (!galleryContext.Artists.Any())
            {
                Artist a1 = new Artist
                {
                    Birthday = new DateTime(1856, 7, 20),
                    DateOfDeath = new DateTime(1901, 1, 23),
                    Biography = "жил да не тужил",
                    Surname = "Иванов",
                    Name = "Иван",
                    Patronymic = "Иванович"
                };
                Artist a2 = new Artist
                {
                    Birthday = new DateTime(1910, 3, 11),
                    DateOfDeath = new DateTime(1985, 2, 2),
                    Biography = "жил да не тужил",
                    Surname = "Сергеев",
                    Name = "Сергей",
                    Patronymic = "Сергеевич"
                };
                galleryContext.Artists.AddRange(new List<Artist> { a1, a2 });
                galleryContext.SaveChanges();
            }
        }
    }
}
