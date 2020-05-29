using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery
{
    class StatusChecker
    {
        private static DateTime now;
        public static void AutoCheck()
        {
            // . . .
        }

        public static void CheckPaintingsForStatus(GalleryContext galleryContext)
        {
            if (galleryContext.Paintings.Any())
            {
                List<Painting> paintings = galleryContext.Paintings.ToList();
                now = DateTime.Now.Subtract(new TimeSpan(0, 0, DateTime.Now.Second));
                foreach (Painting painting in paintings)
                {
                    if (painting.Status != status.NaRestavracii)
                    {
                        galleryContext.Entry(painting).Collection(p => p.Expositions).Load();
                        bool isOnExpo = false;
                        foreach (Exposition exposition in painting.Expositions)
                        {
                            if (exposition.Status == ExpositionStatus.Cancelled)
                            {
                                isOnExpo = false;
                            }
                            else if (DateTime.Now.CompareTo(exposition.StartDate) >= 0
                                    && DateTime.Now.CompareTo(exposition.EndDate) <= 0)
                            {
                                isOnExpo = true;
                            }
                        }
                        if (isOnExpo)
                        {
                            painting.Status = status.NaExposicii;
                        }
                        else
                        {
                            painting.Status = status.NaSklade;
                        }
                        galleryContext.Entry(painting).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                galleryContext.SaveChanges();
            }
        }

        public static void CheckExpositionsForStatus(GalleryContext galleryContext)
        {
            if (galleryContext.Expositions.Any())
            {
                List<Exposition> expositions = galleryContext.Expositions.ToList();
                now = DateTime.Now.Subtract(new TimeSpan(0, 0, DateTime.Now.Second));
                foreach (Exposition exposition in expositions)
                {
                    if (exposition.Status != ExpositionStatus.Cancelled)
                    {
                        if (DateTime.Now.CompareTo(exposition.StartDate) >= 0
                           && DateTime.Now.CompareTo(exposition.EndDate) <= 0)
                        {
                            exposition.Status = ExpositionStatus.Active;
                        }
                        else if (DateTime.Now.CompareTo(exposition.StartDate) < 0)
                        {
                            exposition.Status = ExpositionStatus.Scheduled;
                        }
                        else if (DateTime.Now.CompareTo(exposition.StartDate) > 0)
                        {
                            exposition.Status = ExpositionStatus.Cancelled;
                        }
                        galleryContext.Entry(exposition).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                galleryContext.SaveChanges();
            }
        }
    }
}
