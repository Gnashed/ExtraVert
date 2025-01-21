// See https://aka.ms/new-console-template for more information

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Sunflower",
        LightNeeds = 4,
        AskingPrice = 12.99M,
        City = "Nashville",
        ZipCode = 37211,
        isSold = false
    },
    new Plant()
    {
        Species = "Roses",
        LightNeeds = 3,
        AskingPrice = 19.99M,
        City = "Smyrna",
        ZipCode = 37000,
        isSold = false,
        isRegulated = false,
    },
    new Plant()
    {
        Species = "Dandelion",
        LightNeeds = 3,
        AskingPrice = 6.99M,
        City = "New York",
        ZipCode = 10001,
        isSold = false,
        isRegulated = false
    },
    new Plant()
    {
        Species = "Aloe",
        LightNeeds = 4,
        AskingPrice = 15.99M,
        City = "Tampa Bay",
        ZipCode = 32000,
        isSold = false,
        isRegulated = false
    },
    new Plant()
    {
        Species = "Cannabis",
        LightNeeds = 4,
        AskingPrice = 45.00M,
        City = "Detroit",
        ZipCode = 48200,
        isSold = false,
        isRegulated = true
    }
};

// STARTUP
Console.WriteLine("Welcome to Tion's Plant Shop!");
Console.WriteLine();
// Loop through plants
foreach (Plant plant in plants)
{
    Console.WriteLine(plant.Species);
    Console.WriteLine(plant.LightNeeds);
    Console.WriteLine(plant.AskingPrice);
    Console.WriteLine(plant.City);
    Console.WriteLine(plant.ZipCode);
    Console.WriteLine($"Sold out? {plant.isSold}");
    Console.WriteLine($"Regulated? {plant.isRegulated}");
    Console.WriteLine();
    Console.WriteLine();
}