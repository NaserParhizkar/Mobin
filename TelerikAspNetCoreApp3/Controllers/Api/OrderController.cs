﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Mobin;
using Microsoft.AspNetCore.Mvc;
using Mobin.Service;
using Northwind.Repository.EntityModels;

namespace Northwind.WebUI.Controllers
{
    public class OrderApiController : CrudController<Order>
    {
        public OrderApiController(ICrudService<Order> _crudService) : base(_crudService)
        {
        }
    }
}