using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery
{
    public enum ExpositionStatus
    {
        Scheduled,
        Active,
        Cancelled
    }
    public class Exposition
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ExpositionStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ShowroomId { get; set; }
        [ForeignKey("ShowroomId")]
        public virtual Showroom Showroom { get; set; }
        public int GalleryId { get; set; }
        [ForeignKey("GalleryId")]
        public virtual Gallery Gallery { get; set; }
        public ICollection<Painting> Paintings { get; set; }
    }
}
