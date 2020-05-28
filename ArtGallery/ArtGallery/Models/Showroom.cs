using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery
{
    public class Showroom
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public ICollection<Exposition> Expositions { get; set; }
        public int GalleryId { get; set; }
        [ForeignKey("GalleryId")]
        public virtual Gallery Gallery { get; set; }
    }
}
