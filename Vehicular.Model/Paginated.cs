using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicular.DTOs;

namespace Vehicular.Model
{
    public class Paginated
    {
        public IEnumerable<GetCarDTO> CarDTOs { get; set; }
        public int TotalPages { get; set; }
    }
}
