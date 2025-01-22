// See https://aka.ms/new-console-template for more information

List<Plant> plants = new List<Plant>()
{
    new Plant("Sunflower", 4, 12.99M, "Nashville", 37211, false),
    new Plant("Roses", 3, 19.99M, "Smyrna", 37000, false),
    new Plant("Dandelion", 3, 6.99M, "New York", 10001, false),
    new Plant("Aloe",4,15.99M,"Tampa Bay",32000,false),
    new Plant("Cannabis",4,45.00M,"Detroit",48200,false)
};

// For Showcasing Plant of the Day
void plantOfTheDay()
{
    Random randomIndex = new Random();
    int randomInteger = randomIndex.Next(1, plants.Count);
    
    Console.WriteLine($"{plants[randomInteger].Species} in {plants[randomInteger].City} " +
                      $"{(plants[randomInteger].isSold ? "was sold":"is available")} for " +
                      $"${plants[randomInteger].AskingPrice} dollars.");
}

void displayPlants()
{
    int counter = 0;
    foreach (Plant plant in plants)
    { 
        Console.WriteLine($"{++counter}. {plant.Species} in {plant.City} {(plant.isSold ? "was sold":"is available")} " +
                          $"for ${plant.AskingPrice} dollars.");
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
    while (true)
    {
        displayPlants();
        Console.Write("Enter the number that corresponds to the plant you are wanting to adopt: ");

        try
        {
            int userSelection = Convert.ToInt32(Console.ReadLine().Trim());

            if (userSelection < 1 || userSelection > plants.Count)
            {
                Console.WriteLine("The number is out of range. Please select a valid option.");
                continue;
            }

            plants[userSelection - 1].isSold = true;
            Console.WriteLine($"{plants[userSelection - 1].Species} is now sold!");
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
    }
    plantMenu();
}

void delistPlant()
{
    while (true)
    {
        try
        {
            Console.WriteLine("Please enter the number you want to de-list: ");
            int counter = 0;
            foreach (Plant plant in plants)
            {
                Console.WriteLine($"{++counter}. {plant.Species}");
            }
            int response = Convert.ToInt32(Console.ReadLine());

            if (response < 1 || response > plants.Count)
            {
                Console.WriteLine("Invalid entry. Please try again.");
                continue; // User can try again.
            }
            // If selection is valid, remove it from the list.
            Plant chosenPlant = plants[response - 1];
            plants.Remove(chosenPlant);
            Console.WriteLine("Removed the plant. Here is the updated list:");
            displayPlants();
            break; // Without this the loop is infinite.
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid selection. Please pick a number from the list.");
        }
    }
    plantMenu();
}

// MENU
void plantMenu()
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("Please choose one of the following options: ");
        Console.WriteLine("a: Display all plants.");
        Console.WriteLine("b: Post a plant to be adopted.");
        Console.WriteLine("c: Adopt a plant today!");
        Console.WriteLine("d: De-list a plant.");
        Console.WriteLine("e: Showcase Plant of the Day.");
        Console.WriteLine("exit: Exit the program.");
        string response = Console.ReadLine().Trim();

        // PROCESS MENU RESPONSE
        switch (response?.ToLower().Trim())
        {
            case "a":
                Console.Clear();
                Console.WriteLine("Showing all plants...");
                displayPlants();
                continue;
            case "b":
                Console.WriteLine("Post a plant to be adopted...");
                postAPlant();
                continue;
            case "c":
                Console.WriteLine("Which plant do you want to adopt?");
                adoptAPlant();
                break;
            case "d":
                delistPlant();
                break;
            case "e":
                plantOfTheDay();
                continue;
            case "exit":
                Console.WriteLine("Terminating program...");
                break;
            default:
                Console.WriteLine("Invalid response. Please try again. ");
                Console.WriteLine();
                Console.Clear();
                continue;
        }
        break;
    }
}

// STARTUP GREETING AND PROMPT USER TO MAKE A SELECTION IN THE MENU.
string greeting = "Welcome to Tion's Plant Shop!";
Console.WriteLine(greeting);
plantMenu();
