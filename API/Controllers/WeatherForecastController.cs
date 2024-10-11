using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class WeatherForecastController : BaseApiController
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public WeatherForecastController()
    {
        // ctor
        // var a = new WeatherForecast()
        // {
        //     Date = new DateOnly(),
        //     TemperatureC = 2,
        //     Summary = "2"
        // };
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("index")]
    public IEnumerable<WeatherForecast> Get()
    {
        var result = Enumerable.Range(1,5).Select(index => new WeatherForecast{
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });

        return result.ToArray();

        // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        // {
        //     Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //     TemperatureC = Random.Shared.Next(-20, 55),
        //     Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        // })
        // .ToArray();
    }


    [HttpGet]
    [Route("test")]
    public IEnumerable<WeatherForecast> GetFirstThree()
    {
        return Enumerable.Range(1, 3).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }


    // [HttpPost]
    // [Route("add")]
    // public bool AddForecast(WeatherForecast model){
    //     if(model == null){
    //         throw new Exception("Bad model");
    //         return false;
    //     }

    //     // logic
    //     return true;
    // }
}