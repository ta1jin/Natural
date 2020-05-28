using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ArtGallery.ForTheLazy
{
    class AddPaintings
    {
        public static void Fill(GalleryContext galleryContext)
        {
            if (!galleryContext.Paintings.Any())
            {
                CultureInfo culture = new CultureInfo("ru-RU");
                var gallery = galleryContext.Gallerys.First();
                var artists = galleryContext.Artists.ToList();
                var genres = galleryContext.Genres.ToList();
                var paintingTechniques = galleryContext.PaintingTechniques.ToList();

                Painting painting1 = new Painting
                {
                    Name = "painting1",
                    State= state.Otlichnoe,
                    Artist = artists.First(a => a.Name == "Иван"),
                    Genre = genres.First(g => g.Name == "protret"),
                    PaintingTechnique = paintingTechniques.First(p => p.Name == "Лессировка"),
                    DateOfPainting = Convert.ToDateTime("15.12.1880", culture),
                    Price = Convert.ToDouble(9000),
                    Status = status.NaSklade,
                    Gallery = gallery
                };
                Painting painting2 = new Painting
                {
                    Name = "painting2",
                    State= state.Otlichnoe,
                    Artist = artists.First(a => a.Name == "Иван"),
                    Genre = genres.First(g => g.Name == "protret"),
                    PaintingTechnique = paintingTechniques.First(p => p.Name == "Лессировка"),
                    DateOfPainting = Convert.ToDateTime("21.08.1890", culture),
                    Price = Convert.ToDouble(9000),
                    Status = status.NaSklade,
                    Gallery = gallery
                };
                Painting painting3 = new Painting
                {
                    Name = "painting3",
                    State= state.Otlichnoe,
                    Artist = artists.First(a => a.Name == "Сергей"),
                    Genre = genres.First(g => g.Name == "natyurmort"),
                    PaintingTechnique = paintingTechniques.First(p => p.Name == "Мазковая техника живописи"),
                    DateOfPainting = Convert.ToDateTime("19.10.1960", culture),
                    Price = Convert.ToDouble(9000),
                    Status = status.NaSklade,
                    Gallery = gallery
                };
                Painting painting4 = new Painting
                {
                    Name = "painting4",
                    State= state.Otlichnoe,
                    Artist = artists.First(a => a.Name == "Сергей"),
                    Genre = genres.First(g => g.Name == "natyurmort"),
                    PaintingTechnique = paintingTechniques.First(p => p.Name == "Мазковая техника живописи"),
                    DateOfPainting = Convert.ToDateTime("07.06.1970", culture),
                    Price = Convert.ToDouble(9000),
                    Status = status.NaSklade,
                    Gallery = gallery
                };

                galleryContext.Paintings.AddRange(new List<Painting> { painting1, painting2, painting3, painting4 });
                galleryContext.SaveChanges();
                StatusChecker.CheckPaintingsForStatus(galleryContext);
            }
        }
    }
}
