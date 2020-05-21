using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.NecessaryTables
{
    class FillDatabase
    {
        public void Fill()
        {
            AddGenres.Fill();
            AddPaintingTechniques.Fill();
            AddArtists.Fill();
        }
    }
}
