// See https://aka.ms/new-console-template for more information

List<Plant> plants = new List<Plant>()
{
    new Plant("Sunflower", 4, 12.99M, "Nashville", 37211, false),
    new Plant("Roses", 3, 19.99M, "Smyrna", 37000, false),
    new Plant("Dandelion", 3, 6.99M, "New York", 10001, false),
    new Plant("Aloe",4,15.99M,"Tampa Bay",32000,false),
    new Plant("Cannabis",4,45.00M,"Detroit",48200,false)
};

void displayPlants()
{
    int counter = 0;
    foreach (Plant plant in plants)
    { 
        Console.WriteLine($"{++counter}. {plant.Species} in {plant.City} {(plant.isSold ? "was sold":"is available")} for ${plant.AskingPrice} dollars.");
    }
}

// User needs to enter a species (string), lightNeeds (int), askingPrice (decimal), city (string),
// zipCode (int)
void postAPlant()
{   
    Console.WriteLine("Please fill out the plant details below.");
    
    Console.Write("What's the plant name?: ");
    string? species = Console.ReadLine();
    Console.Write("What's the plant's light needs? Scale 1 to 5 (5 highest, 1 lowest): ");
    int lightNeeds = Convert.ToInt32(Console.ReadLine());
    Console.Write("How much are you asking for? ");
    decimal askingPrice = Convert.ToDecimal(Console.ReadLine());
    Console.Write("What city are you located in? ");
    string? city = Console.ReadLine();
    Console.Write("What's the zip code? ");
    int zipCode = Convert.ToInt32(Console.ReadLine());
    
    // Process the user's inputs
    plants.Add(new Plant(species, lightNeeds, askingPrice, city, zipCode, false));
    Console.WriteLine("Plant added to the list! Here is the updated records:");
    displayPlants();
}

// MENU
void plantMenu()
{
    Console.WriteLine();
    Console.WriteLine("Please choose one of the following options: ");
    Console.WriteLine("a: Display all plants.");
    Console.WriteLine("b: Post a plant to be adopted.");
    Console.WriteLine("c: Adopt a plant today!");
    Console.WriteLine("d: De-list a plant.");
    Console.WriteLine("e: Exit the program.");
    string response = Console.ReadLine().Trim();

    // PROCESS MENU RESPONSE
    switch (response?.ToLower())
    {
        case "a":
            Console.WriteLine("Showing all plants...");
            displayPlants();
            plantMenu();
            break;
        case "b":
            Console.WriteLine("Post a plant to be adopted...");
            postAPlant();
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
            Console.WriteLine();
            Console.Clear();
            plantMenu();
            break;
    };
}

// STARTUP GREETING AND PROMPT USER TO MAKE A SELECTION IN THE MENU.
string greeting = "Welcome to Tion's Plant Shop!";
Console.WriteLine(greeting);
plantMenu();

#region beforeTurningToMethod
// STARTUP GREETING AND PROMPT USER TO MAKE A SELECTION IN THE MENU.
// string greeting = "Welcome to Tion's Plant Shop!";
// Console.WriteLine(greeting);
// plantMenu();

// Console.WriteLine("Please choose one of the following options: ");
// Console.WriteLine("a: Display all plants.");
// Console.WriteLine("b: Post a plant to be adopted.");
// Console.WriteLine("c: Adopt a plant today!");
// Console.WriteLine("d: De-list a plant.");
// Console.WriteLine("e: Exit the program.");
// string response = Console.ReadLine().Trim();
//
// // PROCESS MENU RESPONSE
// switch (response?.ToLower())
// {
//     case "a":
//         Console.WriteLine("Showing all plants...");
//         foreach (Plant plant in plants)
//         { 
//             Console.WriteLine(plant.Species);
//             Console.WriteLine(plant.LightNeeds);
//             Console.WriteLine(plant.AskingPrice);
//             Console.WriteLine(plant.City);
//             Console.WriteLine(plant.ZipCode);
//             Console.WriteLine($"Sold out? {plant.isSold}");
//             Console.WriteLine($"Regulated? {plant.isRegulated}");
//             Console.WriteLine();
//             Console.WriteLine();
//         } break;
//     case "b":
//         Console.WriteLine("Post a plant to be adopted...");
//         break;
//     case "c":
//         Console.WriteLine("Which plant do you want to adopt?");
//         break;
//     case "d":
//         Console.WriteLine("Select a plant to de-list:");
//         break;
//     case "e":
//         Console.WriteLine("Terminating program...");
//         break;
//     default:
//         Console.WriteLine("Invalid response. Please try again. ");
//         break;
// };
#endregion
