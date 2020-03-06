using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReportDate { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        public int PaintingId { get; set; }
        [ForeignKey("PaintingId")]
        public virtual Painting Painting { get; set; }
        public int GalleryId { get; set; }
        [ForeignKey("GalleryId")]
        public virtual Gallery Gallery { get; set; }

    }
}
