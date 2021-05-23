using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myPennyFarthing.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myPennyFarthing.Controllers
{
    public class RideController : Controller
    {
        //   F I E L D S  &  P R O P E R T I E S
        private IRideRepository _repository;


        //   C O N T R O L L E R S
        public RideController(IRideRepository repository)
        {
            _repository = repository;
        }


        //   M E T H O D S
        //   C R E A T E
        [HttpGet]
        public IActionResult Create(int bikeid)
        {
            Ride r = new Ride { Date = DateTime.Now, BikeId = bikeid };
            return View(r);
        }

        [HttpPost]
        public IActionResult Create(Ride r)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(r);
                return RedirectToAction("Details", new { id = r.Id });
            }
            return View(r);
        }


        //  R E A D
        public IActionResult Index(int id)
        {
            Ride r = _repository.GetRideById(id);
            if (r == null)
            {
                return RedirectToAction("Index");
            }
            return View(r);
        }


        public IActionResult Details(int id)
        {
            Ride r = _repository.GetRideById(id);
            if (r == null)
            {
                return RedirectToAction("Index", "Bike");
            }
            return View(r);
        }


        //   U P D A T E
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Ride r = _repository.GetRideById(id);
            return View(r);
        }

        [HttpPost]
        public IActionResult Edit(Ride r)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(r);
                return RedirectToAction("Details", new { id = r.Id });
            }
            return View(r);
        }

        //   D E L E T E
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Ride r = _repository.GetRideById(id);
            if (r == null)
            {
                return RedirectToAction("Index, Bike");
            }
            return View(r);
        }

        [HttpPost]
        public IActionResult Delete(Ride r)
        {
            int bikeId = r.BikeId;
            _repository.Delete(r);
            return RedirectToAction("Details", "Bike", new { id = bikeId });
        }
    }
}
