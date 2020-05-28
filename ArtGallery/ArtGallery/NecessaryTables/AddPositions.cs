using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.NecessaryTables
{
    class AddPositions
    {
        public static void Fill(GalleryContext galleryContext)
        {
            if (!galleryContext.Positions.Any())
            {
                Position p1 = new Position { Name = "Директор" };
                Position p2 = new Position { Name = "Менеджер" };
                Position p3 = new Position { Name = "Системный Администратор" };
                Position p4 = new Position { Name = "Реставратор" };
                galleryContext.Positions.AddRange(new List<Position> { p1, p2, p3, p4 });
                galleryContext.SaveChanges();
            }
        }
    }
}
