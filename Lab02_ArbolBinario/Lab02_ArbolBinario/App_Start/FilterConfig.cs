﻿using System.Web;
using System.Web.Mvc;

namespace Lab02_ArbolBinario
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
