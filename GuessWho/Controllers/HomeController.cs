using GuessWho.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace GuessWho.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            return View(Services.characters());
        }

        public ActionResult Mugshot(string Name)
        {            
            Stream memoryStream = new MemoryStream();
            CloudBlockBlob blockBlob = Services.characterImage(Name);
            blockBlob.DownloadToStream(memoryStream);
            memoryStream.Position = 0;
            return File(memoryStream, blockBlob.Properties.ContentType);
        }

        public ActionResult Characters()
        {            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}