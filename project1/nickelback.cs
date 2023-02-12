/******************************************************************************

Student name: Maminiaina Ravaloarison
Project     : NickelBack
Date        : February 11, 2023

*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
      
    /*
        ~~~~~~~~~~~~~~~ VARIABLES ~~~~~~~~~~~~~~~
    */
    //    For First Operation
    string item       = "";
    double amountPaid = 0;
    double cost       = 0;
    double change     = 0;
    

    //    For decomposing
    string[] billsValue = {"Fifty","Twenty","Ten","Five","One"};
    int[] bills         = { 50,     20,      10,   5,     1 };
    int countBills      = 0;  
    
    string[] coinsValue = {"FiftyCent","Quarter","Dime","Nickel","Penny"};
    double[] coins      = { 0.50,       0.25,     0.10,  0.05,    0.01 };
    int countCoins      = 0;
    /*
        ~~~~~~~~~~~~~~~ END VARIABLES ~~~~~~~~~~~~~~~
    */
    
    
    
    
    /*
        ~~~~~~~~~~~~~~~ FIRST OPERATION ~~~~~~~~~~~~~~~
    */
    Console.Write("What did you buy: ");
    item = Console.ReadLine();

    // Make sure cost < 100
    do
    {
        Console.Write("How much does the " + item + " cost: $");
        cost = Convert.ToDouble(Console.ReadLine());
    
        if (cost > 100) Console.WriteLine("Sorry, the cost cannot be over $100.");
    } while (cost > 100);
    

    // Make sure amount paid < 100
    do
    {
        Console.Write("How much was paid: $");
        amountPaid = Convert.ToDouble(Console.ReadLine());
    
        if (amountPaid > 100) Console.WriteLine("Sorry, the amount paid cannot be over $100.");
    } while (amountPaid > 100);
    

    change = amountPaid - cost;
    Console.WriteLine("Your change is: $" + change);
    /*
        ~~~~~~~~~~~~~~~ END FIRST OPERATION ~~~~~~~~~~~~~~~
    */
    
    
    Console.WriteLine("You get back:");
    /*
        ~~~~~~~~~~~~~~~ DECOMPOSING CHANGE ~~~~~~~~~~~~~~~
    */
    // loop over bills & bills value
    for (int i = 0; i < bills.Length; i++)
    {
        countBills = (int) (change / bills[i]);
        if (countBills > 0)
        {
            change -= countBills * bills[i];
            Console.WriteLine(countBills + " " + billsValue[i]);
        }
    }

    // loop over coins and coins value
    for (int i = 0; i < coins.Length; i++)
    {
        countCoins = (int) (change / coins[i]);
        if (countCoins > 0)
        {
            change -= countCoins * coins[i];
            Console.WriteLine(countCoins + " " + coinsValue[i]);
        }
    }
    /*
        ~~~~~~~~~~~~~~~ END DECOMPOSITION ~~~~~~~~~~~~~~~
    */

  }
}