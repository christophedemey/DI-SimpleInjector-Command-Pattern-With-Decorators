using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_CommandPattern
{
    public class MoveCustomerCommand
    {
        public int CustomerId { get; set; }
        public string NewAddress { get; set; }
    }
}
