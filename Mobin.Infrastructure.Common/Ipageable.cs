using System;
using System.Collections.Generic;
using System.Text;

namespace Mobin.Common
{
    public class IPageable
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}