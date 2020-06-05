using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery
{
    public class Artist : Person
    {
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName = "datetime2")]
        public DateTime DateOfDeath { get; set; }
        public string Biography { get; set; }
        public ICollection<Painting> Paintings { get; set; }
    }
}
