using eShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.Services
{
    public class SellerService : ISellersServices
    {
       private readonly eShopDbContext _context;

        public SellerService(eShopDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Seller seller)
        {
            await _context.Sellers.AddAsync(seller);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Sellers.FirstOrDefaultAsync(n => n.SellerId == id);
            _context.Sellers.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Seller>> GetAllAsync()
        {
            var result = await _context.Sellers.ToListAsync();
            return result;
        }

        public async Task<Seller> GetByIdAsync(int id)
        {
            var result = await _context.Sellers.FirstOrDefaultAsync(n => n.SellerId == id);
            return result;
        }

        public async Task<Seller> UpdateAsync(int id, Seller seller)
        {
            seller.SellerId = id;
            _context.Update(seller);
            await _context.SaveChangesAsync();
            return seller;
        }
       

    }
}
