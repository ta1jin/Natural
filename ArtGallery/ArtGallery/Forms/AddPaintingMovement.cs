using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtGallery.Forms
{
    public partial class AddPaintingMovement : Form
    {
        public AddPaintingMovement()
        {
            InitializeComponent();
        }

        // =========== < пока что не работает > ==============
        public static void CreatePaintingMovement(string Description, bool GoingToRestoration, bool GoingToExposition, bool Discarded,  bool GoingToSklad, int EmployeeId, int GalleryId, Painting inPainting, string NameAfterMovement, double PriceAfterMovement, state StateAfterMovement,  DateTime DateOfPaintingAfterMovement, Report AdditionalReport, Exposition AdditionalExposition ) 
        {
            
            PaintingMovement newPaintingMovement = new PaintingMovement(); 

            GalleryContext gc = new GalleryContext();
            var paintings = from p in gc.Paintings
                            where p.Id == inPainting.Id
                             select p;

            
            foreach (Painting p in paintings)
            {
                newPaintingMovement.Id = gc.PaintingMovement
                    .Select(i => p.Id).
                    DefaultIfEmpty(0).
                    Max();
                newPaintingMovement.Id = newPaintingMovement.Id + 1;

                newPaintingMovement.DateOfRecord = DateTime.Now;
                newPaintingMovement.PaintingId = p.Id;
                newPaintingMovement.Painting = p;
                newPaintingMovement.StatusBeforeMovement = p.Status;
                newPaintingMovement.StateBeforeMovement = p.State;
                newPaintingMovement.StateAfterMovement = StateAfterMovement;
                if (GoingToExposition)
                {
                    newPaintingMovement.StatusAfterMovement = status.NaExposicii;
                }
                else if (GoingToRestoration)
                {
                    newPaintingMovement.StatusAfterMovement = status.NaRestavracii;
                } else if (GoingToSklad)
                {
                    newPaintingMovement.StatusAfterMovement = status.NaSklade;
                }
                else if (Discarded)
                {
                    newPaintingMovement.Discarded = Discarded;
                }
                
                
                
                
                
            }

            newPaintingMovement.Description = Description;
            newPaintingMovement.GoingToRestoration = GoingToRestoration;
            newPaintingMovement.GoingToExposition = GoingToExposition;
            newPaintingMovement.GoingToSklad = GoingToSklad;
            newPaintingMovement.Discarded = Discarded;

            newPaintingMovement.EmployeeId = EmployeeId;
            var employees = from e in gc.Employees
                            where e.Id == EmployeeId
                            select e;
            foreach (Employee e in employees)
            {
                newPaintingMovement.Employee = e;
            }

            newPaintingMovement.GalleryId = GalleryId;
            var gallerys = from g in gc.Gallerys
                            where g.Id == GalleryId
                           select g;
            foreach (Gallery g in gallerys)
            {
                newPaintingMovement.Gallery = g;
            }

            
            newPaintingMovement.NameBeforeMovement = inPainting.Name;
            newPaintingMovement.NameAfterMovement = NameAfterMovement;
            newPaintingMovement.DateOfPaintingBeforeMovement = inPainting.DateOfPainting;
            newPaintingMovement.DateOfPaintingAfterMovement = DateOfPaintingAfterMovement;
            newPaintingMovement.PriceBeforeMovement = inPainting.Price;
            newPaintingMovement.PriceAfterMovement = PriceAfterMovement;
            newPaintingMovement.StateBeforeMovement = inPainting.State;
            newPaintingMovement.StateAfterMovement = StateAfterMovement;

            //следующие двое будут зависеть от предыдущих булеанов
            //StatusBeforeMovement
            //StatusAfterMovement
            //ReportsBeforeMovement 
            //ReportsAfterMovement  (AdditionalReport)
            //ExpositionsAfterMovement (AdditionalExposition)
            //ExpositionsBeforeMovement
        }

        private void AddPaintingMovement_Load(object sender, EventArgs e)
        {

        }
    }
}
