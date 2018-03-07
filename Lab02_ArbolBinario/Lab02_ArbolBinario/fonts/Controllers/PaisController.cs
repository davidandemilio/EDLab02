﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab02_ArbolBinario.Models;
using TDA;
using Lab02_ArbolBinario.DBContest;
namespace Lab02_ArbolBinario.Controllers
{
    public class PaisController : Controller
    {

        DefaultConnection<Pais> db = DefaultConnection<Pais>.getInstance;

        
        public ActionResult CargaJsonPais(HttpPostedFileBase archivo)
        {
            db.datos.Clear();
            Carga_de_archivo<Pais> carga = new Carga_de_archivo<Pais>();
            db.AB = carga.Cargajsoninterna(archivo,Server);
            db.AB.EnOrden(asignar_comparacion);
            db.AB.EnOrden(pasar_a_lista);
            return RedirectToAction("Index");
        }


        // GET: Pais
        public ActionResult Index()

        {
           
            return View(db.datos.ToList());

        }

        [HttpPost]
        public ActionResult MostrarOrden(string orden)
        {
            db.datos.Clear();
           if (orden == "InOrden")
            {
              
                db.AB.EnOrden(pasar_a_lista);
            }
            else if (orden == "PostOrden")
            {
              
                db.AB.PostOrden(pasar_a_lista);

            }
            else if (orden == "PreOrden")
            {
               
                db.AB.PreOrden(pasar_a_lista);
            }
            return RedirectToAction("Index");
        }

        public void pasar_a_lista(Nodo<Pais> actual)
        {
            db.datos.Add(actual.valor);
        }

        public void asignar_comparacion(Nodo<Pais> actual)
        {
            actual.comparador = comparador_paises;
           
        }

        public int comparador_paises(Pais actual,Pais nuevo)
        {
            return actual.nombre.CompareTo(nuevo.nombre);
        }

        // GET: Pais/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
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

        // GET: Pais/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pais/Edit/5
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

        // GET: Pais/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pais/Delete/5
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
