using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Mvc;
using UI_MVC.Factories;
using UI_MVC.Models;

namespace UI_MVC.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IHomeIndexViewModelFactory indexFactory;
        private readonly IHomeDetailViewModelFactory detailFactory;

        public ProductionController(IHomeIndexViewModelFactory indexFactory, IHomeDetailViewModelFactory detailFactory)
        {
            this.indexFactory = indexFactory;
            this.detailFactory = detailFactory;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var indexViewModel = await indexFactory.Create(page);
            return View(indexViewModel);
        }

        public async Task<IActionResult> Category(int id, int page = 1)
        {
            var indexViewModel = await indexFactory.Create(page, "category", id);
            return View("Index", indexViewModel);
        }

        public async Task<IActionResult> Brand(int id, int page = 1)
        {
            var indexViewModel = await indexFactory.Create(page, "brand", id);
            return View("Index", indexViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await detailFactory.Create(id);
            return View(viewModel);
        }
    }

}
