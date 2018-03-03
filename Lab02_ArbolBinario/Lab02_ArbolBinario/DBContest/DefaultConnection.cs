using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDA;

namespace Lab02_ArbolBinario.DBContest
{
    public class DefaultConnection<T>
    {
        private static volatile DefaultConnection<T> Instance;
        private static object syncRoot = new Object();

        public List<T> datos = new List<T>();
        public List<string> Ids = new List<string>();
        public int IDActual { get; set; }

        public ArbolBinarioBusqueda<T> AB = new ArbolBinarioBusqueda<T>();


        private DefaultConnection()
        {
            IDActual = 0;
        }

        public static DefaultConnection<T> getInstance
        {

            get
            {

                if (Instance == null)
                {
                    lock (syncRoot)
                    {

                        if (Instance == null)
                        {
                            Instance = new DefaultConnection<T>();
                        }
                    }
                }
                return Instance;
            }
        }


    }
}
