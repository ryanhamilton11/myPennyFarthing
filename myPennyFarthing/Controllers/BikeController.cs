using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myPennyFarthing.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myPennyFarthing.Controllers
{
    public class BikeController : Controller
    {
        //   F I E L D S  &  P R O P E R T I E S
        private IBikeRepository _repository;


        //   C O N T R O L L E R S
        public BikeController(IBikeRepository repository)
        {
            _repository = repository;
        }


        //   M E T H O D S
        //   C R E A T E
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Bike { Year = DateTime.Now.Year });
        }

        [HttpPost]
        public IActionResult Create(Bike b)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(b);
                return RedirectToAction("Details", new { id = b.Id });
            }
            return View(b);
        }


        //   R E A D
        public IActionResult Index()
        {
            return View(_repository.GetAllBikes().OrderBy(b => b.Year));
        }


        public IActionResult Details(int id)
        {
            Bike b = _repository.GetBikeById(id);
            if(b == null)
            {
                return RedirectToAction("Index");
            }
            return View(b);
        }


        //   U P D A T E
        [HttpGet]
        public  IActionResult Edit(int id)
        {
            Bike b = _repository.GetBikeById(id);
            if (b == null)
            {
                return RedirectToAction("Index", "Bike");
            }
            return View(b);
        }

        [HttpPost]
        public IActionResult Edit(Bike b)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(b);
                return RedirectToAction("Details", new { id = b.Id });
            }
            return View(b);
        }

        //   D E L E T E
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Bike b = _repository.GetBikeById(id);
            if (b == null)
            {
                return RedirectToAction("Index");
            }
            return View(b);
        }

        [HttpPost]
        public IActionResult Delete(Bike b)
        {
            _repository.Delete(b.Id);
            return RedirectToAction("Index");
        }
    }
}
