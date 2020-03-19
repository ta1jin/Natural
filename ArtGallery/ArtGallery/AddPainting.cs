using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtGallery
{
    
    public partial class AddPainting : Form
    {
        GalleryContext gc = new GalleryContext();
        public AddPainting()
        {   
            InitializeComponent();
            Fill_Database fd = new Fill_Database();
            fd.fill();
            
            var artistNames = from a in gc.Artists                      
                        select a.Name;
            var genresNames = from g in gc.Genres
                              select g.Name;
            var paintingTechniqueNames = from pT in gc.PaintingTechniques
                              select pT.Name;
            
            artistsComboBox.Items.AddRange(artistNames.ToArray());
            genresComboBox.Items.AddRange(genresNames.ToArray());
            paintingTechniqueComboBox.Items.AddRange(paintingTechniqueNames.ToArray());           
            string[] states = System.Enum.GetNames(typeof(state));
            stateComboBox.Items.AddRange(states);
        }

        private void OK_Click(object sender, EventArgs e)
        {
                       
            var artist = from a in gc.Artists
                         where a.Name == artistsComboBox.SelectedItem.ToString()
                         select a;
            var genre = from g in gc.Genres
                         where g.Name == genresComboBox.SelectedItem.ToString()
                         select g;
            var paintingTechinque = from pT in gc.PaintingTechniques
                         where pT.Name == paintingTechniqueComboBox.SelectedItem.ToString()
                         select pT;
            var gallery = from g in gc.Gallerys
                                    select g;



            Painting painting = new Painting();
            painting.Name = paintingName.Text;
            painting.State = (state)stateComboBox.SelectedIndex;
            painting.Artist = artist.First();
            painting.Genre = genre.First();
            painting.PaintingTechnique = paintingTechinque.First();
            painting.DateOfPainting = DateOfPainting.Value;
            painting.Price = Convert.ToDouble(priceTextBox.Text);
            painting.Status = status.NaSklade;
            painting.Gallery = gallery.First();
            gc.Paintings.Add(painting);
            gc.SaveChanges();

        }
    }
}
