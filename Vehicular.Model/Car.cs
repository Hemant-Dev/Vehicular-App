using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicular.Model
{
    [Table("CarInfo")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Car Name is required.")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Engine Capacity is required.")]

        public int EngineCapacity { get; set; }
        [Required(ErrorMessage = "Engine Type is required.")]
        [StringLength(25, ErrorMessage = "Type Length cannot be greater than 25 chars")]
        public string EngineType { get; set; }
        [Required(ErrorMessage = "Fuel Capacity is required.")]
        public decimal FuelCapacity { get; set; }
        [Required(ErrorMessage = "Brake Type is required.")]
        [StringLength(50)]
        public string BrakeType { get; set; }
        [Required(ErrorMessage = "Seat Capacity is required")]
        public int Seats { get; set; }

        [ForeignKey(nameof(Manufacturer))]
        [Required(ErrorMessage = "ManufacturerId is Required.")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [Required(ErrorMessage = "ColorId is required.")]
        [ForeignKey(nameof(Color))]
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }
    }
}
