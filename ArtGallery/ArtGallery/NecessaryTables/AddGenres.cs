using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.NecessaryTables
{
    class AddGenres
    {
        public static void Fill()
        {
            using (GalleryContext galleryContext = new GalleryContext())
            {
                if (!galleryContext.Genres.Any())
                {
                    Genre g1 = new Genre
                    {
                        Name = "protret",
                        Description = "chetko"
                    };
                    Genre g2 = new Genre
                    {
                        Name = "natyurmort",
                        Description = "kruto"
                    };
                    galleryContext.Genres.AddRange(new List<Genre> { g1, g2 });
                    galleryContext.SaveChanges();
                }
            }
        }
    }
}
