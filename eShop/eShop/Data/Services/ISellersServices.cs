using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.Services
{
    public interface ISellersServices
    {
        Task<IEnumerable<Seller>> GetAllAsync();
        Task<Seller> GetByIdAsync(int id);

        Task AddAsync(Seller seller);
        Task<Seller> UpdateAsync(int id, Seller newSeller);

        Task DeleteAsync(int id);

    }
}
