using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery
{
    public enum Access { Admin, Director, Manager, Repairman}
    public class Employee : Person
    {
        public int GalleryId { get; set; }
        [ForeignKey("GalleryId")]
        public virtual Gallery Gallery { get; set; }
        public string Position { get; set; }
        public ICollection<Report> Reports { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Access Access { get; set; }
        
    }
}
