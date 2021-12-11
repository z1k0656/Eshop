using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.Services
{
    public interface ICarsServices
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int id);

        Task AddAsync(Car seller);
        Task<Car> UpdateAsync(int id, Car newCar);

        Task DeleteAsync(int id);
    }
}
