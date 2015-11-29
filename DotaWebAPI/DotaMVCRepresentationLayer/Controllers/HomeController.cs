﻿using System.Web.Mvc;
using DotaMVCRepresentationLayer.Attributes;
using DotaMVCRepresentationLayer.Models;
using DotaMVCRepresentationLayer.Models.Mocks;

namespace DotaMVCRepresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MainPageViewModelMock());
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(new ContactViewModelMock());
        }
    }
}