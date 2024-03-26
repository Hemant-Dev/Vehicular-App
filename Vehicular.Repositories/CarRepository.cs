using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicular.Data;
using Vehicular.IRepositories;
using Vehicular.Model;

namespace Vehicular.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly VehicularAppDbContext _dbContext;
        public CarRepository(VehicularAppDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Color>> GetAllColorsAsync()
        {
            return await _dbContext.Colors.ToListAsync();
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync()
        {
            return await _dbContext.Manufacturers.ToListAsync();
        }
    }
}
