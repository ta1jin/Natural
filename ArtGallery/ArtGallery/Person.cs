using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery
{
    class Person
    {
        [Key]
        public int Id { get; set; }
        public int GalleryId { get; set; }
        [ForeignKey("GalleryId")]
        public virtual Gallery Gallery { get; set; }
        public string Name { get; set; }
        public string Syrname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
    }
}
