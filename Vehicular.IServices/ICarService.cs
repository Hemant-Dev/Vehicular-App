﻿using Vehicular.DTOs;
using Vehicular.Model;
namespace Vehicular.IServices
{
    public interface ICarService 
    {
        Task<IEnumerable<GetCarDTO>> GetAllCarsAsync();
        Task<GetCarDTO> GetCarByIdAsync(int carId);
        Task<GetCarDTO> CreateCarAsync(CreateCarDTO carDTO);
        Task<GetCarDTO> UpdateCarAsync(int id, UpdateCarDTO carDTO);
        Task<bool> DeleteCarAsync(int carId);

        Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync();
        Task<IEnumerable<Color>> GetAllColorsAsync();
        Task<IEnumerable<Engine>> GetAllEnginesAsync();
        Task<IEnumerable<Brake>> GetAllBrakesAsync();
        Task<IEnumerable<GetCarDTO>> GetFilteredCarDTOList(string filter);   
    }
}
