using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salesDepot
{
    public class ProgramObjetcs
    {
        public static List<Product> Products { get; set; } = new()
        {
            new Product() { Name = "Laptop", Price = 5000, Quantity = 10 },
            new Product() { Name = "Mouse", Price = 50, Quantity = 100 },
            new Product() { Name = "Keyboard", Price = 100, Quantity = 50 },
        };
        
    }
}
