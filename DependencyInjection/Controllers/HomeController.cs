using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        //private ProductTotalizer totalizer;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
            //this.totalizer = totalizer;
        }

        public ViewResult Index([FromServices]ProductTotalizer totalizer)
        {
            //ViewBag.Total = totalizer.Total;
            ViewBag.HomeController = repository.ToString();
            ViewBag.Totalizer = totalizer.Repository.ToString();
            return View(repository.Products);
        }
    }
}
