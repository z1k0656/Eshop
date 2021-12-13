using eShop.Data;
using eShop.Data.Services;
using eShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    public class CarsController : Controller
    {
        static Seller seller;

        private readonly ICarsServices _service;

        public CarsController(ICarsServices service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allSellers = await _service.GetAllAsync();
            return View(allSellers);
        }

        //this method is now working yet because i dont know how to use Sessions in mvc .....
        public async Task<IActionResult> AddToCart(int Id)
        {
            CartItem cart = new CartItem();

            var carDetails = await _service.GetByIdAsync(Id);
            if (carDetails == null)
                return View("NotFound");


            carDetails.Model = cart.Model;
            carDetails.Price = cart.Price;
            return View();
        }

        //Get: Cars/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Model, ImageURL,Description, Price")] Car car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            await _service.AddAsync(car);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cars/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);
            if (carDetails == null)
                return View("NotFound");

            return View(carDetails);
        }

        //Get: Cars/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);
            seller = carDetails.Seller;
            if (carDetails == null)
                return View("NotFound");

            return View(carDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CarId, Model, Price, Description, ImageURL, StartDate, EndDate, CarMark")] Car car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            car.SellerId = seller.SellerId;
            await _service.UpdateAsync(id, car);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cars/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);

            if (carDetails == null) return View("NotFound");
            return View(carDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);
            if (carDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
