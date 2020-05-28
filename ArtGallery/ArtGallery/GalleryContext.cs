using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;


namespace ArtGallery
{
    public class GalleryContext : DbContext
{
        public GalleryContext()
            : base("ConString")
    {
    }
        public virtual DbSet<Painting> Paintings { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<PaintingTechnique> PaintingTechniques { get; set; }
        public virtual DbSet<Gallery> Gallerys { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Showroom> Showrooms { get; set; }
        public virtual DbSet<Exposition> Expositions { get; set; }
        public virtual DbSet<PaintingMovement> PaintingMovement { get; set; }
        public virtual DbSet<PaintingMovementJournal> PaintingMovementJournals { get; set; }
    }
}
