using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using directorios = System.IO;
using TDA;
using Lab02_ArbolBinario.Models;
using Lab02_ArbolBinario.DBContest;
namespace Lab02_ArbolBinario.Controllers
{
    public class CadenaController : Controller
    {

        DefaultConnection<string> db = DefaultConnection<string>.getInstance;
        public ActionResult CargaJsonCad(HttpPostedFileBase archivo)
        {
            Carga_de_archivo<string> carga = new Carga_de_archivo<string>();
            db.AB=carga.Cargajsoninterna(archivo,Server);
            return View();
        }
        // GET: Cadena
        public ActionResult Index()
        {
            db.AB.EnOrden(pasar_a_lista);
            return View(db.datos.ToList());
        }

        // GET: Cadena/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public void pasar_a_lista(Nodo<string> actual)
        {
            db.datos.Add(actual.valor);
        }

        // GET: Cadena/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadena/Create
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

        // GET: Cadena/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cadena/Edit/5
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

        // GET: Cadena/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cadena/Delete/5
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
