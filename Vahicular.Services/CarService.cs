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
                EngineId = carDTO.EngineId,
                FuelCapacity = carDTO.FuelCapacity,
                BrakeId = carDTO.BrakeId,
                Seats = carDTO.Seats,
                ManufacturerId = carDTO.ManufacturerId,
                ColorId = carDTO.ColorId,
            };
            var result = await _carRepository.AddAsync(car);
            var newCarDTO = new GetCarDTO(result.Id, result.Name, result.EngineCapacity, result.EngineId, result.FuelCapacity, result.BrakeId, result.Seats, result.ManufacturerId, result.ColorId);

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
                    new GetCarDTO(car.Id, car.Name, car.EngineCapacity, car.EngineId, car.FuelCapacity, car.BrakeId, car.Seats, car.ManufacturerId, car.ColorId));
                return carsDTOList;
            }
            return null;
        }

        

        public async Task<GetCarDTO> GetCarByIdAsync(int carId)
        {
            var car = await _carRepository.GetByIdAsync(carId);
            if(car != null)
            {
                return new GetCarDTO(car.Id, car.Name, car.EngineCapacity, car.EngineId,  car.FuelCapacity, car.BrakeId, car.Seats, car.ManufacturerId, car.ColorId);
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
                oldCar.EngineId = carDTO.EngineId;
                oldCar.FuelCapacity = carDTO.FuelCapacity;
                oldCar.BrakeId = carDTO.BrakeId;
                oldCar.Seats = carDTO.Seats;
                oldCar.ManufacturerId = carDTO.ManufacturerId;
                oldCar.ColorId = carDTO.ColorId;    

                await _carRepository.UpdateAsync(id, oldCar);
                return new GetCarDTO(oldCar.Id, oldCar.Name, oldCar.EngineCapacity, oldCar.EngineId,  oldCar.FuelCapacity, oldCar.BrakeId, oldCar.Seats, oldCar.ManufacturerId, oldCar.ColorId);
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
        public Task<IEnumerable<Engine>> GetAllEnginesAsync()
        {
            return _carRepository.GetAllEnginesAsync();
        }

        public Task<IEnumerable<Brake>> GetAllBrakesAsync()
        {
            return _carRepository.GetAllBrakesAsync();
        }

        public async Task<IEnumerable<GetCarDTO>> GetFilteredCarDTOList(string filter)
        {
            var filteredCarList = await _carRepository.GetCarFilterAsync(filter);
            var filteredCarDTOList = filteredCarList.Select( car => new GetCarDTO(
                    car.Id, car.Name, car.EngineCapacity, car.EngineId, car.FuelCapacity, car.BrakeId, car.Seats, car.ManufacturerId, car.ColorId
                ));
            return filteredCarDTOList;
        }

        public async Task<IEnumerable<GetCarDTO>> GetAdvanceFilteredCarDTOList(GetCarDTO carDTO)
        {
            var advanceFilteredCarList = await _carRepository.GetCarAdvanceFilterAsync(new Car()
            {
                Name = carDTO.Name,
                EngineCapacity = carDTO.EngineCapacity,
                EngineId = carDTO.EngineId,
                FuelCapacity = carDTO.FuelCapacity,
                BrakeId = carDTO.BrakeId,
                Seats = carDTO.Seats,
                ManufacturerId = carDTO.ManufacturerId,
                ColorId = carDTO.ColorId,
            });

            var advanceFilteredCarDTOList = advanceFilteredCarList.Select( car => new GetCarDTO(
                    car.Id, car.Name, car.EngineCapacity, car.EngineId, car.FuelCapacity, car.BrakeId, car.Seats, car.ManufacturerId, car.ColorId
                ));
            return advanceFilteredCarDTOList;
        }

        public async Task<(IEnumerable<GetCarDTO>, int)> GetPaginatedCarDTOList(int page, int pageSize)
        {

            var paginatedCarListAndTotalPages = await _carRepository.GetPaginatedData(page, pageSize);
            var paginatedCarDTOList = paginatedCarListAndTotalPages.Item1.Select(car => new GetCarDTO(
                       car.Id, car.Name, car.EngineCapacity, car.EngineId, car.FuelCapacity, car.BrakeId, car.Seats, car.ManufacturerId, car.ColorId
                   ));
            return (paginatedCarDTOList, paginatedCarListAndTotalPages.Item2);
        }

        public async Task<(IEnumerable<GetCarDTO>, int)> GetPaginatedFilteredCarDTOList(int page, int pageSize, string filter)
        {
            var paginatedCarFilteredListAndTotalPages = await _carRepository.GetPaginatedCarFiltersAsync(page, pageSize, filter);
            var paginatedCarDTOFilteredList = paginatedCarFilteredListAndTotalPages.Item1.Select(car => new GetCarDTO(
                    car.Id, car.Name, car.EngineCapacity, car.EngineId, car.FuelCapacity, car.BrakeId, car.Seats, car.ManufacturerId, car.ColorId
                ));
            return (paginatedCarDTOFilteredList, paginatedCarFilteredListAndTotalPages.Item2);
        }

        public async Task<(IEnumerable<GetCarDTO>, int)> GetPaginatedAdvanceFilteredCarDTOList(int page, int pageSize, GetCarDTO carDTO)
        {
            var paginatedAdvanceFilteredCarListAndTotalPages = await _carRepository.GetPaginatedAdvanceCarFiltersAsync(page, pageSize, new Car()
            {
                Id = carDTO.Id,
                Name = carDTO.Name,
                EngineCapacity = carDTO.EngineCapacity,
                EngineId = carDTO.EngineId,
                FuelCapacity = carDTO.FuelCapacity,
                BrakeId = carDTO.BrakeId,
                Seats = carDTO.Seats,
                ManufacturerId = carDTO.ManufacturerId,
                ColorId = carDTO.ColorId
            });
            var paginatedAdvanceFilteredCarDTOList = paginatedAdvanceFilteredCarListAndTotalPages.Item1.Select(car => new GetCarDTO(car.Id, car.Name, car.EngineCapacity, car.EngineId, car.FuelCapacity, car.BrakeId, car.Seats, car.ManufacturerId, car.ColorId));

            return (paginatedAdvanceFilteredCarDTOList, paginatedAdvanceFilteredCarListAndTotalPages.Item2);

        }
    }
}
