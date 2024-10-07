using Microsoft.AspNetCore.Mvc;
using Quillia.Database.Data;
using Quillia.Database.Repositary.IRepository;
using Quillia.Models;

namespace Quillia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        
        private readonly IUnitOfWork _categoryRepo;
        public CategoryController(IUnitOfWork db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Categorycs> objCatagoryList = _categoryRepo.Category.GetAll().ToList();

            return View(objCatagoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categorycs obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("Name", "Test is invalid value");
            }

            if (ModelState.IsValid)
            {
                _categoryRepo.Category.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category Created Successfully";
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
            Categorycs? categoryFromDb = _categoryRepo.Category.Get(u => u.Id == id);/*
            Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();*/

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Categorycs obj)
        {

            if (ModelState.IsValid)
            {
                _categoryRepo.Category.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category Updated Successfully";

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
            Categorycs? categoryFromDb = _categoryRepo.Category.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Categorycs? obj = _categoryRepo.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Category.Remove(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category Deleted Successfully";

            return RedirectToAction("Index");
        }
    }

}