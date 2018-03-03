using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDA;
using directorios = System.IO;


namespace Lab02_ArbolBinario.Controllers
{
    public class Carga_de_archivo<T>
    {

        public ArbolBinarioBusqueda<T> Cargajsoninterna(HttpPostedFileBase archivo,HttpServerUtilityBase SERVIDOR)
        {
            ArbolBinarioBusqueda<T> arbol_a_insertar = new ArbolBinarioBusqueda<T>();
            string pathArchivo = string.Empty;
            if (archivo != null)
            {
               
                string path = SERVIDOR.MapPath("~/Cargas/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                pathArchivo = path + Path.GetFileName(archivo.FileName);
                string extension = Path.GetExtension(archivo.FileName);
                archivo.SaveAs(pathArchivo);
                Random miRandom = new Random();
                string archivoJSON = directorios.File.ReadAllText(pathArchivo);
                arbol_a_insertar.Raiz = JsonConvert.DeserializeObject<Nodo<T>>(archivoJSON);
                return arbol_a_insertar;
                    
                  
                // return File("/dataPaises.json", "text/x-json");

            }
            return null;

           
        }
    }
}