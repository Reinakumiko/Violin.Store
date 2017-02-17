using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Violin.Store.Web.BackFront.Controllers
{
	public class ImageController : Controller
	{
		// GET: Image
		readonly string imageSavePath = "/UploadImage/";

		public ActionResult Index()
		{
			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}

		public ActionResult Upload()
		{
			var localPath = Server.MapPath("~");
			var savePath = $"{localPath}/{imageSavePath}";
			if (!Directory.Exists(savePath))
				Directory.CreateDirectory(savePath);

			try
			{
				return Json(FroalaEditor.File.Upload(System.Web.HttpContext.Current, imageSavePath));
			}
			catch (Exception e)
			{
				return Json(e);
			}
		}

		public ActionResult Load()
		{
			try
			{
				return Json(FroalaEditor.Image.List(imageSavePath));
			}
			catch (Exception e)
			{
				return Json(e);
			}
		}

		public ActionResult Delete()
		{
			try
			{
				FroalaEditor.Image.Delete(imageSavePath + HttpContext.Request.Form["src"]);
				return Json(true);
			}
			catch (Exception e)
			{
				return Json(e);
			}
		}
	}
}