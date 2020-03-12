using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Syrname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
    }
}
