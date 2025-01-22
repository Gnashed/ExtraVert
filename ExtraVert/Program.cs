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

// When the user choose a plant, change its Sold property to be true.
void adoptAPlant()
{
    displayPlants();
    Console.Write("Enter the number that corresponds to the plant you are wanting to adopt: ");
    int userSelection = Convert.ToInt32(Console.ReadLine().Trim());
    // Process user's selection
    switch (userSelection)
    {
        case 1:
            plants[0].isSold = true;
            Console.WriteLine($"{plants[0].Species} is now sold!");
            plantMenu();
            break;
        case 2:
            plants[1].isSold = true;
            Console.WriteLine($"{plants[1].Species} is now sold!");
            plantMenu();
            break;
        case 3:
            plants[2].isSold = true;
            Console.WriteLine($"{plants[2].Species} is now sold!");
            plantMenu();
            break;
        case 4:
            plants[3].isSold = true;
            Console.WriteLine($"{plants[3].Species} is now sold!");
            plantMenu();
            break;
        case 5:
            plants[4].isSold = true;
            Console.WriteLine($"{plants[4].Species} is now sold!");
            plantMenu();
            break;
        case 6:
            plants[5].isSold = true;
            Console.WriteLine($"{plants[5].Species} is now sold!");
            plantMenu();
            break;
        default:
            Console.WriteLine("Please enter a valid number!");
            adoptAPlant();
            break;
    }
}

void delistPlant()
{
    Console.WriteLine("Please enter the number you want to de-list: ");
    int counter = 0;
    foreach (Plant plant in plants)
    {
        Console.WriteLine($"{++counter}. {plant.Species}");
    }
    int response = Convert.ToInt32(Console.ReadLine());
    plants.Remove(plants[response - 1]);
    Console.WriteLine("Removed the plant. Here is the updated list:");
    displayPlants();
    plantMenu();
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
            adoptAPlant();
            break;
        case "d":
            delistPlant();
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
