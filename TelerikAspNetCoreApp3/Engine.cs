using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language;
using System.Diagnostics;

namespace Northwind.WebUI
{
    public class Engine : RazorViewEngine
    {
        public Engine(IRazorPageFactoryProvider pageFactory,
            IRazorPageActivator pageActivator, 
            HtmlEncoder htmlEncoder, 
            IOptions<RazorViewEngineOptions> optionsAccessor,
            RazorProject razorProject, 
            ILoggerFactory loggerFactory, 
            DiagnosticSource diagnosticSource)
            : base(pageFactory, pageActivator, htmlEncoder, optionsAccessor, razorProject, loggerFactory, diagnosticSource)
        {
        }
    }
}