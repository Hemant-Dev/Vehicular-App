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

        public async Task<IEnumerable<Car>> GetCarAdvanceFilterAsync(Car carObj)
        {

            var query = _dbContext.Cars.AsQueryable();
            if(!string.IsNullOrWhiteSpace(carObj.Name))
            {
                query = query.Where(car => car.Name == carObj.Name);
            }
            if(carObj.EngineCapacity > 0)
            {
                query = query.Where(car => car.EngineCapacity == carObj.EngineCapacity);
            }
            if(carObj.FuelCapacity > 0)
            {
                query = query.Where(car => car.FuelCapacity == carObj.FuelCapacity);
            }
            if(carObj.Seats > 0)
            {
                query = query.Where(car => car.Seats == carObj.Seats);
            }
            if(carObj.ManufacturerId > 0)
            {
                query = query.Where(car => car.ManufacturerId == carObj.ManufacturerId);
            }
            if(carObj.ColorId > 0)
            {
                query = query.Where(car => car.ColorId == carObj.ColorId);
            }
            if(carObj.EngineId > 0)
            {
                query = query.Where(car => car.EngineId == carObj.EngineId);
            }
            if(carObj.BrakeId > 0)
            {
                query = query.Where(car => car.BrakeId == carObj.BrakeId);
            }
            return await query.ToListAsync();
        }

        public async Task<(IEnumerable<Car>, int)> GetPaginatedData(int page, int pageSize)
        {
            var query = _dbContext.Cars.AsQueryable();
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            query = query.Skip((page-1) * pageSize).Take(pageSize);

            return (await query.ToListAsync(), totalPages);
        }

        public async Task<(IEnumerable<Car>, int)> GetPaginatedCarFiltersAsync(int page, int pageSize, string filter)
        {
            var carsList = await _dbContext.Cars.Include(car => car.Color).Include(car => car.Manufacturer).Include(car => car.Engine).Include(car => car.Brake).Where(car => car.Color.ColorName.Contains(filter)
            || car.Manufacturer.manufacturerName.Contains(filter)
            || car.Engine.EngineName.Contains(filter)
            || car.Brake.BrakeName.Contains(filter)
            || car.Name.Contains(filter)
            || car.Seats.ToString().Contains(filter)
            || car.EngineCapacity.ToString().Contains(filter)
            || car.FuelCapacity.ToString().Contains(filter)
            ).ToListAsync();

            var totalCount = carsList.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            carsList = carsList.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return (carsList, totalPages);
        }

        public async Task<(IEnumerable<Car>, int)> GetPaginatedAdvanceCarFiltersAsync(int page, int pageSize, Car carObj)
        {
            var query = _dbContext.Cars.AsQueryable();
            if (!string.IsNullOrWhiteSpace(carObj.Name))
            {
                query = query.Where(car => car.Name == carObj.Name);
            }
            if (carObj.EngineCapacity > 0)
            {
                query = query.Where(car => car.EngineCapacity == carObj.EngineCapacity);
            }
            if (carObj.FuelCapacity > 0)
            {
                query = query.Where(car => car.FuelCapacity == carObj.FuelCapacity);
            }
            if (carObj.Seats > 0)
            {
                query = query.Where(car => car.Seats == carObj.Seats);
            }
            if (carObj.ManufacturerId > 0)
            {
                query = query.Where(car => car.ManufacturerId == carObj.ManufacturerId);
            }
            if (carObj.ColorId > 0)
            {
                query = query.Where(car => car.ColorId == carObj.ColorId);
            }
            if (carObj.EngineId > 0)
            {
                query = query.Where(car => car.EngineId == carObj.EngineId);
            }
            if (carObj.BrakeId > 0)
            {
                query = query.Where(car => car.BrakeId == carObj.BrakeId);
            }
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            return (await query.ToListAsync(), totalPages);
        }
    }
}
