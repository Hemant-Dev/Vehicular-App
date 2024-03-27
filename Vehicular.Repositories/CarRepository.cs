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

        public async Task<IEnumerable<Brake>> GetAllBrakesAsync()
        {
            return await _dbContext.Brakes.ToListAsync();
        }

        public async Task<IEnumerable<Color>> GetAllColorsAsync()
        {
            return await _dbContext.Colors.ToListAsync();
        }

        public async Task<IEnumerable<Engine>> GetAllEnginesAsync()
        {
            return await _dbContext.Engines.ToListAsync();
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync()
        {
            return await _dbContext.Manufacturers.ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetCarFilterAsync(string filter)
        {
            //return await _dbContext.Cars.Include(x=>x.Color).Include(x=>x.Manufacturer).Where(f=>f.Manufacturer.manufacturerName.Contains(filter) || f.Color.ColorName.Contains(filter)).ToListAsync();
            return await _dbContext.Cars.Include(car => car.Color).Include(car => car.Manufacturer).Include(car => car.Engine).Include(car => car.Brake).Where(car => car.Color.ColorName.Contains(filter)
            || car.Manufacturer.manufacturerName.Contains(filter)
            || car.Engine.EngineName.Contains(filter)
            || car.Brake.BrakeName.Contains(filter)
            || car.Name.Contains(filter)
            || car.Seats.ToString().Contains(filter)
            || car.EngineCapacity.ToString().Contains(filter)
            || car.FuelCapacity.ToString().Contains(filter)
            ).ToListAsync();
        }
    }
}
