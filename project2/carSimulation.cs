/******************************************************************************

Maminiaina Ravaloarison
IT-260: Advanced Programing

*******************************************************************************/

using System;
using System.Linq;


class Program
{
    // Create an object Car
    public class Car
    {
        private bool isSeatBeltConnected = false;
        private bool areKeysInIgnition   = false;
        public bool isStarted            = false;
        private bool gasPedalEnabled     = false;
        public bool isBlinkerOn          = false;
        public string blinkerState       = "";
        public string gear               = "P";
        private int gasTank              = 100;
        private int speed                = 0; 
        private int distanceTraveled     = 0;
        
        // ✅ Seat Belt Function
        public void ConnectSeatBelt()
        {
            if (!isSeatBeltConnected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                isSeatBeltConnected     = true;
                Console.WriteLine("\nSeat belt connected ...");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                isSeatBeltConnected     = false;
                Console.WriteLine("\nSeat belt disconnected ...");
            }
        }
        
        // 🔑 keys
        public void DragKeysToIgnition()
        {
            if (!isSeatBeltConnected)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nSeat belt not connected");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            areKeysInIgnition       = true;
            Console.WriteLine("\nKeys dragged to ignition switch ...");
        }
        
        // 🚗 Start Car
        public void StartCar()
        {
            if (!areKeysInIgnition || !isSeatBeltConnected)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nKeys not in ignition or seat belt not connected");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            isStarted               = true;
            Console.WriteLine("\nCar started ...");
            DisplayScreen();
        }

        // 🛑 Break
        public void Brake()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow; 
            if (speed == 0)
            {
                Console.WriteLine("The car has already stopped.");
                return;
            }

            if (speed < 0 || (speed - 10) == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                speed = 0;
                Console.WriteLine("\nCar has stopped.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nMPH decreasing from " + speed + " to " + (speed - 10));
            speed -= 10;
        }

        // ⚙️ Shift Gear
        public void ShiftGear(string newGear)
        { 
            Console.ForegroundColor = ConsoleColor.DarkRed; 
            string[] GearArr = {"D", "R", "N","P"};
            if (!GearArr.Contains(newGear))
            {
                Console.WriteLine("\nInvalid CCommand");
                return;
            }
            
            if (!isStarted)
            {
                Console.WriteLine("Gears cannot be changed unless the car is Started.");
                return;
            }
            
            else if (speed != 0)
            {
                Console.WriteLine("Gears cannot be changed unless the car is at 0 MPH");
                return;
            }

            
            if (newGear == "D" || newGear == "R")
            {
                Console.ForegroundColor = ConsoleColor.Green;  
                gasPedalEnabled         = true;
                Console.WriteLine("\nGas pedal enabled.");
            } 
            
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;  
                gasPedalEnabled         = false;
                Console.WriteLine("\nGas pedal disabled.");
            } 
            
            gear = newGear;
            DisplayScreen();
        }

        // 🫔 gear menu
        public void GearMenu()
        {
            Console.ResetColor(); 
            
            // Prompt user for Gear
            Console.WriteLine("\nShift your gear:");
            Console.WriteLine("'P' Parking");
            Console.WriteLine("'R' Reverse");
            Console.WriteLine("'N' Neutral");
            Console.WriteLine("'D' Drive");

            // Get gear selected
            Console.Write("");
            string GearSelected = Console.ReadLine();
            ShiftGear(GearSelected);
        }

        // 📈 Speedometer
        public void IncreaseSpeed(int increment)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (!isStarted)
            {
                Console.WriteLine("Must turn on the car");
                return;
            }
            
            else if (!gasPedalEnabled)
            {
                Console.WriteLine("\n- Gas pedal is disabled.");
                Console.WriteLine("- Gas pedal only works if car is in drive or reverse.");
                return;
            }
            
            speed            += increment;
            distanceTraveled += increment;
            gasTank          -= 1; 
            
            if (speed > 55)
            {
                Console.WriteLine("\nSpeeding!");
            }
            
            Console.ForegroundColor = ConsoleColor.Blue;
                
            Console.WriteLine("\nSpeed (MPH): " + speed);
            Console.WriteLine("Speed (KPH): " + speed * 1.60934);

