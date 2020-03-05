﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery
{
    class Report
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReportDate { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmplyeeId")]
        public virtual Employee Employee { get; set; }
        public int PaintingId { get; set; }
        [ForeignKey("PaintingId")]
        public virtual Painting Painting { get; set; }


    }
}
