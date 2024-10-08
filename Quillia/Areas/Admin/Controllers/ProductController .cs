using Microsoft.AspNetCore.Mvc;
using Quillia.Database.Data;
using Quillia.Database.Repositary.IRepository;
using Quillia.Models;

namespace Quillia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        
        private readonly IUnitOfWork _ProductRepo;
        public ProductController(IUnitOfWork db)
        {
            _ProductRepo = db;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _ProductRepo.Product.GetAll().ToList();

            return View(objProductList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {

            if (ModelState.IsValid)
            {
                _ProductRepo.Product.Add(obj);
                _ProductRepo.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? ProductFromDb = _ProductRepo.Product.Get(u => u.Id == id);/*
            Product? ProductFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            Product? ProductFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();*/

            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {

            if (ModelState.IsValid)
            {
                _ProductRepo.Product.Update(obj);
                _ProductRepo.Save();
                TempData["success"] = "Product Updated Successfully";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? ProductFromDb = _ProductRepo.Product.Get(u => u.Id == id);

            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _ProductRepo.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _ProductRepo.Product.Remove(obj);
            _ProductRepo.Save();
            TempData["success"] = "Product Deleted Successfully";

            return RedirectToAction("Index");
        }
    }

}