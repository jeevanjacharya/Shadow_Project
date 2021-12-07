using ProductEFBL;
using ProductEFDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductBL blObj = new ProductBL();
            var products = blObj.GetAllProducts();
            foreach (var prod in products)
            {
                Console.WriteLine(prod.Slno + "|" + prod.ProductName + "|" + prod.ProductPrice);
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Enter the Product name");
            string productname = Console.ReadLine();
            Console.WriteLine("Enter the Product Price");
            int productprice = Convert.ToInt32(Console.ReadLine());

            ProductDTO newProdObj = new ProductDTO()
            {
                ProductName = productname,
                ProductPrice = productprice
            };

            int retVal = blObj.AddNewProduct(newProdObj);

            if (retVal == 1)
            {
                Console.WriteLine("Product added");
            }
            else if (retVal == -1)
            {
                Console.WriteLine("department name cannot be empty");
            }
            else if (retVal == -2)
            {
                Console.WriteLine("department group name cannot be empty");
            }
            else if (retVal == -3)
            {
                Console.WriteLine("creation date is cannot be empty");
            }
            else
            {
                Console.WriteLine("something is wrong.... will get back to you");
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Enter the SLNO");
            int slno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Product name");
            string prodname = Console.ReadLine();
            Console.WriteLine("Enter the Product price");
            int prodprice = Convert.ToInt32(Console.ReadLine());

            ProductDTO ProdObj = new ProductDTO()
            {
                Slno = slno,
                ProductName = prodname,
                ProductPrice = prodprice
            };

            int retVal1 = blObj.UpdateProduct(ProdObj);

            if (retVal1 == 1)
            {
                Console.WriteLine("Product Updated");
            }
            else
            {
                Console.WriteLine("something is wrong will get back to you");
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Enter the SLNO");
            int prodslno = Convert.ToInt32(Console.ReadLine());
            
            ProductDTO slnoObj = new ProductDTO()
            {
                Slno = prodslno
            };

            int retVal2 = blObj.UpdateProduct(slnoObj);

            if (retVal2 == 1)
            {
                Console.WriteLine("Product Deleted");
            }
            else
            {
                Console.WriteLine("something is wrong will get back to you");
            }
        }
    }
}
