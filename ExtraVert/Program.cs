// See https://aka.ms/new-console-template for more information

List<Plant> plants = new List<Plant>()
{
    new Plant("Sunflower", 4, 12.99M, "Nashville", 37211, availableUntil: new DateTime(2025, 2, 12), sold: false),
    new Plant("Roses", 3, 19.99M, "Smyrna", 37000, availableUntil: new DateTime(2025, 1, 31), sold: false),
    new Plant("Dandelion", 3, 6.99M, "New York", 10001, availableUntil: new DateTime(2025, 2, 10), sold: false),
    new Plant("Aloe",4,15.99M,"Tampa Bay",32000, availableUntil: new DateTime(2025, 3, 21), sold: false),
    new Plant("Cannabis",4,45.00M,"Detroit",48200, availableUntil: new DateTime(2025, 3, 2), sold: false)
};

// For Showcasing Plant of the Day
void PlantOfTheDay()
{
    Random randomIndex = new Random();
    int randomInteger = randomIndex.Next(1, plants.Count);
    while (plants[randomInteger].IsSold)
    {
        randomInteger = randomIndex.Next(1, plants.Count);
    }
    Console.WriteLine($"{plants[randomInteger].Species} in {plants[randomInteger].City} " +
                      $"{(plants[randomInteger].IsSold ? "was sold":"is available")} for " +
                      $"${plants[randomInteger].AskingPrice} dollars.");
}

void DisplayPlants()
{
    int counter = 0;
    DateTime currentDate = DateTime.Today;
    foreach (Plant plant in plants)
    {
        if (!plant.IsSold && currentDate < plant.AvailableUntil)
        {
            Console.WriteLine($"{++counter}. {plant.Species} in {plant.City} {(plant.IsSold ? "was sold":"is available")} " +
                              $"for ${plant.AskingPrice} dollars. This post will expire on {plant.AvailableUntil}");
        }
    }
}

void PostAPlant()
{   
    Console.WriteLine("Please fill out the plant details below.");
    
    string? species;
    while (true)
    {
        Console.Write("What's the plant name?: ");
        species = Console.ReadLine();
        
        if (string.IsNullOrEmpty(species))
        {
            Console.WriteLine("You must enter a name for the species. Try again");
            continue;
        }
        break;
    }
    
    int lightNeeds;
    while (true)
    {
        Console.WriteLine("What's the plant's light needs? Scale 1 to 5 (5 highest, 1 lowest): ");
        if (int.TryParse(Console.ReadLine(), out lightNeeds) && lightNeeds is >= 1 and <= 5)
        {
            break;
        }
        Console.WriteLine("Invalid input. Please try again with a number between 1 and 5.");
    }

    decimal askingPrice;
    while (true)
    {
        Console.WriteLine("How much are you asking for? ");
        if (decimal.TryParse(Console.ReadLine(), out askingPrice) && askingPrice is > 0)
        {
            break;
        }
        Console.WriteLine("Invalid input. Please try again by entering a dollar amount. Ex. 12.99: ");
    }

    string? city;
    while (true)
    {
        Console.Write("What city are you located in? ");
        city = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(city))
        {
            Console.WriteLine("You must enter a name for the city. Try again.");
            continue;
        }
        break;
    }

    int zipCode;
    while (true)
    {
        Console.Write("What's the zip code? ");
        if (int.TryParse(Console.ReadLine(), out zipCode) && zipCode is > 9999 and < 99999)
        {
            Console.Clear();
            break;
        }
        // Else ...
        Console.Clear();
        Console.WriteLine("Invalid input. Please enter a valid zip code. ");
    }
    
    // For collecting the date that the user wants the post to expire on.
    int year;
    int month;
    int day;
    DateTime dateToExpire;

    while (true)
    {
        Console.WriteLine("Enter the year: ");
        if (int.TryParse(Console.ReadLine(), out year) && year is >= 2025)
        {
            Console.WriteLine("Enter the month: ");
            if (int.TryParse(Console.ReadLine(), out month) && month is >= 1 and < 13)
            {
                Console.WriteLine("Enter the day: ");
                if (int.TryParse(Console.ReadLine(), out day) && day is >= 1 and < 32)
                {
                    dateToExpire = new DateTime(year, month, day);
                    Console.WriteLine($"This post will expire on {dateToExpire}.");
                    break;
                }
                Console.WriteLine("Invalid input. Please try again with a number between 1 and 31.");
            }
            Console.WriteLine("Invalid input. Please try again with a number between 1 and 12.");
        }
        Console.WriteLine("Invalid input. Please try again with a year no earlier than 2025.");
    }
    
    // Process the user's inputs
    plants.Add(new Plant(species, lightNeeds, askingPrice, city, zipCode, dateToExpire, sold: false));
    Console.WriteLine("Plant added to the list! Here are the updated records:");
    DisplayPlants();
}

// When the user choose a plant, change its Sold property to be true.
void AdoptAPlant()
{
    while (true)
    {
        DisplayPlants();
        Console.Write("Enter the number that corresponds to the plant you are wanting to adopt: ");

        try
        {
            int userSelection = Convert.ToInt32(Console.ReadLine()?.Trim());

            if (userSelection < 1 || userSelection > plants.Count)
            {
                Console.WriteLine("The number is out of range. Please select a valid option.");
                continue;
            }

            plants[userSelection - 1].IsSold = true;
            Console.WriteLine($"{plants[userSelection - 1].Species} is now sold!");
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
    }
    PlantMenu();
}

void DelistPlant()
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
            DisplayPlants();
            break; // Without this the loop is infinite.
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid selection. Please pick a number from the list.");
        }
    }
    PlantMenu();
}

void FilterList()
{
    int userLightingRequirements;
    while (true)
    {
        Console.WriteLine("Enter a number to filter plants that requires up " +
                          "to (but no more) lighting than the amount you specified: ");
        if(int.TryParse(Console.ReadLine(), out userLightingRequirements) && userLightingRequirements is >= 1 and <= 5)
        {
            List<Plant> filteredPlants = new List<Plant>();
            foreach (Plant plant in plants)
            {
                if (plant.LightNeeds <= userLightingRequirements)
                {
                    filteredPlants.Add(plant);
                }
            }
            Console.WriteLine("Filtered plants: ");
            foreach (Plant plantObj in filteredPlants)
            {
                Console.WriteLine($"\n{plantObj.Species} has a lighting need of {plantObj.LightNeeds} which is " +
                                  $"within your lighting requirements. The asking price is {plantObj.AskingPrice}." +
                                  $" The plant is from {plantObj.City} and {(plantObj.IsSold ? "sold out" : "is available.")}");
            }
            break;
        }
        Console.WriteLine("Invalid input. Please try again with a number between 1 and 5.");
    }
}

// MENU
void PlantMenu()
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
        Console.WriteLine("f: Search inventory for plants that can grow in darker environments.");
        Console.WriteLine("exit: Exit the program.");
        Console.WriteLine();
        string? response = Console.ReadLine()?.Trim();

        // PROCESS MENU RESPONSE
        switch (response?.ToLower().Trim())
        {
            case "a":
                Console.Clear();
                Console.WriteLine("Showing all plants...");
                DisplayPlants();
                continue;
            case "b":
                Console.WriteLine("Post a plant to be adopted...");
                PostAPlant();
                continue;
            case "c":
                Console.WriteLine("Which plant do you want to adopt?");
                AdoptAPlant();
                break;
            case "d":
                DelistPlant();
                break;
            case "e":
                PlantOfTheDay();
                continue;
            case "f":
                FilterList();
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
PlantMenu();
