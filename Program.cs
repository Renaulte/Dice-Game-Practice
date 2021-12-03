using System;

namespace Dice_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            #region variable declarations
            string userInput;
            int timesToRun;
            string userColor;
            string diceColor = null;
            int diceSides;
            int userColorNum = 1;
            bool loopLogicColor = false;
            bool isNumValid = false;
            bool isStrValid = false;
            bool isNumInRange = false;
            #endregion

            #region User Input Sides


            Console.WriteLine("Welcome! Let's set up your dice. How many sides do you want your dice to have?\nEnter a number between 2 to 20:");
            do
            {
                string diceSidesStr = Console.ReadLine();

                isNumValid = Int32.TryParse(diceSidesStr, out diceSides);
                if (isNumValid == true)
                {
                    if (diceSides > 1 && diceSides < 21)
                    {
                        Console.WriteLine($"Number of sides set to {diceSides}.");
                        isNumInRange = true;
                    }
                    else
                    {
                        Console.WriteLine("Input must be between 2 and 20.\n");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input, please try again.\n");
                }
            } while (isNumValid == false || isNumInRange == false);


            #endregion

            #region User Input Color
            //code to ask user to select a dice color
            Console.WriteLine("Now let's pick a dice color. Input a number to select your color:");

            do
            {


                Console.WriteLine("1. Red\n2. Green\n3. Blue\n4. Transparent");
                userColor = Console.ReadLine();

                if (Int32.TryParse(userColor, out userColorNum))
                {
                    switch (userColorNum)
                    {
                        case 1:
                            userColorNum = 1;
                            diceColor = "Red";
                            loopLogicColor = true;
                            Console.WriteLine($"Dice color set to {diceColor}.");
                            break;
                        case 2:
                            userColorNum = 2;
                            diceColor = "Green";
                            loopLogicColor = true;
                            Console.WriteLine($"Dice color set to {diceColor}.");
                            break;
                        case 3:
                            userColorNum = 3;
                            diceColor = "Blue";
                            loopLogicColor = true;
                            Console.WriteLine($"Dice color set to {diceColor}.");
                            break;
                        case 4:
                            userColorNum = 4;
                            diceColor = "Transparent";
                            loopLogicColor = true;
                            Console.WriteLine($"Dice color set to {diceColor}.");
                            break;
                        default:
                            Console.WriteLine("Invalid input, please try again.");
                            break;
                    }

                }
            }
            while (loopLogicColor == false);
            #endregion

            #region Main Logic

            Dice userDice = new(diceSides, diceColor);
            bool checkForOne = false;

            do 
            {
                Console.WriteLine($"Input a number to roll that many {userDice.Color} D{userDice.NumSides}. Get a max roll of {userDice.NumSides} to win!");
                userInput = Console.ReadLine();
                Int32.TryParse(userInput, out timesToRun);

                if (userInput == "Nonstop!")
                {
                    
                    int numTimesRun = 0;
                    while (checkForOne != true)
                    {
                        numTimesRun++;
                        checkForOne = DiceGameMethod(userDice.NumSides, timesToRun, userDice.Color);
                        if (checkForOne == true)
                        {
                            Console.WriteLine($"It took you {numTimesRun} times to get a max roll on the first try!");
                            break;
                        }


                    }
                }
                else
                {
                    checkForOne = DiceGameMethod(userDice.NumSides, timesToRun, userDice.Color);
                }
            } while (checkForOne == false);
            Console.ReadLine();
        }
        #endregion

        #region Dice Game Method
        public static bool DiceGameMethod(int diceSides, int timesToRun, string diceColor)
        {
            string userConfirm;
            bool userVar;
            int nextRandomNumber = 0;
            int timesRun = 0;
            int timesWon = 0;
            bool winCon = false;
            Random random = new();

            do
            {
                while (winCon == false)
                {
                    nextRandomNumber = random.Next(1, diceSides + 1);
                    Console.WriteLine($"Roll #{timesRun}: Result: {nextRandomNumber}");
                    timesRun++;
                    if (timesRun == 1 && nextRandomNumber == diceSides)
                    {
                        Console.WriteLine($"You got a max roll with the {diceColor} die on the first try!");
                        timesWon++;
                    }
                    else if (nextRandomNumber == diceSides)
                    {
                        Console.WriteLine($"Max roll with the {diceColor} die! This is roll #{timesRun}.");
                        timesWon++;
                    }
                    if(timesRun == timesToRun)
                    {
                        Console.WriteLine($"You won {timesWon} times in {timesToRun} rolls.");
                        winCon = true;
                    }

                }
                Console.WriteLine("Play again? Yes or No");
                userConfirm = Console.ReadLine();
                if (userConfirm == "yes")
                {
                    userVar = true;
                    nextRandomNumber = 0;
                    timesRun = 0;
                    return false;
                }
                else
                {
                    userVar = false;
                    return true;
                }
            } while (userVar == true);
        }
    }
    #endregion

}
