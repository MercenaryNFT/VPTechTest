using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TechTestVP.Lib.DTOs;

namespace TechTestVP.Lib.Models
{
    public class Order
    {
        public Guid Guid { get; set; }
        public DateTime Created { get; set; }
        public string CustomerRef { get; set; }
        public int OrderNumber { get; set; }
        public Guid CustomerGuid { get; set; }
        public Customer Customer { get; set; }
        public List<OrderLine> Lines { get; set; }
        public DateTime? RequiredDate { get; set; }
        public bool IsShipped { get; set; }

    }
}
