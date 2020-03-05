using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ArtGallery
{
    enum state { Otlichnoe, TrebuetRestavracii, Util }
    enum status { NaRestavracii, NaExposicii, NaSklade }
    enum Genre {a,b,c}
    enum PaintingTehnique {a,b,c }
    class Painting
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist Artist { get; set; }      
        public Genre Genre { get; set; }
        public PaintingTehnique PaintingTehnique { get; set; }
        public DateTime DateOfPainting { get; set; }
        public double Price { get; set; }
        public state State { get; set; }
        public status Status { get; set; }
        public ICollection<Report> Reports { get; set; }

    }
}
