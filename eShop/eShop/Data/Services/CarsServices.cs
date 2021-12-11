using eShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly eShopDbContext _context;

        public CarsServices(eShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var result = await _context.Cars.OrderBy(n => n.Model).ToListAsync();
            return result;
        }

        public async Task AddAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Cars.FirstOrDefaultAsync(n => n.CarId == id);
            _context.Cars.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            var result = await _context.Cars.Include(s => s.Seller).FirstOrDefaultAsync(n => n.CarId == id);
            return result;
        }

        public async Task<Car> UpdateAsync(int id, Car car)
        {
            car.CarId = id;
            _context.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
