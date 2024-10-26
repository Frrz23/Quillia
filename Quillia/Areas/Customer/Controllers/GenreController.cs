using Microsoft.AspNetCore.Mvc;
using Quillia.Database.Repositary.IRepository;
using Quillia.Models;
using System.Collections.Generic;

namespace Quillia.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class GenreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int? categoryId)
        {
            var categories = _unitOfWork.Category.GetAll();
            ViewBag.Categories = categories;

            ViewBag.CurrentCategory = categoryId;

            IEnumerable<Product> productList;
            if (categoryId.HasValue)
            {
                productList = _unitOfWork.Product.GetAll(p => p.CategoryId == categoryId, includeProperties: "Category");
            }
            else
            {
                productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            }

            return View(productList);
        }

    }
}
