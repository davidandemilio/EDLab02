using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab02_ArbolBinario.Models;
using TDA;
using Lab02_ArbolBinario.DBContest;
namespace Lab02_ArbolBinario.Controllers
{
    public class EnteroController : Controller
    {
        DefaultConnection<Entero> db = DefaultConnection<Entero>.getInstance;


        // GET: Entero
        public ActionResult Index()
        {
            return View(db.datos.ToList());
        }

       
        // GET: Entero/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public void pasar_a_lista(Nodo<Entero> actual) {
            db.datos.Add(actual.valor);
        }

        // GET: Entero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entero/Create
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

        // GET: Entero/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Entero/Edit/5
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

        // GET: Entero/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entero/Delete/5
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


        [HttpPost]
        public ActionResult CargaJsonEnt(HttpPostedFileBase archivo)
        {

            db.datos.Clear();
            Carga_de_archivo<int> carga = new Carga_de_archivo<int>();
            ArbolBinarioBusqueda < int > arbol_ingresar = carga.Cargajsoninterna(archivo, Server);
            almacenar_en_Enteros(arbol_ingresar);
            db.AB.EnOrden(pasar_a_lista);

            return RedirectToAction("Index");          
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

        public void almacenar_en_Enteros(ArbolBinarioBusqueda<int> arbol_ingresar)
        {
            arbol_ingresar.PreOrden(asignar_en_recorrido);

        }

        public void asignar_en_recorrido(Nodo<int> actual)
        {
            Entero ent = new Entero();
            ent.valor = actual.valor;
            Nodo<Entero> nd_insertar = new Nodo<Entero>(ent,comparador_enteros);

            db.AB.Insertar(nd_insertar);

        }
        public int comparador_enteros(Entero actual,Entero nuevo)
        {
            return actual.valor.CompareTo(nuevo.valor);

        }

    }
}
