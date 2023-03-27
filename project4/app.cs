using System;

class Program
{
    static void Main(string[] args)
    {
        // Display the offerings of Royal Caribbean Cruise Lines
        Console.WriteLine("Welcome to Royal Caribbean Cruise Lines!");
        Console.WriteLine("We sail to several destinations including The Bahamas, Bermuda, The Caribbean, Cuba, and The Panama Canal.");
        Console.WriteLine("Our ships include Allure of the Seas, Anthem of the Seas, Harmony of the Seas, Oasis of the Seas, and Symphony of the Seas.");

        // Get the user's selection for stateroom and ship
        Console.WriteLine("\nPlease choose your stateroom type:");
        Console.WriteLine("1. Interior ($599pp)");
        Console.WriteLine("2. Ocean View ($699pp)");
        Console.WriteLine("3. Balcony ($799pp)");
        Console.WriteLine("4. Royal Suite Class ($1,999pp) for Mid Deck");
        Console.Write("Enter your selection (1-4): ");
        int stateroomSelection = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPlease choose your ship:");
        Console.WriteLine("1. Allure of the Seas (+15%)");
        Console.WriteLine("2. Anthem of the Seas (+20%)");
        Console.WriteLine("3. Harmony of the Seas (-10%)");
        Console.WriteLine("4. Oasis of the Seas (base price)");
        Console.WriteLine("5. Symphony of the Seas (+5%)");
        Console.Write("Enter your selection (1-5): ");
        int shipSelection = int.Parse(Console.ReadLine());

        // Calculate the stateroom price based on the user's selection
        double stateroomPrice = 0;
        switch (stateroomSelection)
        {
            case 1:
                stateroomPrice = 599;
                break;
            case 2:
                stateroomPrice = 699;
                break;
            case 3:
                stateroomPrice = 799;
                break;
            case 4:
                stateroomPrice = 1999;
                break;
            default:
                Console.WriteLine("Invalid selection.");
                return;
        }

        // Calculate the ship price based on the user's selection
        double shipPrice = 0;
        switch (shipSelection)
        {
            case 1:
                shipPrice = stateroomPrice * 1.15;
                break;
            case 2:
                shipPrice = stateroomPrice * 1.20;
                break;
            case 3:
                shipPrice = stateroomPrice * 0.90;
                break;
            case 4:
                shipPrice = stateroomPrice;
                break;
            case 5:
                shipPrice = stateroomPrice * 1.05;
                break;
            default:
                Console.WriteLine("Invalid selection.");
                return;
        }

        // Get the user's selection for excursions and drinks
        Console.WriteLine("\nExcursions are available for Cultural Sightseeing, Snorkeling, and Scuba Diving.");
        Console.WriteLine("Cultural Sightseeing costs $150pp and Snorkeling costs $100pp.");
        Console.WriteLine("Scuba Diving costs $599pp (group of 6) which includes gear rental, 4 Open Water Dives, Pool Sessions, and Transportation.");
        Console.WriteLine("Private lessons are available for an additional $100.");
        Console.Write("Do you want to go Scuba Diving? (Y/N): ");
        bool scubaDiving = Console.ReadLine().ToUpper() == "Y";

        Console.Write("Do you want to go Cultural Sightseeing? (Y/N): ");
        bool culturalSightseeing = Console.ReadLine().ToUpper() == "Y";

        Console.Write("Do you want to go Cultural Sightseeing? (Y/N): ");
        bool culturalSightseeing = Console.ReadLine().ToUpper() == "Y";

        // Get the user's selection for drink packages
        Console.WriteLine("\nDrink packages are available:");
        Console.WriteLine("1. Alcoholic Drinks, Specialty Coffee and Tea, Soda and Bottled Water - $150pp");
        Console.WriteLine("2. Specialty Coffee and Tea, Soda and Bottled Water - $75pp");
        Console.WriteLine("3. Soda and Bottled Water - $25pp");
        Console.WriteLine("4. No beverage package");

        Console.Write("Enter your selection for drink package (1/2/3/4): ");
        int drinkPackageSelection = int.Parse(Console.ReadLine());

        // Calculate the cost of the selected drink package
        double drinkPackageCost = 0;
        switch (drinkPackageSelection)
        {
            case 1:
                drinkPackageCost = 150;
                break;
            case 2:
                drinkPackageCost = 75;
                break;
            case 3:
                drinkPackageCost = 25;
                break;
            case 4:
                drinkPackageCost = 0;
                break;
            default:
                Console.WriteLine("Invalid selection. No beverage package selected.");
                break;
        }

        // Get the user's personal information and credit card details
        Console.WriteLine("\nPlease enter your personal information and credit card details:");
        Console.Write("First name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Address: ");
        string address = Console.ReadLine();
        Console.Write("City: ");
        string city = Console.ReadLine();
        Console.Write("State: ");
        string state = Console.ReadLine();
        Console.Write("Zip code: ");
        string zipCode = Console.ReadLine();
        Console.Write("Credit card type: ");
        string creditCardType = Console.ReadLine();
        Console.Write("Credit card number: ");
        string creditCardNumber = Console.ReadLine();

        // Calculate the total cost of the trip
        double basePrice = GetBasePrice("Oasis of the Seas");
        double roomPrice = GetRoomPrice(basePrice);
        double excursionsPrice = GetExcursionsPrice(scubaDiving, culturalSightseeing);
        double drinkPackagePrice = drinkPackageCost * 2; // Assuming 2 people are traveling
        double totalCost = roomPrice + excursionsPrice + drinkPackagePrice;

        // Print a summary of the user's selections and the total cost
        Console.WriteLine("\nThank you for booking your trip with Royal Caribbean Cruise Lines!");
        Console.WriteLine("Your selections:");
        Console.WriteLine($"- Ship: Oasis of the Seas");
        Console.WriteLine($"- Room type: {GetSelectedRoomType()}");
        Console.WriteLine($"- Excursions: {GetSelectedExcursions(scubaDiving, culturalSightseeing)}");
        Console.WriteLine($"- Drink package: {GetSelectedDrinkPackage(drinkPackageSelection)}");
        Console.WriteLine($"- First name: {firstName}");
        Console.WriteLine($"- Last name: {lastName}");
        Console.WriteLine($"- Address: {address}");
        Console.WriteLine($"- City: {city}");

    }

}



