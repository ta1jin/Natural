using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.ForTheLazy
{
    class AddExpositions
    {
        public static void Fill(GalleryContext galleryContext)
        {
            if (!galleryContext.Expositions.Any())
            {
                var gallery = galleryContext.Gallerys.First();
                var showrooms = galleryContext.Showrooms.ToList();
                var paintings = galleryContext.Paintings.ToList();

                Exposition exposition1 = new Exposition
                {
                    Name = "expo1",
                    Status = ExpositionStatus.Scheduled,
                    StartDate = new DateTime(2020, 05, 18, 12, 00, 00),
                    EndDate = new DateTime(2020, 05, 22, 18, 00, 00),
                    Showroom = showrooms.First(sh => sh.Title == "Зал №1"),
                    Gallery = gallery,
                    Paintings = paintings,
                };
                Exposition exposition2 = new Exposition
                {
                    Name = "expo2",
                    Status = ExpositionStatus.Scheduled,
                    StartDate = new DateTime(2020, 05, 25, 12, 00, 00),
                    EndDate = new DateTime(2020, 05, 29, 18, 00, 00),
                    Showroom = showrooms.First(sh => sh.Title == "Зал №1"),
                    Gallery = gallery,
                    Paintings = paintings
                };
                Exposition exposition3 = new Exposition
                {
                    Name = "expo3",
                    Status = ExpositionStatus.Scheduled,
                    StartDate = new DateTime(2020, 06, 1, 12, 00, 00),
                    EndDate = new DateTime(2020, 06, 5, 18, 00, 00),
                    Showroom = showrooms.First(sh => sh.Title == "Зал №2"),
                    Gallery = gallery,
                    Paintings = paintings
                };
                Exposition exposition4 = new Exposition
                {
                    Name = "expo4",
                    Status = ExpositionStatus.Scheduled,
                    StartDate = new DateTime(2020, 06, 8, 12, 00, 00),
                    EndDate = new DateTime(2020, 06, 12, 18, 00, 00),
                    Showroom = showrooms.First(sh => sh.Title == "Зал №2"),
                    Gallery = gallery,
                    Paintings = paintings
                };

                galleryContext.Expositions.AddRange(new List<Exposition> { exposition1, exposition2, exposition3, exposition4 });
                galleryContext.SaveChanges();
                StatusChecker.CheckExpositionsForStatus(galleryContext);
            }
        }
    }
}
