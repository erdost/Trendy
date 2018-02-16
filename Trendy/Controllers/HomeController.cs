using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Trendy.Data;
using Trendy.Entities;
using Trendy.Models;

namespace Trendy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int pageSize = 10, int pageIndex = 0)
        {
            var productRepo = new MongoRepository<Product>();

            var products = productRepo.SearchFor(i => true, pageSize, pageIndex)
                .Select(p => new ProductViewModel {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    LastUpdatedTime = p.LastUpdatedTime
                });

            return View(
                new IndexViewModel {
                    Products = new List<ProductViewModel>(products),
                    PageIndex = pageIndex
                });
        }
    }
}
