using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.NecessaryTables
{
    class AddShowrooms
    {
        public static void Fill(GalleryContext galleryContext)
        {
            if (!galleryContext.Showrooms.Any())
            {
                var gallery = galleryContext.Gallerys.First();

                Showroom sh1 = new Showroom
                {
                    Title = "Зал №1",
                    Location = "Первый этаж",
                    Gallery = gallery
                };
                Showroom sh2 = new Showroom
                {
                    Title = "Зал №2",
                    Location = "Второй этаж",
                    Gallery = gallery
                };
                galleryContext.Showrooms.AddRange(new List<Showroom> { sh1, sh2 });
                galleryContext.SaveChanges();
            }
        }
    }
}
