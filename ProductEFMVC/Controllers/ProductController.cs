using ProductEFBL;
using ProductEFDTO;
using ProductEFMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductEFMVC.Controllers
{
    public class ProductController : Controller
    {
        ProductEntities1 efObj = new ProductEntities1();
        // GET: Product
        public ActionResult ViewProduct()
        {
            List<Product> lstProduct = new List<Product>();
            ProductBL blObj = new ProductBL();
            var dbResult = blObj.GetAllProducts();
            foreach (var item in dbResult)
            {
                lstProduct.Add(new Product()
                {
                    Slno = item.Slno,
                    ProductName = item.ProductName,
                    ProductPrice = item.ProductPrice
                });
            }
            return View(lstProduct);
        }

        [HttpGet]
        public ActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewProductPost(Product newProdObj)
        {
            try
            {
                ProductBL blObj = new ProductBL();
                ProductDTO dtoObj = new ProductDTO();
                dtoObj.ProductName = newProdObj.ProductName;
                dtoObj.ProductPrice = newProdObj.ProductPrice;
                int result = blObj.AddNewProduct(dtoObj);
                if (result == 1)
                {
                    TempData["AlertMessage"] = "Product added successfully!!";
                    return RedirectToAction("ViewProduct");
                }
                else
                {
                    return View("AddNewProduct");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }

        [HttpGet]
        public ActionResult UpdateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditProduct(Product newProdObj)
        {
            try
            {
                ProductBL blObj = new ProductBL();
                ProductDTO dtoObj = new ProductDTO();
                dtoObj.Slno = newProdObj.Slno;
                dtoObj.ProductName = newProdObj.ProductName;
                dtoObj.ProductPrice = newProdObj.ProductPrice;
                int result = blObj.UpdateProduct(dtoObj);
                if (result == 1)
                {
                    TempData["AlertMessage"] = "Product updated successfully!!";
                    return RedirectToAction("ViewProduct");
                }
                else
                {
                    return View("UpdateProduct");
                }

            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            ProductBL blObj = new ProductBL();
            int result = blObj.DeleteProduct(Id);
            if (result == 1)
            {
                TempData["testmsg"] = "<script>alert('Requested Successfully ');</script>";
                return RedirectToAction("ViewProduct");
            }
            else
            {
                return View("Login");            
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDetail1 userdetail)
        {
            var checklogin = efObj.UserDetails1.Where(x => x.UserName.Equals(userdetail.UserName) && x.Password.Equals(userdetail.Password)).FirstOrDefault();
            if (checklogin != null)
            {
                Session["UserName"] = userdetail.UserName.ToString();
                Session["Password"] = userdetail.Password.ToString();
                return RedirectToAction("ViewProducts");
            }
            else
            {
                ViewBag.Notification = "Wrong Username and Password";
            }
            return View();
        }
    }
}