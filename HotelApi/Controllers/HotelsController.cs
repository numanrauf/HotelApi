using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Models;
using Newtonsoft.Json;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHotels(int hotelId, DateTime date)
        {
            List<Root> hotelsList;
            using (var r = new StreamReader("hotelrates.json"))
            {
                var json = r.ReadToEnd();
                hotelsList = JsonConvert.DeserializeObject<List<Root>>(json);
            }

            var resultOutput = new List<ResultOutput>();
            foreach (var hotel in hotelsList.Where(hotel => hotel.hotel.hotelID == hotelId))
            {
                var targetRateList = hotel.hotelRates.Where(targetRates => targetRates.targetDay.ToString("MM/dd/yyyy") == date.ToString("MM/dd/yyyy")).ToList();

                resultOutput.Add(new ResultOutput
                {
                    hotel = hotel.hotel,
                    HotelRate = targetRateList
                });
                return Ok(resultOutput);
            }
            return NotFound("No Record found");
        }
    }
}

