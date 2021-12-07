using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductEFDTO
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Slno { get; set; }
    }

    public class LoginDTO
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
