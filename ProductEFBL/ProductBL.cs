using ProductEFDAL;
using ProductEFDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductEFBL
{
    public class ProductBL
    {
        public List<ProductDTO> GetAllProducts()
        {
            ProductDAL dalObj = new ProductDAL();
            return dalObj.FetchProducts();
        }

        public int AddNewProduct(ProductDTO prodObj)
        {
            ProductDAL dalObj = new ProductDAL();
            return dalObj.InsertNewProduct(prodObj);
        }

        public int UpdateProduct(ProductDTO prodObj)
        {
            ProductDAL dalObj = new ProductDAL();
            return dalObj.UpdateNewProduct(prodObj);
        }

        public int DeleteProduct(int id)
        {
            ProductDAL dalObj = new ProductDAL();
            return dalObj.DeleteProduct(id);
        }
    }
}
