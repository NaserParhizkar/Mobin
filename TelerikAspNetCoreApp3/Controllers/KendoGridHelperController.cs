﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebUI.Controllers
{
    public class KendoGridHelperController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }


        public ViewResult MySearchInputs()
        {
            return View();
        }
    }
}