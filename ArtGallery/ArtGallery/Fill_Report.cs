using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery
{
    class Fill_Report
    {

        public void fill()
        {
			GalleryContext gc = new GalleryContext();

			Report rep = new Report();
			rep.Id = "количество всех репортов+1";
			rep.Title = "заголовок отчета,  который пишет менеджер при заполнении";
			rep.Description = "содержание отчета, который пишет менеджер при заполнении"
			rep.ReportDate = DateTime.Now;
			rep.EmployeeId = "берется айди залогинившегося менеджера";
			rep.PaintingId = "сюда пойдут айди картин, которые выбрал менеджер";
			rep.GalleryId = "сюда идет айди галереи, к которой привязан менеджер";

			gc.Reports.Add(rep);

			gc.SaveChanges();



		}
    }
}