            switch (speed / 10)
            {
                case 0: Console.WriteLine("0-9 MPH");   
                break;
                case 1: Console.WriteLine("10-19 MPH");     
                break;
                case 2: Console.WriteLine("20-29 MPH");         
                break;
                default: Console.WriteLine((speed - 9) + "-" + (speed) + " MPH"); 
                break;
            }

        }
        
        // ⛽️ Gas Tank
        public void Move()
        {
            if (gasTank < 20)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nPlease Consider Feeling the Tank!");
            }
            
            if (isStarted && gasPedalEnabled)
            {
                gasTank -= 1;
                DisplayScreen();
            }

        }
        

        // 📺 Display gas reserve
        public void DisplayProgressBar()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nGas Tank Level    : " + gasTank + "%");
        }
        
        // 💯 Gas Pump
        public void FillGasTank()
        {
            gasTank = 100;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n⛽️ Gas tank filled to 100%.");
            DisplayScreen();
        }

        // 📺 Screen display
        public void DisplayScreen()
        {
            DisplayProgressBar();
            Console.WriteLine("Gear Mode         : " + gear);
            Console.WriteLine("Distance Traveled : " + distanceTraveled + " Miles");
            if (isBlinkerOn)
            {
                Console.WriteLine("Blinker           : " + blinkerState);   
            }
        }

        // 🚦 Turn on Blinker
        public void TurnOnBlinker(string direction)
        { 
            if (!isStarted)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nCar has not started yet.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            
            if (direction == "L")
            {
                isBlinkerOn = true; 
                Console.WriteLine("\nBlinker left");
                blinkerState = "👈 left";
            }
            
            else if (direction == "R")
            {
                isBlinkerOn = true; 
                Console.WriteLine("\nBlinker right");
                blinkerState = "👉 right";
            }
            
            else if (direction == "O")
            {
                if (!isBlinkerOn)
                {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nBlinker already off.");
                return;
                }
                isBlinkerOn = false;
                Console.WriteLine("\nBlinker turned off");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nInvalid Command.");
                BlinkerMenu();
            }
        }

        // Bliker Menu
        public void BlinkerMenu()
        {
            Console.ResetColor(); 
            
            // Prompt user for Blinker
            Console.WriteLine("\nBlinker Options:");
            Console.WriteLine("'O' Turn Off");
            Console.WriteLine("'L' Turn Left");
            Console.WriteLine("'R' Turn Right");

            // Get gear selected
            Console.Write("");
            string Direction = Console.ReadLine();
            TurnOnBlinker(Direction);
        }
    }

    // Main fuction
    public static void Main(string[] args)
    {
        Car myCar = new Car();
        bool isEnd = false;

        while(!isEnd) 
        {
            Console.ResetColor(); 
            
            // Prompt user for command
            Console.WriteLine("\nChoose a command:");
            Console.WriteLine("1. Connect Seat Belt");
            Console.WriteLine("2. Drag Keys to Ignition");
            Console.WriteLine("3. Start Car");
            Console.WriteLine("4. Shift gear");
            Console.WriteLine("5. Press gas");
            Console.WriteLine("6. Fill Tank");
            Console.WriteLine("7. Turn Blinker");
            Console.WriteLine("8. Use Brake");
            Console.WriteLine("9. Stop Car");
            

            // Get user command
            Console.Write("");
            string userInput = Console.ReadLine();

            // Car action based on command
            switch (userInput)
            {
                case "1": myCar.ConnectSeatBelt();                break;
                case "2": myCar.DragKeysToIgnition();             break;
                case "3": myCar.StartCar();                       break;
                case "4": myCar.GearMenu();                       break;
                case "5": myCar.IncreaseSpeed(5);
                          myCar.Move();                           break;
                case "6": myCar.FillGasTank();                    break;
                case "7": myCar.BlinkerMenu();                    break;
                case "8": myCar.Brake();                          break;
                case "9": myCar.isStarted = false;                     
                          isEnd = true;                           break;
                default : Console.ForegroundColor = ConsoleColor.DarkRed;
                          Console.WriteLine("\nInvalid command"); break;
            }
            // Closing switch
        }
        // closing is end
    }
}