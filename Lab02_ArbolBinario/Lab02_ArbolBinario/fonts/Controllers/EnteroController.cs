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

        public void ITSB()
        {
            if (EstaBalanceado(db.AB.Raiz) == true)
            {
                Response.Write("El Arbol esta Balanceado");
            }
            else
            {
                Response.Write("El Arbol No esta Balanceado");
            }
        }

        public static bool EstaBalanceado(Nodo<Entero> nodo)
        {
            var mm = new DetMinMax();
            mm.Minimo = int.MaxValue;
            mm.Maximo = int.MinValue;

            EncontrarMinMax(mm, nodo, 0);

            return (mm.Maximo - mm.Minimo <= 1) ? true : false;
        }

        private static void EncontrarMinMax(DetMinMax mm, Nodo<Entero> node, int depth)
        {
            if (node == null) return;

            EncontrarMinMax(mm, node.izquierdo, depth + 1);
            EncontrarMinMax(mm, node.derecho, depth + 1);

            // En el nodo final
            if (node.izquierdo == null || node.derecho == null)
            {
                if (mm.Minimo > depth) mm.Minimo = depth;
                if (mm.Maximo < depth) mm.Maximo = depth;
            }
        }
        public class DetMinMax
        {
            public int Minimo { get; set; }
            public int Maximo { get; set; }
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
