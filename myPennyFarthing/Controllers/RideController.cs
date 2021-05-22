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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ride r)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(r);
                return RedirectToAction("Details");
            }
            return View(r);
        }


        //   R E A D
        public IActionResult Index(int id)
        {
            IQueryable<Ride> rides = _repository.GetAllRides(id);
            return View(rides);
        }


        public IActionResult Details(int id)
        {
            Ride r = _repository.GetRideById(id);
            if (r == null)
            {
                return RedirectToAction("Index");
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
                return RedirectToAction("Details");
            }
            return View(r);
        }

        //   D E L E T E
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Ride r = _repository.GetRideById(id);
            return View(r);
        }

        [HttpPost]
        public IActionResult Delete(Ride r)
        {
            _repository.Delete(r);
            return RedirectToAction("Index");
        }
    }
}
