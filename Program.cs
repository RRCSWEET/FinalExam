using System;
using System.Threading;
using static System.Console;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            int attempt = 1, bet, money, guess = 0, isStraightBet, outisideBetNum, moneyWon;
            string input, retry = "y";

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("***********************************************************************************");
            WriteLine("*********************Welcome to Group 9's Roulette game!***************************");
            WriteLine("***********************************************************************************");
            WriteLine("**************************European Roulette board**********************************");
            WriteLine("***********************************************************************************");
            WriteLine(" ");

            
            

            do //user inputs amount of money they have, not their bet amount
            {
                Write("Please enter how much money do you have in total: $");
                input = ReadLine();
                money = int.Parse(input);
                if(money <= 0)
                {
                    WriteLine("That's an invalid amount.");
                }
            } while (money <= 0);

            do // loop to repeat program if user want to play again and had money to do so
            {
                WriteLine("\nYour money: $" + money + "        Attempt: " + attempt); //updates user on money they have left and amount of times they've played
                WriteLine("-------------------------------------------------------");
                bet = GetBet("How much do you want to bet? $", money); // gets bet amount
                money = money - bet;

                WriteLine("\nWhat would you like to bet on?");
                isStraightBet = GetBetNum("Enter '1' for a straight bet(single number only), Enter '2' for outside bets."); // checks to see if you want to straight bet or outside 
                if (isStraightBet == 1)
                {

                    do //straight bet
                    {
                        WriteLine("\nPlease enter the single number you want to bet on (0-36): ");
                        input = ReadLine();
                        guess = int.Parse(input);
                        if (guess < 0 || guess > 36)
                        {
                            WriteLine("Your selection is invalid.");
                        }

                    } while (guess < 0 || guess > 36);
                    WriteLine("you have bet $" + bet + " on " + guess + ".");
                }
                else //outside bets
                {
                    outisideBetNum = GetOutsideBet("Please enter your selection using the numbers below: ", bet);
                    guess = outisideBetNum;

                }
                WriteLine("Press enter to begin the game.");
                ReadKey();
                WriteLine("\nThe wheel is spinning.");
                for(int i = 0; i < 5; i++) //added pauses to simulate ball spinning on wheel
                {
                    Write(".");
                    Thread.Sleep(500);
                }
                Thread.Sleep(500);

                wheel wheel1 = new wheel(); // creates object containing landspot, bet calc, etc
                WriteLine("\nthe ball landed on " + wheel1.GetLandSpot() + " " + wheel1.GetColor());
                

                moneyWon = wheel1.GetCalc(isStraightBet, guess, bet);
                money += moneyWon;
                WriteLine("\nYou now have a total  of $" + money);
                WriteLine("-------------------------------------------------------");


                if (money == 0)
                {
                    WriteLine("\nYou have no more money left, the game is over.");
                    break;
                }
                WriteLine("Would you like to play again?('y' for yes, any other key for no)");
                retry = ReadLine();
                retry.ToLower();
                if(retry == "y")
                {
                    attempt++;
                    WriteLine(" ");
                    WriteLine(" ");
                    WriteLine(" ");
                    WriteLine(" ");
                }
                else if (retry != "y")
                {
                    WriteLine("\nYou have chosen to leave, the game is over.");
                    break;
                }
            } while (retry == "y");
        }


        static int GetOutsideBet(string val, int val2) //gets answer and prints out your selection
        {
            string input;
            int guess;
            string[] outsideBetArray = new string[9];
            outsideBetArray[0] = "Odd";
            outsideBetArray[1] = "Even";
            outsideBetArray[2] = "1 to 18";
            outsideBetArray[3] = "19 to 36";
            outsideBetArray[4] = "Red";
            outsideBetArray[5] = "Black";
            outsideBetArray[6] = "1st 12";
            outsideBetArray[7] = "2nd 12";
            outsideBetArray[8] = "3rd 12";

            WriteLine("\n" + val);
            WriteLine("1. Odd    2. Even    3. 1 to 18(1st half/low)    4. 19 to 36(2nd half/high)");
            WriteLine("5. Red     6. Black  7. 1st 12     8. 2nd 12");
            WriteLine("9. 3rd 12");
            do
            {
                input = ReadLine();
                guess = int.Parse(input);
                if (guess < 1 || guess > 9)
                {
                    WriteLine("Your selection is invalid.");
                }
            } while (guess < 1 || guess > 9);
            WriteLine("\nyou have bet $" + val2 + " on " + outsideBetArray[guess - 1] + ".");
            return guess;
        }

        static int GetBetNum(string val)
        {
            int num;
            string input;
            do
            {
                WriteLine(val);
                input = ReadLine();
                num = int.Parse(input);
                if(num != 1 && num != 2)
                {
                    WriteLine("your selection is invalid.");
                }
            }while (num != 1 && num != 2);
            return num;
        }
        static int GetBet(string val1, int val2)
        {
            int num;
            string input;
            do
            {
                Write(val1);
                input = ReadLine();
                num = int.Parse(input);
                if (num > val2 || num <= 0)
                {
                    WriteLine("Your bet is invalid.");
                }
            } while (num > val2 || num <= 0);
            return num;
        }
    }
}
