﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery
{
    public class Employee : Person
    {
        public string Position { get; set; }
        public ICollection<Report> Reports { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Access { get; set; }
    }
}
