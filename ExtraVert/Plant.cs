public class Plant
{
    public string Species { get; set; }
    public int LightNeeds { get; set; } // 1 is shade, 5 is full sun.
    public decimal AskingPrice { get; set; }
    public string City { get; set; }
    public int ZipCode { get; set; }
    public bool IsSold { get; set; }
    public DateTime AvailableUntil { get; set; }
    
    // Constructor
    public Plant(
        string species,
        int lightNeeds,
        decimal askingPrice,
        string city,
        int zipCode,
        DateTime availableUntil,
        bool sold
        )
    {
        // Validate inputs before constructing object.
        if (string.IsNullOrWhiteSpace(species))
            throw new ArgumentException("You must enter a name for the species. Try again.");
        
        if (lightNeeds is < 1 or > 5)
            throw new ArgumentOutOfRangeException(nameof(lightNeeds), "Light needs must be a number between 1 and 5. " +
                                                                      "Try again.");
        
        if (askingPrice <= 0)
            throw new ArgumentOutOfRangeException(nameof(askingPrice), "You must enter a " +
                                                                       "value greater than 0. Try again.");

        if (zipCode is < 10000 or > 99999)
            throw new ArgumentOutOfRangeException(nameof(zipCode), "You must enter a valid zipcode. Try again.");
        
        Species = species;
        LightNeeds = lightNeeds;
        AskingPrice = askingPrice;
        City = city;
        ZipCode = zipCode;
        IsSold = sold;
        AvailableUntil = availableUntil;
    }
}