using System;
using System.Collections.Generic;
using HotelApi.Controllers;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace HotelsApi.Test
{
    [TestFixture]
    public class HotelsTest
    {
        [Test]
        public void TestGetHotels()
        {

            // arrange
            var controller = new HotelsController();

            // act
            var result = controller.GetHotels(7294, Convert.ToDateTime("2016-03-15"));
            var okResult = result as OkObjectResult;

            // assert

            var resultOutput = (List<ResultOutput>) okResult.Value;

            foreach (var output in resultOutput)
            {
                Assert.AreEqual(26, output.HotelRate.Count);
                Assert.AreEqual(7294, output.hotel.hotelID);
            }

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
         

        }
        [Test]
        public void TestGetHotelNotFound()
        {
            // arrange
            var controller = new HotelsController();

            // act
            var result = controller.GetHotels(3584, Convert.ToDateTime("2016-03-15"));
            var notFoundResult = result as NotFoundObjectResult;

            // assert
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(notFoundResult.Value, "No Record found");
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }
    }
}