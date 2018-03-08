using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab02_ArbolBinario.Models;
using TDA;
using Lab02_ArbolBinario.DBContest;
using System.Net;

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
            return nuevo.nombre.CompareTo(actual.nombre);
        }

        public void EsDegenerado()
        {
            if (db.AB.Raiz.isDegenerate() == false)
            {
                Response.Write("El Arbol No es degenerado");
            }
            else
            {
                Response.Write("El Arbol es degenerado");
            }
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
        public ActionResult Create([Bind(Include ="nombre,Grupo")]Pais pais) 
        {
            try
            {
            //TODO: Add insert logic here
                Nodo<Pais> nuevo_pais = new Nodo<Pais>(pais, null);
                nuevo_pais.valor = pais;
                db.datos.Clear();
                db.AB.Insertar(nuevo_pais);
                db.AB.EnOrden(asignar_comparacion);
                db.AB.EnOrden(pasar_a_lista);

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
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais_buscado = db.datos.Find(x => x.nombre == id);

            if (pais_buscado == null)
            {

                return HttpNotFound();
            }
            return View(pais_buscado);
        }

        // POST: Pais/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.AB.Eliminar(db.datos.First(x => x.nombre == id));
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
    }
}
