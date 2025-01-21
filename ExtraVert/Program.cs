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

// STARTUP GREETING AND PROMPT USER TO MAKE A SELECTION IN THE MENU.
Console.WriteLine("Welcome to Tion's Plant Shop!");
Console.WriteLine();

// MENU
Console.WriteLine("Please choose one of the following options: ");
Console.WriteLine("a: Display all plants.");
Console.WriteLine("b: Post a plant to be adopted.");
Console.WriteLine("c: Adopt a plant today!");
Console.WriteLine("d: De-list a plant.");
Console.WriteLine("e: Exit the program.");
string response = Console.ReadLine().Trim();

while (response != "e")
{
    
}

// PROCESS MENU RESPONSE
switch (response?.ToLower())
{
    case "a":
        Console.WriteLine("Showing all plants...");
        break;
    case "b":
        Console.WriteLine("Post a plant to be adopted...");
        break;
    case "c":
        Console.WriteLine("Which plant do you want to adopt?");
        break;
    case "d":
        Console.WriteLine("Select a plant to de-list:");
        break;
    case "e":
        Console.WriteLine("Terminating program...");
        break;
    default:
        Console.WriteLine("Invalid response. Please try again. ");
        break;
};

// Loop through plants
// foreach (Plant plant in plants)
// {
//     Console.WriteLine(plant.Species);
//     Console.WriteLine(plant.LightNeeds);
//     Console.WriteLine(plant.AskingPrice);
//     Console.WriteLine(plant.City);
//     Console.WriteLine(plant.ZipCode);
//     Console.WriteLine($"Sold out? {plant.isSold}");
//     Console.WriteLine($"Regulated? {plant.isRegulated}");
//     Console.WriteLine();
//     Console.WriteLine();
// }
