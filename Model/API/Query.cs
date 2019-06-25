using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPS.Model
{
    public abstract class Query
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}