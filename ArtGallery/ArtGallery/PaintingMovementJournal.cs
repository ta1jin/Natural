using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery
{
    public class PaintingMovementJournal
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfRecord { get; set; }
        public string Description { get; set; }

        public bool GoingToRestoration { get; set; }
        public bool GoingToExposition { get; set; }

        public bool GoingFromRestoration { get; set; }
        public bool GoingFromExposition { get; set; }
        
        public bool Discarded { get; set; }

        //public int FromGalleryId { get; set; }
        //[ForeignKey("FromGalleryId")]
        // public virtual FromGallery FromGallery { get; set; }

        // public int ToGalleryId { get; set; }
        // [ForeignKey("ToGalleryId")]
        // public virtual ToGallery ToGallery { get; set; }


        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public int GalleryId { get; set; }
        [ForeignKey("GalleryId")]
        public virtual Gallery Gallery { get; set; }


        public ICollection<Painting> Paintings { get; set; }
    }

    


    /* public class FromGallery
     {
         [Key]
         public int Id { get; set; }

         public int GalleryId { get; set; }
         [ForeignKey("GalleryId")]
         public virtual Gallery Gallery { get; set; }

     }

     public class ToGallery
     {
         [Key]
         public int Id { get; set; }

         public int GalleryId { get; set; }
         [ForeignKey("GalleryId")]
         public virtual Gallery Gallery { get; set; }
     }*/
}
