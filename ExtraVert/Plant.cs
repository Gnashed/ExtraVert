public class Plant
{
    public string Species { get; set; }
    public int LightNeeds { get; set; } // 1 is shade, 5 is full sun.
    public decimal AskingPrice { get; set; }
    public string City { get; set; }
    public int ZipCode { get; set; }
    public bool isSold { get; set; }
    
    // Constructor
    public Plant(
        string species,
        int lightNeeds,
        decimal askingPrice,
        string city,
        int zipCode,
        bool sold
        )
    {
        Species = species;
        LightNeeds = lightNeeds;
        AskingPrice = askingPrice;
        City = city;
        ZipCode = zipCode;
        isSold = sold;
    }
}