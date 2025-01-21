using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("api/[controller]/quote")]
public class AgentController : ControllerBase
{
    private readonly ILogger<AgentController> _logger;   

    public AgentController(ILogger<AgentController> logger)
    {
        _logger = logger;   
    }

    [HttpGet()]
    public ActionResult<Quote> Quote()
    {
       _logger.LogInformation("Quote Action called");
       var quote = CreateQuote();
       _logger.LogInformation(message: "Quote Object ::", quote);
       return quote;
    }

    private static Quote CreateQuote()
    {
        var vehicle1 = new Vehicle{
            Make = "Audi",
            Model = "Q5",
            Year = 2022         
        };
        var vehicle2 = new Vehicle{
            Make = "Tesla",
            Model = "Model3",
            Year = 2024       
        };
        var vehicleList = new List<Vehicle>
        {
            vehicle1,
            vehicle2
        };
        var customer = new Customer{
            firstName = "John",
            lastName = "Doe",
            ZipCode = 21704
        };
        return new Quote{
            profile = customer,
            vehicles = vehicleList,
            quoteNumber = "ACQ" + GenerateRandomAlphanumeric(10),
            quotePrice = GenerateRandomPrice(700,2000)
        };
    }

    public static string GenerateRandomAlphanumeric(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";  // Alphanumeric characters
        Random random = new Random();
        char[] stringChars = new char[length];

        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);
    }

    public static int GenerateRandomPrice(int minPrice, int maxPrice)
    {
        Random random = new Random();
        
        // Generate random decimal within the specified range        
        var randomValue = random.Next(minPrice, maxPrice + 1);
        
        // Return the price rounded to 2 decimal places
        return randomValue;
    }
}
