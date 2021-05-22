using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myPennyFarthing.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myPennyFarthing.Controllers
{
    public class MXController : Controller
    {
        //   F I E L D S  &  P R O P E R T I E S
        private IMXRepository _repository;


        //   C O N T R O L L E R S
        public MXController(IMXRepository repository)
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
        public IActionResult Create(MX mx)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(mx);
                return RedirectToAction("Details");
            }
            return View(mx);
        }


        //   R E A D
        public IActionResult Index(int id)
        {
            IQueryable<MX> mxs = _repository.GetAllMXs(id);
            return View(mxs);
        }


        public IActionResult Details(int id)
        {
            MX mx = _repository.GetMXById(id);
            if (mx == null)
            {
                return RedirectToAction("Index");
            }
            return View(mx);
        }


        //   U P D A T E
        [HttpGet]
        public IActionResult Edit(int id)
        {
            MX mx = _repository.GetMXById(id);
            return View(mx);
        }

        [HttpPost]
        public IActionResult Edit(MX mx)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(mx);
                return RedirectToAction("Details");
            }
            return View(mx);
        }

        //   D E L E T E
        [HttpGet]
        public IActionResult Delete(int id)
        {
            MX mx = _repository.GetMXById(id);
            return View(mx);
        }

        [HttpPost]
        public IActionResult Delete(MX mx)
        {
            _repository.Delete(mx);
            return RedirectToAction("Index");
        }
    }
}
