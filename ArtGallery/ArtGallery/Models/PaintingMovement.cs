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
        [Key]
        public int Id { get; set; }
        public DateTime DateOfRecord { get; set; }
        public string Description { get; set; }

        public bool GoingToRestoration { get; set; }
        public bool GoingToExposition { get; set; }
        
        public bool GoingFromRestoration { get; set; }
        public bool GoingFromExposition { get; set; }

        public bool Discarded { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public int GalleryId { get; set; }
        [ForeignKey("GalleryId")]
        public virtual Gallery Gallery { get; set; }

        public int PaintingId { get; set; }
        [ForeignKey("PaintingId")]
        public Painting Painting { get; set; }

        //может ли ID меняться? если когда-то будет, добавить сюда и изменения Id картин
        public string NameBeforeMovement { get; set; }
        public string NameAfterMovement { get; set; }

        //public int ArtistIdBeforeMovement { get; set; }
        //[ForeignKey("ArtistId")]
        //public virtual Artist ArtistBeforeMovement { get; set; }

        //public int ArtistIdAfterMovement { get; set; }
        //[ForeignKey("ArtistId")]
        //public virtual Artist ArtistAfterMovement { get; set; }



        //public int GenreIdBeforeMovement { get; set; }
        //[ForeignKey("GenreId")]
        //public int GenreIdAfterMovement { get; set; }
        //[ForeignKey("GenreId")]
        //public virtual Genre GenreBeforeMovement { get; set; }
        //public virtual Genre GenreAfterMovement { get; set; }
        //public int PaintingTehniqueIdBeforeMovement { get; set; }
        //[ForeignKey("PaintingTehniqueId")]
        //public virtual PaintingTechnique PaintingTechniqueBeforeMovement { get; set; }
        //public int PaintingTehniqueIdAfterMovement { get; set; }
        //[ForeignKey("PaintingTehniqueId")]
        //public virtual PaintingTechnique PaintingTechniqueAfterMovement { get; set; }
        
        //будет ли у нас несколько Gallery? если да, добавить галереюИд до и галереюИд после изменений
        public DateTime DateOfPaintingBeforeMovement { get; set; }
        public DateTime DateOfPaintingAfterMovement { get; set; }
        public double PriceBeforeMovement { get; set; }
        public double PriceAfterMovement { get; set; }
        public state StateBeforeMovement { get; set; }
        public state StateAfterMovement { get; set; }
        public status StatusBeforeMovement { get; set; }
        public status StatusAfterMovement { get; set; }
        public ICollection<Report> ReportsBeforeMovement { get; set; }
        public ICollection<Report> ReportsAfterMovement { get; set; }
        public ICollection<Exposition> ExpositionsBeforeMovement { get; set; }
        public ICollection<Exposition> ExpositionsAfterMovement { get; set; }

    }
}
