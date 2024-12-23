﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project6_ApiWeather.Context;
using Project6_ApiWeather.Entities;

namespace Project6_ApiWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        WeatherContext context= new WeatherContext();

        [HttpGet]
        public IActionResult WeatherCityList() 
        {
            var values= context.Cities.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateWeatherCity(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return Ok("Şehir Eklendi");
        }

        [HttpDelete]

        public IActionResult DeleteWeatherCity(int id) 
        {
            var value = context.Cities.Find(id);
            context.Cities.Remove(value);
            context.SaveChanges();
            return Ok("Şehir Silindi");
        }

        [HttpPut]

        public IActionResult UpdateWeatherCity(City city) 
        {
            var value = context.Cities.Find(city.CityId);
            value.CityName = city.CityName; 
            value.Details = city.Details;
            value.Temp = city.Temp;
            value.Country = city.Country;
            context.SaveChanges();
            return Ok("Şehir Güncellendi");
        }

        [HttpGet("GetByIdWeatherCity")]
        public IActionResult GetByIdWeatherCity(int id) 
        {
            var value = context.Cities.Find(id);
            return Ok(value);
        }

        [HttpGet("TotalCityCount")]
        public IActionResult TotalCityCount()
        {
            var values = context.Cities.Count();
            return Ok(values);
        }

        [HttpGet("MaxTempCity")]

        public IActionResult MaxTempCity() 
        {
            var values = context.Cities.OrderByDescending(x => x.Temp).Select(y => y.CityName).FirstOrDefault();
            return Ok(values);
        }

        [HttpGet("MinTempCity")]

        public IActionResult MinTempCity()
        {
            var values = context.Cities.OrderBy(x => x.Temp).Select(y => y.CityName).FirstOrDefault();
            return Ok(values);
        }
    }
}
