using System;

namespace Dice_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            #region variable declarations
            string userInput;
            string userColor;
            string diceColor;
            int userNum;
            int userColorNum = 1;
            bool loopLogicSides = false;
            bool loopLogicColor = false;
            #endregion

            #region User Input Sides
            //first line of code to ask user to input number of sides on the dice
            while (loopLogicSides == false)
            {
                Console.WriteLine("Welcome! Let's set up your dice. How many sides do you want your dice to have?\nEnter a number between 2 to 20:");
                string userNumStr = Console.ReadLine();

                if (Int32.TryParse(userNumStr, out userNum))
                {
                    Console.WriteLine($"Number of sides set to {userNum}.");
                    loopLogicSides = true;
                    
                }
                else
                {
                    Console.WriteLine($"Could not read data. Try again.");
                }
            }

            #endregion

            #region User Input Color
            //code to ask user to select a dice color
            while (loopLogicColor == false)
            {

                Console.WriteLine("Now let's pick a dice color. Input a number to select your color:");
                Console.WriteLine("1. Blue\n2. Red\n3. Clear");
                userColor = Console.ReadLine();

                if (Int32.TryParse(userColor, out userColorNum))
                {
                    switch (userColorNum)
                    {
                        case 1:
                            userColorNum = 1;
                            diceColor = "Blue";
                            loopLogicColor = true;
                            Console.WriteLine($"Dice color set to {diceColor}.");
                            break;
                        case 2:
                            userColorNum = 2;
                            diceColor = "Red";
                            loopLogicColor = true;
                            Console.WriteLine($"Dice color set to {diceColor}.");
                            break;
                        case 3:
                            userColorNum = 3;
                            diceColor = "Clear";
                            loopLogicColor = true;
                            Console.WriteLine($"Dice color set to {diceColor}.");
                            break;
                        default:
                            Console.WriteLine("Invalid input, please try again.");
                            break;
                    }

                }
            }

            #endregion

            Dice dice = new Dice(userNum, "red");


            Console.WriteLine("Input a number to roll that many D20s. Roll a nat 20 to win!");
            userInput = Console.ReadLine();

            //if(userInput == "Nonstop!")
            //{
            //    int checkForOne = 0;
            //    int numTimesRun = 0;
            //    while (checkForOne != 1)
            //    {
            //        numTimesRun++;
            //        checkForOne = DiceGameMethod();
            //        if (checkForOne == 1)
            //        {
            //            Console.WriteLine($"It took you {numTimesRun} times to get a nat 20 on the first try!");
            //            break;
            //        }
                    
                    
            //    }
            //}
            //else
            //{
            //    DiceGameMethod();
            //}
            Console.ReadLine();
        }

        public static int DiceGameMethod()
        {
            string userConfirm;
            bool userVar;
            int nextRandomNumber = 0;
            int timesRun = 0;
            Random random = new Random();

            do
            {
                while (nextRandomNumber != 20)
                {
                    nextRandomNumber = random.Next(1, 21);
                    Console.WriteLine(nextRandomNumber);
                    timesRun++;
                    if (timesRun == 1 && nextRandomNumber == 20)
                    {
                        Console.WriteLine("You got a nat 20! It only took one try!");
                        return 1;
                    }
                    else if (nextRandomNumber == 20)
                    {
                        Console.WriteLine($"You got a nat 20! It only took {timesRun} rolls.");
                        return 0;
                    }

                }
                Console.WriteLine("Play again? Yes or No");
                userConfirm = Console.ReadLine();
                if (userConfirm == "yes")
                {
                    userVar = true;
                    nextRandomNumber = 0;
                    timesRun = 0;
                    return 0;
                }
                else
                {
                    userVar = false;
                }
                return 0;

            } while (userVar == true);
        }
    }
        
    
}
