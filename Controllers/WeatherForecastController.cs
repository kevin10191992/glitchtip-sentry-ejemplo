using Microsoft.AspNetCore.Mvc;
using Sentry;

namespace sentry_ejemplo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/hello")]
    public async Task<ActionResult> Hello(int time)
    {

        await Task.Delay(time);
        return Ok("hello after " + time);

    }

    [HttpGet(Name = "GetWeatherForecast")]
    public string Get()
    {
        try
        {

            throw new Exception("ee");
            var a = Enumerable.Range(1, 5).ToArray();
            return string.Join(",", a);
        }
        catch (Exception ex)
        {
            SentrySdk.CaptureException(ex);
            return "ha ocurrido un error";
        }



    }
}
