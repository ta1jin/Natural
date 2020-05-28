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
        public static void CreatePaintingMovement(string Description, bool GoingToRestoration, bool GoingToExposition, bool Discarded, bool GoingFromRestoration, bool GoingFromExposition, int EmployeeId, int GalleryId, Painting inPainting, string NameAfterMovement, double PriceAfterMovement, state StateAfterMovement,  DateTime DateOfPaintingAfterMovement, Report AdditionalReport, Exposition AdditionalExposition ) 
        {
            
            PaintingMovement newPaintingMovement = new PaintingMovement(); 

            //TODO как ID поставить максимальный ID + 1
            //TODO DateOfRecord определять внутри функции
            GalleryContext gc = new GalleryContext();
            var painting = from p in gc.Paintings
                            where p.Id == inPainting.Id
                             select p;

            //Id
            //DateOfRecord
            newPaintingMovement.Description = Description;
            newPaintingMovement.GoingToRestoration = GoingToRestoration;
            newPaintingMovement.GoingToExposition = GoingToExposition;
            newPaintingMovement.GoingFromRestoration = GoingFromRestoration;
            newPaintingMovement.GoingFromExposition = GoingFromExposition;
            newPaintingMovement.Discarded = Discarded;
            newPaintingMovement.EmployeeId = EmployeeId;
            //Employee найти по айди
            newPaintingMovement.GalleryId = GalleryId;
            //Gallery тож найти по айди
            //PaintingId
            //Painting
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
