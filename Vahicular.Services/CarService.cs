using Vehicular.DTOs;
using Vehicular.IRepositories;
using Vehicular.IServices;
using Vehicular.Model;


namespace Vahicular.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }
        public async Task<GetCarDTO> CreateCarAsync(CreateCarDTO carDTO)
        {
            if(carDTO == null) throw new ArgumentNullException(nameof(carDTO));
            var car = new Car()
            {
                Name = carDTO.Name,
                EngineCapacity = carDTO.EngineCapacity,
                EngineType = carDTO.EngineType,
                FuelCapacity = carDTO.FuelCapacity,
                BrakeType = carDTO.BrakeType,
                Seats = carDTO.Seats,
                ManufacturerId = carDTO.ManufacturerId,
                ColorId = carDTO.ColorId,
            };
            var result = await _carRepository.AddAsync(car);
            var newCarDTO = new GetCarDTO(result.Id, result.Name, result.EngineCapacity, result.EngineType, result.FuelCapacity, result.BrakeType, result.Seats, result.ManufacturerId, result.ColorId);

            return newCarDTO;
        }

        public async Task<bool> DeleteCarAsync(int carId)
        {
            if(carId < 0) throw new ArgumentOutOfRangeException(nameof(carId));
            return await _carRepository.DeleteAsync(carId); 
        }

        public async Task<IEnumerable<GetCarDTO>> GetAllCarsAsync()
        {
            var carsList = await _carRepository.GetAllAsync();
            if(carsList != null)
            {
                var carsDTOList = carsList.Select((car) =>
                    new GetCarDTO(car.Id, car.Name, car.EngineCapacity, car.EngineType, car.FuelCapacity, car.BrakeType, car.Seats, car.ManufacturerId, car.ColorId));
                return carsDTOList;
            }
            return null;
        }

        

        public async Task<GetCarDTO> GetCarByIdAsync(int carId)
        {
            var car = await _carRepository.GetByIdAsync(carId);
            if(car != null)
            {
                return new GetCarDTO(car.Id, car.Name, car.EngineCapacity, car.EngineType, car.FuelCapacity, car.BrakeType, car.Seats, car.ManufacturerId, car.ColorId);
            }
            return null;
        }

        public async Task<GetCarDTO> UpdateCarAsync(int id, UpdateCarDTO carDTO)
        {
            var oldCar = await _carRepository.GetByIdAsync(id);
            if(oldCar != null)
            {

                            
                oldCar.Id = id;
                oldCar.Name = carDTO.Name;
                oldCar.EngineCapacity = carDTO.EngineCapacity;
                oldCar.EngineType = carDTO.EngineType;
                oldCar.FuelCapacity = carDTO.FuelCapacity;
                oldCar.BrakeType = carDTO.BrakeType;
                oldCar.Seats = carDTO.Seats;
                oldCar.ManufacturerId = carDTO.ManufacturerId;
                oldCar.ColorId = carDTO.ColorId;    

                await _carRepository.UpdateAsync(id, oldCar);
                return new GetCarDTO(oldCar.Id, oldCar.Name, oldCar.EngineCapacity, oldCar.EngineType, oldCar.FuelCapacity, oldCar.BrakeType, oldCar.Seats, oldCar.ManufacturerId, oldCar.ColorId);
            }
            return null;

        }

        public Task<IEnumerable<Color>> GetAllColorsAsync()
        {
            return _carRepository.GetAllColorsAsync();
        }

        public Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync()
        {
            return _carRepository.GetAllManufacturersAsync();
        }

    }
}
