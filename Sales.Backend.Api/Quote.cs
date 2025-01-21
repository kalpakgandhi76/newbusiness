namespace Models;

public class Quote
{
    public Customer profile { get; set; }

    public List<Vehicle> vehicles { get; set; }

    public string quoteNumber { get; set; }

    public int quotePrice { get; set; }
}

public class Vehicle
{
    public string Make { get; set; }

    public string Model { get; set; }

    public int Year { get; set; }
}

public class Customer
{
    public string firstName { get; set; }

    public string lastName { get; set; }

    public int ZipCode { get; set; }
}