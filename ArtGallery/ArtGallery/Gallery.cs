using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public long HotLine { get; set; }
        public string Info { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Painting> Paintings { get; set; }      
        public ICollection<Exposition> Expositions { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
