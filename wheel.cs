using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Roulette
{
    class wheel
    {
        int[] blackArray = new int[18] { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 29, 28, 31, 33, 35 };
        int[] redArray = new int[18] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        Random ranNum = new Random();
        double landSpot;

        public wheel() // constructor
        {
            landSpot = ranNum.Next(0, 36);
        }

        public double GetLandSpot() // get landspot value
        {
            return landSpot;
        }

        public string GetColor() // gets color of each number on weheel
        {
            foreach(int val in blackArray)
            {
                if (landSpot == val)
                {
                    return "black";
                }
            }
            foreach (int val in redArray)
            {
                if (landSpot == val)
                {
                    return "red";
                }
            }
            return "green";
        }

        public int GetCalc(int isStraightBet, int guess, int moneyBet)
        {
            bool isEven = true;
            int betCalc;

            if (landSpot != 0 && landSpot % 2 == 0)
            {
                isEven = true;
            }
            else if(landSpot % 2 != 0)
            {
                isEven = false;
            }
            

            if (isStraightBet == 1 && guess == landSpot) //straight bet win
            {
                betCalc = moneyBet + (moneyBet * 35);
                WriteLine("\nWOW!, you won $" + betCalc);
                return betCalc;
            }
            else if (isStraightBet == 1 && guess != landSpot) //straight bet loss
            {
                WriteLine("\nSorry, you did not win.");
                return 0;
            }
                


            else if(isStraightBet == 2) // calc all outside bet wins
            {
                if (guess == 2 && isEven == true && landSpot != 0) //even outside bet win
                {
                    betCalc = moneyBet * 2;
                    WriteLine("\nyou won $ " + betCalc);
                    return betCalc;
                }
                else if (guess == 1 && isEven == false && landSpot != 0) //odd outside bet win
                {
                    betCalc = moneyBet * 2;
                    WriteLine("\nyou won $ " + betCalc);
                    return betCalc;
                }
                else if (guess == 3 && landSpot >= 1 && landSpot <= 18) //1st half win
                {
                    betCalc = moneyBet * 2;
                    WriteLine("\nyou won $ " + betCalc);
                    return betCalc;
                }
                else if (guess == 4 && landSpot >= 19) //2nd half win
                {
                    betCalc = moneyBet * 2;
                    WriteLine("\nyou won $ " + betCalc);
                    return betCalc;
                }
                else if (guess == 7 && landSpot >= 1 && landSpot <= 12) //1st 3rd win
                {
                    betCalc = moneyBet + (moneyBet * 2);
                    WriteLine("\nyou won $ " + betCalc);
                    return betCalc;
                }
                else if (guess == 8 && landSpot >= 13 && landSpot <= 24) //2nd 3rd win
                {
                    betCalc = moneyBet + (moneyBet * 2);
                    WriteLine("\nyou won $ " + betCalc);
                    return betCalc;
                }
                else if (guess == 9 && landSpot >= 25) //3rd 3rd win
                {
                    betCalc = moneyBet + (moneyBet * 2);
                    WriteLine("\nyou won $ " + betCalc);
                    return betCalc;
                }

                else if (guess == 5) //red win
                {
                    foreach (int val in redArray)
                    {
                        if (val == landSpot)
                        {
                            betCalc = moneyBet * 2;
                            WriteLine("\nyou won $ " + betCalc);
                            return betCalc;
                        }  
                    }
                    WriteLine("\nSorry, you did not win.");
                    return 0;
                }

                else if (guess == 6) //black win
                {
                    foreach (int val in blackArray)
                    {
                        if (landSpot == val)
                        {
                            betCalc = moneyBet * 2;
                            WriteLine("\nyou won $ " + betCalc);
                            return betCalc;
                        } 
                    }
                    
                }
                WriteLine("\nSorry, you did not win.");
            }  
            return 0;
        }

}
}
