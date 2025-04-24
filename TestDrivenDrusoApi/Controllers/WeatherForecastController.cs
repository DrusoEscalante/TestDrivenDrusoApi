using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using TestDrivenDrusoApi.Data;

namespace TestDrivenDrusoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly MyContext _myContext;


       
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        //test
        public WeatherForecastController(ILogger<WeatherForecastController> logger,MyContext context)
        {
            _logger = logger;
            _myContext = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Test")]
        public IActionResult getTest()
        {
            return Ok("Hello");
        }

        [HttpGet("testConnection")]
        public IActionResult testConnection()
        {
            string connectionString = "Data Source=CS-21\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                return Ok("Connected");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("testContext")]
        public IActionResult testContext()
        {
            if (_myContext != null)
            {
                return Ok("nice");
            }
            else {
                return StatusCode(500,"not good");
            }
        }

        [HttpGet("getCustomers")]
        public IActionResult getCustomers()
        {
            return Ok(_myContext.Customers.ToList());
        }
    }
}
