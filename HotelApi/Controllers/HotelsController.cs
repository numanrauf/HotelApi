using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HotelApi.Models;
using HotelApi.Services;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }


        [HttpGet]
        public IActionResult GetHotels(int hotelId, DateTime date)
        {

            var resultOutput = new List<ResultOutput>();
            foreach (var hotel in _hotelService.FetchHotels().Where(hotel => hotel.hotel.hotelID == hotelId))
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

