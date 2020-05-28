using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.NecessaryTables
{
    class FillDatabase
    {
        public void Fill(GalleryContext galleryContext)
        {
            if (galleryContext != null)
            {
                AddGenres.Fill(galleryContext);
                AddPaintingTechniques.Fill(galleryContext);
                AddArtists.Fill(galleryContext);
                AddShowrooms.Fill(galleryContext);
                AddPositions.Fill(galleryContext);
            }
        }
    }
}
