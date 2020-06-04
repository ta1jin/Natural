using ArtGallery.NecessaryTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtGallery
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (GalleryContext galleryContext = new GalleryContext())
            {
                if (!galleryContext.Gallerys.Any())
                {
                    Gallery gallery = new Gallery();
                    gallery.Email = "gallery@natural.ru";
                    gallery.HotLine = "+79963153651";
                    gallery.Info = "Только натуральные картины написанные натуралами(но это не точно)";
                    gallery.Title = "Natural Gallery";
                    galleryContext.Gallerys.Add(gallery);

                    galleryContext.SaveChanges();

                    FillDatabase fillDB = new FillDatabase();
                    fillDB.Fill(galleryContext);
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
