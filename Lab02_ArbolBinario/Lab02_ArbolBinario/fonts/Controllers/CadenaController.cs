﻿using System;
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
using System.Net;

namespace Lab02_ArbolBinario.Controllers
{
    public class CadenaController : Controller
    {

        DefaultConnection<Cadena> db = DefaultConnection<Cadena>.getInstance;
        public ActionResult CargaJsonCad(HttpPostedFileBase archivo)
        {
            db.datos.Clear();
            Carga_de_archivo<string> carga = new Carga_de_archivo<string>();
            ArbolBinarioBusqueda<string> arbol_ingresar = carga.Cargajsoninterna(archivo, Server);
            almacenar_en_Cadenas(arbol_ingresar);
            db.AB.EnOrden(pasar_a_lista);

            return RedirectToAction("Index");
        }
        // GET: Cadena
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


        // GET: Cadena/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public void pasar_a_lista(Nodo<Cadena> actual)
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
        public ActionResult Create([Bind(Include = "valor")]Cadena cadena)
        {
            try
            {
                // TODO: Add insert logic here
                Nodo<Cadena> nueva_cadena = new Nodo<Cadena>(cadena, null);
                nueva_cadena.valor = cadena;
                db.datos.Clear();
                db.AB.Insertar(nueva_cadena);
                db.AB.EnOrden(asignar_comparacion);
                db.AB.EnOrden(pasar_a_lista);

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
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadena cadena_buscada = db.datos.Find(x => x.valor == id);

            if (cadena_buscada == null)
            {

                return HttpNotFound();
            }
            return View(cadena_buscada);
        }

        // POST: Cadena/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.AB.Eliminar(db.datos.First(x => x.valor == id));
                db.datos.Clear();
                db.AB.EnOrden(asignar_comparacion);
                db.AB.EnOrden(pasar_a_lista);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void almacenar_en_Cadenas(ArbolBinarioBusqueda<string> arbol_ingresar)
        {
            arbol_ingresar.PreOrden(asignar_en_recorrido);

        }

        public void asignar_en_recorrido(Nodo<string> actual)
        {
            Cadena cad = new Cadena();
            cad.valor = actual.valor;
            Nodo<Cadena> nd_insertar = new Nodo<Cadena>(cad, comparador_cadenas);

            db.AB.Insertar(nd_insertar);

        }
        public int comparador_cadenas(Cadena actual, Cadena nuevo)
        {
            return actual.valor.CompareTo(nuevo.valor);

        }
        public void asignar_comparacion(Nodo<Cadena> actual)
        {
            actual.comparador = comparador_cadenas;
        }
    }
}
