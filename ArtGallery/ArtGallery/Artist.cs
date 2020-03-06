using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery
{
    public class Artist : Person
    {
        public DateTime DateOfDeath { get; set; }
        public string Biography { get; set; }
    }
}
