﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers {
    public class SellersController : Controller {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService) {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index() {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create() { 

            var departments = _departmentService.FindAll();
            var ViewModel = new SellerFormViewModel { Departments = departments };
            return View(ViewModel);
        }


        [HttpPost] //Identifies method as POST
        [ValidateAntiForgeryToken] //Prevents CSRF Attacks (When someone uses your logged session to send private data)
        public IActionResult Create(Seller seller) {

            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
