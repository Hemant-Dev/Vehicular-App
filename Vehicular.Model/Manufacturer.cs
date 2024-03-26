using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicular.Model
{
    [Table("ManufacturerInfo")]
    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int manufacturerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string manufacturerName { get; set; }

    }
}
