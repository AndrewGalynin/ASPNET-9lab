using System;
using System.Net.Http;
using System.Threading.Tasks;

public class WeatherService
{
    private readonly string apiKey = "74c659172edb2b620813acbc9c8e6750"; // API ключ для доступу до сервісу погоди

    public WeatherService(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public async Task<string> GetWeatherInfoAsync(string city)
    {
        string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                if (weatherData != null)
                {
                    string description = weatherData.weather[0].description;
                    double temperature = Convert.ToDouble(weatherData.main.temp) - 273.15; // Convert from Kelvin to Celsius
                    return $"Weather in {city}: {description}, Temperature: {temperature:F1}°C";
                }
            }

            return "Weather data not available.";
        }
    }
}

