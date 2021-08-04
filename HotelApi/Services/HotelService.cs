using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Models;
using Newtonsoft.Json;

namespace HotelApi.Services
{
    public class HotelService : IHotelService
    {
        public List<Root> FetchHotels()
        {
            List<Root> hotelsList;
            using (var r = new StreamReader("hotelrates.json"))
            {
                var json = r.ReadToEnd();
                hotelsList = JsonConvert.DeserializeObject<List<Root>>(json);
            }

            return hotelsList;
        }
    }
}
