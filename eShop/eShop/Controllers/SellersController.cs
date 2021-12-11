﻿using eShop.Data;
using eShop.Data.Services;
using eShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    public class SellersController : Controller
    {
        private readonly ISellersServices _service;

        public SellersController(ISellersServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allSellers = await _service.GetAllAsync();
            return View(allSellers);
        }
        
        //Get: Sellers/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL,Bio")]Seller seller)
        {
            if (!ModelState.IsValid) 
            {
                return View(seller);
            }
            await _service.AddAsync(seller);
            return RedirectToAction(nameof(Index));

            
        }
        
        //Get: Sellers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var sellerDetails = await _service.GetByIdAsync(id);

            if (sellerDetails == null) 
                return View("NotFound");

            return View(sellerDetails);
        }

        //Get: Sellers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var sellerDetails = await _service.GetByIdAsync(id);

            if (sellerDetails == null) 
                return View("NotFound");

            return View(sellerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName, ProfilePictureURL,Bio")] Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return View(seller);
            }
            await _service.UpdateAsync(id, seller);
            return RedirectToAction(nameof(Index));
        }

        //Get: Sellers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var sellerDetails = await _service.GetByIdAsync(id);

            if (sellerDetails == null) return View("NotFound");
            return View(sellerDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sellerDetails = await _service.GetByIdAsync(id);
            if (sellerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
