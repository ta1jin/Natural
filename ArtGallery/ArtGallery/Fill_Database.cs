using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery
{
	
	class Fill_Database
	{

		public void fill()
		{
			GalleryContext gc = new GalleryContext();
			Artist a = new Artist();
			a.Birthday= new DateTime(2015, 7, 20);
			a.DateOfDeath = new DateTime(2017,1,23);
			a.Biography = "wdwdwdwdwd";
			a.Name = "wdwdwdwdwd";
			a.Surname = "wdwdwdwdwd";
			a.Patronymic = "wdwdwdwdwd";
			gc.Artists.Add(a);

			Artist a1 = new Artist();
			a1.Birthday = new DateTime(2012, 3, 11);
			a1.DateOfDeath = new DateTime(2013, 2, 2);
			a1.Biography = "ababab";
			a1.Name = "ababab";
			a1.Surname = "ababab";
			a1.Patronymic = "ababab";
			gc.Artists.Add(a1);

			Genre g = new Genre();
			g.Name = "protret";
			g.Description = "chetko";
			gc.Genres.Add(g);

			Genre g2 = new Genre();
			g2.Name = "natyurmort";
			g2.Description = "kruto";
			gc.Genres.Add(g2);

			PaintingTechnique pt = new PaintingTechnique();
			pt.Name = "Лессировка";
			pt.Description = "Это техника рисования краской тонким слоем сразу по основе или по просушенному слою краски. Характерна только для прозрачных красок - масла, акварели, иногда акрила. Основное качество лессировки - прозрачность. Нанесённый поверх предыдущего слоя краски слой лессировки как бы глазирует поверхность картины, придаёт особую выразительность и глубину слоям краски, лежащим под лессировкой. В сочетании с плотными укрывистыми слоями краски в картине маслом лессировка создаёт иллюзию глубины и прозрачности, благодаря ей появляется объёмная живопись.";
			gc.PaintingTechniques.Add(pt);

			PaintingTechnique pt2 = new PaintingTechnique();
			pt2.Name = "Мазковая техника живописи";
			pt2.Description = "Среди техник живописи мазковая выделяется особо. Это такой способ живописи, когда краска смешивается на палитре и наносится на холст отдельными мазками - каждый мазок на своё место. Таким образом, объём и форма в живописи вылепливаются наложенными на холст мазками нужного цвета, тона, размера. Фактурная живопись, демонстрирующая множество мазков разного качества и рельефа, рассматривается на расстоянии, таким образом отдельные мазки краски сливаются в единое целое изображение и придают картине реалистичность, живость, динамичность. Мазковая техника живописи учит художника точно намешивать нужные оттенки и класть их в нужное место, поэтому она используется при обучении художников чаще всего.";
			gc.PaintingTechniques.Add(pt2);

			Gallery gallery = new Gallery();
			gallery.Email = "ArtGallery@gmail.com";
			gallery.HotLine = "+79963153651";
			gallery.Info = "Только натуральные картины написанные натуралами(но это не точно)";
			gallery.Title = "ArtGallery";
			gc.Gallerys.Add(gallery);


			gc.SaveChanges();

		}


		


	}
}
