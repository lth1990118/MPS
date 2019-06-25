using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPS.Model
{
    public class ItemInfoQuery : Query
    {
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }

    }
}