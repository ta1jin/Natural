using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery
{
    class PaintingsStatusesChecker
    {
        public static void AutoCheck()
        {
            // . . .
        }

        public static void CheckPaintingsForState()
        {
            using (GalleryContext galleryContext = new GalleryContext())
            {
                if (galleryContext.Paintings.Any())
                {
                    List<Painting> paintings = galleryContext.Paintings.ToList();
                    foreach (Painting painting in paintings)
                    {
                        galleryContext.Entry(painting).Collection(p => p.Expositions).Load();
                        bool isOnExpo = false;
                        foreach (Exposition exposition in painting.Expositions)
                        {
                            if ((DateTime.Now.CompareTo(exposition.StartDate.Subtract(new TimeSpan(0, 1, 0))) >= 0
                                && DateTime.Now.CompareTo(exposition.EndDate.Subtract(new TimeSpan(0, 1, 0))) <= 0))
                            {
                                isOnExpo = true;
                            }
                        }
                        if (painting.Status != status.NaRestavracii)
                        {
                            if (isOnExpo)
                            {
                                painting.Status = status.NaExposicii;
                            }
                            else
                            {
                                painting.Status = status.NaSklade;
                            }
                        }
                        galleryContext.Entry(painting).State = System.Data.Entity.EntityState.Modified;
                    }
                    galleryContext.SaveChanges();
                }
            }
        }
    }
}
