﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicular.Model;

namespace Vehicular.IRepositories
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync();
        Task<IEnumerable<Color>> GetAllColorsAsync();
        Task<IEnumerable<Engine>> GetAllEnginesAsync();
        Task<IEnumerable<Brake>> GetAllBrakesAsync();

        Task<IEnumerable<Car>> GetCarFilterAsync(string filter);
        Task<(IEnumerable<Car>, int)> GetPaginatedCarFiltersAsync(int page, int pageSize, string filter);
        Task<IEnumerable<Car>> GetCarAdvanceFilterAsync(Car carObj);
        Task<(IEnumerable<Car>, int)> GetPaginatedData(int page, int pageSize);
        Task<(IEnumerable<Car>, int)> GetPaginatedAdvanceCarFiltersAsync(int page, int pageSize, Car carObj);
    }
}
