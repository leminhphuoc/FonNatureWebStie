﻿using FonNature.Filter;
using FonNature.Services.IClientServices;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    [CountVisitor]
    public class HomeController : Controller
    {
        private readonly IHomeServices _homeServices;

        public HomeController(IHomeServices homeServices)
        {
            _homeServices = homeServices;
        }

        public ActionResult Home()
        {
            ViewBag.Title = "Home Page";
            ViewBag.SlideList = _homeServices.ListSlide();
            ViewBag.FooterCategories = _homeServices.ListFooterCategory();
            ViewBag.Footers = _homeServices.ListFooter();
            ViewBag.About = _homeServices.ListAbout();
            ViewBag.Staffs = _homeServices.GetStaffs();
            var seo = _homeServices.GetHomeSeo();
            if(seo != null)
            {
                ViewBag.MetaTitle = seo.MetaTitle ?? string.Empty;
                ViewBag.MetaDescription = seo.SeoDescription ?? string.Empty;
                ViewBag.MetaKeyword = seo.SeoKeyWord ?? string.Empty;
            }
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            ViewBag.BlogCategories = _homeServices.ListContentCategory();
            ViewBag.ProductsCategories = _homeServices.ListProductCategories();
            var menus = _homeServices.ListMenu();
            return PartialView(menus);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            ViewBag.FooterCategories = _homeServices.ListFooterCategory();
            var footers = _homeServices.ListFooter();
            return PartialView(footers);
        }
    }
}
