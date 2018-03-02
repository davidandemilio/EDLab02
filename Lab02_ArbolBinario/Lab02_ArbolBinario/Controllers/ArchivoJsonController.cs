using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using directorios = System.IO;
using TDA;



namespace Lab02_ArbolBinario.Controllers
{
    public class ArchivoJsonController : Controller
    {
        ArbolB AB = new ArbolB();
        public ActionResult CargaJson(HttpPostedFileBase archivo)
        {
            string pathArchivo = string.Empty;
            if (archivo != null)
            {
                string path = Server.MapPath("~/Cargas/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                pathArchivo = path + Path.GetFileName(archivo.FileName);
                string extension = Path.GetExtension(archivo.FileName);
                archivo.SaveAs(pathArchivo);
                Random miRandom = new Random();
                string archivoJSON = directorios.File.ReadAllText(pathArchivo);

                 AB.Raiz = JsonConvert.DeserializeObject<Nodo>(archivoJSON);
                // return File("/dataPaises.json", "text/x-json");

            }
            return View();
        }

        // GET: ArchivoJson
        public ActionResult Index()
        {

            return View();
        }

        // GET: ArchivoJson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArchivoJson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArchivoJson/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ArchivoJson/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArchivoJson/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ArchivoJson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArchivoJson/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
