using System.Collections.Generic;
using HotelApi.Models;

namespace HotelApi.Services
{
    public interface IHotelService
    {
        public List<Root> FetchHotels();
    }
}
