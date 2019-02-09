using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Babai.EntityFramework.Models;
using Babai.EntityFramework.Core;

namespace Babai.EntityFramework.Controllers
{
    public class PhonesController : Controller
    {
        private MobileContext context;
        public PhonesController(MobileContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var phones = this.context.Phones.ToList();
            return View(phones);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Phone phone)
        {
            this.context.Phones.Add(phone);
            this.context.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
