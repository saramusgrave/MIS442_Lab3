using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web.Http;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _prodRepo;
        
        public ProductController()
        {
            _prodRepo = new ProductRepository();
        }
        [HttpGet]
        public ActionResult Index()
        {            
            ViewBag.Title = "MIS442 News";
            ViewBag.Header = "MIS442 News";
            return View(_prodRepo.GetList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _prodRepo.Save(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = _prodRepo.Get(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _prodRepo.Save(product);
            return RedirectToAction("Index");
        }
        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult ViewProduct(int id)
        {
            Product product = _prodRepo.Get(id);
            Product ProductModel = new Product()
            {
                ProductID = product.ProductID,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                ProductVersion = product.ProductVersion,
                ProductReleaseDate = product.ProductReleaseDate

            };
            return ViewProduct(id);
        }
    }
}