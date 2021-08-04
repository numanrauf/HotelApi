using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Models
{
    public class ResultOutput
    {
        public Hotel hotel { get; set; }
        public List<HotelRate> HotelRate { get; set; }
    }
}
