using System.ComponentModel.DataAnnotations;

namespace Vehicular.DTOs
{

    public record CreateCarDTO([Required(ErrorMessage = "Car Name is required.")] string Name, [Required(ErrorMessage = "Engine Capacity is required.")] int EngineCapacity, [Required(ErrorMessage = "Engine Id is required.")] int EngineId, [Required(ErrorMessage = "Fuel Capacity is required.")] decimal FuelCapacity, [Required(ErrorMessage = "Brake Id is required.")] int BrakeId, [Required(ErrorMessage = "Seat Capacity is required")] int Seats, [Required(ErrorMessage = "ManufacturerId is Required.")] int ManufacturerId, [Required(ErrorMessage = "ColorId is required.")] int ColorId);
    public record UpdateCarDTO([Required(ErrorMessage ="Car Id is required.")] int Id, [Required(ErrorMessage = "Car Name is required.")] string Name, [Required(ErrorMessage = "Engine Capacity is required.")] int EngineCapacity, [Required(ErrorMessage = "Engine Id is required.")] int EngineId, [Required(ErrorMessage = "Fuel Capacity is required.")] decimal FuelCapacity, [Required(ErrorMessage = "Brake Id is required.")] int BrakeId, [Required(ErrorMessage = "Seat Capacity is required")] int Seats, [Required(ErrorMessage = "ManufacturerId is Required.")] int ManufacturerId, [Required(ErrorMessage = "ColorId is required.")] int ColorId);

    public record GetCarDTO(int Id, string Name, int EngineCapacity, int EngineId, decimal FuelCapacity,
                            int BrakeId, int Seats, int ManufacturerId, int ColorId);    
}
