using lab_9.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        var items = new List<ObjectItem>
        {
            new ObjectItem { ID = 1, Name = "Item 1", Price = 10.5m },
            new ObjectItem { ID = 2, Name = "Item 2", Price = 20.0m },
            new ObjectItem { ID = 3, Name = "Item 3", Price = 15.75m }
        };

        return View("ObjectTable", items);
    }

    public ActionResult Weather()
    {
        string weatherInfo = GetWeatherInfo("New York"); 

        return View("WeatherComponent", (object)weatherInfo);
    }

    private string GetWeatherInfo(string region)
    {
        Random rnd = new Random();
        double temperature = 20 + rnd.NextDouble() * 15; // Генеруємо випадкову температуру від 20 до 35 градусів Цельсія
        return $"Weather in {region}: Sunny, Temperature: {temperature:F1}°C";
    }
}
