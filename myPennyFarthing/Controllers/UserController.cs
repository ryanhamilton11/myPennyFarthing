using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myPennyFarthing.Models;

namespace myPennyFarthing.Controllers
{
    public class UserController : Controller
    {
        //   F I E L D S  &  P R O P E R T I E S
        private IUserRepository _repository;



        //   C O N T R O L L E R S
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }


        //   M E T H O D S
        //   C R E A T E
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegistrationViewModel urvm)
        {
            if(ModelState.IsValid)
            {
                User u = new User();
                u.UserName = urvm.UserName;
                u.Password = urvm.Password;
                User newUser = _repository.Create(u);
                if(newUser == null)
                {
                    ModelState.AddModelError("", "A User With That Email Address Already Exists.");
                    return View(urvm);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(urvm);
        }


        //   R E A D
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            bool loggedIn = _repository.Login(u);
            if(loggedIn == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(u);
        }

        public IActionResult Logout()
        {
            _repository.Logout();
            return RedirectToAction("Index", "Home");
        }


        //   U P D A T E
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(UserChangePasswordViewModel ucpvm)
        {
            if(ModelState.IsValid)
            {
                bool success = _repository.ChangePassword(ucpvm.CurrentPassword, ucpvm.NewPassword);
                if(success == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Unable To Change Password");
                return View(ucpvm);
            }
            return View(ucpvm);
        }

        //   D E L E T E
    }
}
