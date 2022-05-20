using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;

namespace Onion.WebApp.Controllers
{
    public class DetailController : Controller
    {
        private readonly IDetail _detailService;
        private readonly IStorekeeper _storekeeperService;


        public DetailController(IDetail detailService, IStorekeeper storekeeperService)
        {
            _detailService = detailService;
            _storekeeperService = storekeeperService;
        }


        [HttpGet]
        public IActionResult Show()
        {
            return View(_detailService.GetList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Storekeepers = _storekeeperService.GetList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(DetailDTO detailDTO)
        {
            ViewBag.Storekeepers = _storekeeperService.GetList();
            if (!_detailService.IsUnique(detailDTO))
            {
                if (ModelState.IsValid)
                {
                    _detailService.Create(detailDTO);
                    ViewBag.CreateResult = "Detail is successfully created!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Detail already exists!");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            _detailService.Delete(id);
            return RedirectToAction("Show", "Detail");
        }
    }
}
