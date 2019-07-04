using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KendoBus.Repository
{
    public enum UnitOfMoney
    {
        [Description("تومان")]
        Tomans = 1,
        [Description("ریال")]
        Rials = 2
    }
}