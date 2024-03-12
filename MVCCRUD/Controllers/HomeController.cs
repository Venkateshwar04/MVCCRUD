using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class HomeController : Controller
    {
        MVCCRUDDBContext _context = new MVCCRUDDBContext();

        public ActionResult Index()
        {
            var listofData = _context.Products.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();  
        }
        [HttpPost]
        public ActionResult Create(Product model)
        {
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Products.Add(model);
            //        _context.SaveChanges();
            //        TempData["message"] = "Data Insert Successfully";
            //        return RedirectToAction("Index"); // Redirect to a different action after successful insertion
            //    }
            //    catch (Exception ex)
            //    {
            //        // Log the exception or handle it appropriately
            //        ModelState.AddModelError("", "Error occurred while saving data: " + ex.Message);
            //    }
            //}

            _context.Products.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var data = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(data);  
        }
        [HttpPost]
        public ActionResult Edit(Product Model)
        {
            var data = _context.Products.Where(x => x.ProductId == Model.ProductId).FirstOrDefault();
            if (data != null) 
            {
                data.ProductName = Model.ProductName;
                data.CategoryId = Model.ProductId;
                data.CategoryName = Model.ProductName;
            }
            return RedirectToAction("index");
        }

        public ActionResult Detail(int id)
        {
            var data = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            _context.Products.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Delete Successfully";
            return RedirectToAction("index");
        }    


    }
}