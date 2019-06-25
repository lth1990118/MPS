using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class AddressInfo
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
