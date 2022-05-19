using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.WebApp.Controllers
{
    public class StorekeeperController : Controller
    {
        private readonly IStorekeeper _storekeeperService;


        public StorekeeperController(IStorekeeper storekeeperService)
        {
            _storekeeperService = storekeeperService;
        }


        [HttpGet]
        public IActionResult Show()
        {
            return View(_storekeeperService.GetList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StorekeeperDTO storekeeperDTO)
        {
            if (!_storekeeperService.IsUnique(storekeeperDTO))
            {
                if (ModelState.IsValid)
                {
                    _storekeeperService.Create(storekeeperDTO);
                    ViewBag.CreateResult = "Storekeeper is successfully created!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Storekeeper already exists!");
            }
            return View();
        }
    }
}
