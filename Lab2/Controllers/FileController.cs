using Lab2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Lab2.Controllers
{
    public class FileController : Controller
    {
        public static string CurrentFile = string.Empty;
        // GET: File
        public ActionResult Index()
        {
            var filePaths = Directory.GetFiles(Server.MapPath("~/TextFiles"));

            return View(new FileIndexModel
            {
                Files = getFileNames(filePaths)
            });
        }

        public ActionResult Content(string id)
        {
            id = id + ".txt";
            string filePath = Server.MapPath("~/TextFiles") + "\\" + id;
            string content = string.Empty;

            try
            {
                using (var stream = new StreamReader(filePath))
                {
                    content = stream.ReadToEnd();
                }
            }
            catch (Exception exc)
            {
                content = ("Uh oh!");
            }

            return View(new FileContentModel()
            {
                FileInfo = content
            });
        }

        public string[] getFileNames(string[] filePaths)
        {
            string[] files = new string[filePaths.Length];
            for(int i = 0; i < filePaths.Length; i++)
            {
                files[i] = Path.GetFileNameWithoutExtension(filePaths[i]);
            }
            return files;
        }
    }
}