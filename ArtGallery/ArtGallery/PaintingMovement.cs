using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery
{
    public class PaintingMovement
    {
        //TO DO add to GalleryContext later
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ReportDate { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
      
        [ForeignKey("PaintingId")]
        public ICollection<int> PaintingId { get; set; }
        
    }
}
