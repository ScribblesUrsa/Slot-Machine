﻿

namespace Slot_Machine
{



    
    internal class Program
    {
        const int ROW_COUNT = 3;
        const int COLUMN_COUNT = 3;
        const int SINGLE_LINE_HORIZONTAL_VERTICAL_DIAGONAL_PRIZE = 5;
        const int DOUBLE_LINE_HORIZONAL_VERTICAL_DIAGONAL_PRIZE = 15;
        const int QUADRUPLE_DIRECTION_PRIZE = 25;
        const int TRIPLE_LINE_PRIZE = 100;
        const int PRICE_PER_SPIN = 2;
        const int CONSTANT0 = 0;
        const int CONSTANT1 = 1;
        const int CONSTANT2 = 2;

        /// <summary>
        /// Displays Main Screen and Corresponding Winning Prices
        /// </summary>


        static string RandomCharacter(List<string> symbols)
        {
            Random randomPickGenerator = new Random();
            int slotIndex = randomPickGenerator.Next(symbols.Count);
            return symbols[slotIndex];
        }
            


        //generate a 2d array with random symbols
        static void string[,] GenRandomSlotGrid(List<string> symbols)
        {
            string[,] slots = new string[ROW_COUNT, COLUMN_COUNT];
            for (int slotRow = 0; slotRow < ROW_COUNT; slotRow++)
            {
                for (int slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
                {
               
                     slots[slotRow, slotColumn] = RandomCharacter(symbols) ;                                  //Should take out the indexes maybe?
                }
            }
            
            for (int slotRow = 0; slotRow < ROW_COUNT; slotRow++)
            {
                for (int slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
                {
                    Console.Write("  " + slots[slotRow, slotColumn] + "  ");
                }
                Console.WriteLine("\n");
            }
          
        }

        static void Main(string[] args)
        {

            UIMethods.PrintHeader();


            string[,] slots = new string[ROW_COUNT, COLUMN_COUNT];                                                                                          //Defining the slot matrices of the game

            char playChoice = 'y';

            int timesOfSpin = 0;

            while (playChoice.Equals('y'))
            {
                int slotIndex = 0;
                int slotRow = 0;
                int slotColumn = 0;
                bool centreLineWin = false;

                Console.WriteLine("\n");
                Console.WriteLine();


                timesOfSpin = UIMethods.SpinTimesOption();

                slots = GenRandomSlotGrid(reelCharacters);

                for (slotRow = 0; slotRow < ROW_COUNT; slotRow++)                                       //Logic
                {

                    for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
                    {
                        slotIndex = randomPickGenerator.Next(reelCharacters.Count);
                        slots[slotRow, slotColumn] = reelCharacters[slotIndex];
                    }
                }

                for (slotRow = 0; slotRow < ROW_COUNT; slotRow++)                                       //Logic
                {
                    for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
                    {
                        Console.Write("  " + slots[slotRow, slotColumn] + "  ");
                    }
                    Console.WriteLine("\n");
                }

                int lineVerticalWinCount = 0;
                for (slotRow = 0; slotRow < ROW_COUNT; slotRow++)                                       //Logic
                {
                    int sameCharacterCount = 0;
                    for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)                                                                               //Determining the winnings
                    {
                        if (slots[slotRow, 0] == slots[slotRow, slotColumn])
                        {
                            sameCharacterCount++;
                        }
                    }

                    if (sameCharacterCount == COLUMN_COUNT)
                    {
                        lineVerticalWinCount++;
                    }
                }                                                                                                                               //Sets the value of slotRow and slotColumn to default
                int lineHorizontalWinCount = 0;
                for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)                               //Logic
                {
                    int sameCharacterCount = 0;
                    for (slotRow = 0; slotRow < ROW_COUNT; slotRow++)                                                                                           //Determining the winnings
                    {
                        if (slots[0, slotColumn] == slots[slotRow, slotColumn])
                        {
                            sameCharacterCount++;
                        }
                    }

                    if (sameCharacterCount == COLUMN_COUNT)
                    {
                        lineHorizontalWinCount++;
                    }
                }

                for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)                                   //Logic
                {
                    int centreLineCheck = 0;
                    if (slots[((ROW_COUNT - 1) / 2), 0] == slots[((ROW_COUNT - 1) / 2), slotColumn])
                    {
                        centreLineCheck++;
                    }

                    if (ROW_COUNT == centreLineCheck)
                    {
                        centreLineWin = true;
                    }

                }

                int lineDiagonalWinCount = 0;
                int diagonalWinningCheck = 0;
                for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
                {
                    slotRow = slotColumn;
                    int sameCharacterCount = 0;
                    if (slots[0, 0] == slots[slotRow, slotColumn])
                    {
                        sameCharacterCount++;
                    }

                    if (diagonalWinningCheck == ROW_COUNT)
                    {
                        lineDiagonalWinCount++;
                    }

                }
                diagonalWinningCheck = 0;

                for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
                {
                    slotRow = slotColumn;

                    if (slots[ROW_COUNT - 1, 0] == slots[slotRow, COLUMN_COUNT - 1 - slotColumn])
                    {
                        diagonalWinningCheck++;
                    }

                    if (diagonalWinningCheck == ROW_COUNT)
                    {
                        lineDiagonalWinCount++;
                    }

                }

                int numberOfSpins = 0;
                numberOfSpins++;
                int moneyWagered = 0;
                moneyWagered = numberOfSpins * PRICE_PER_SPIN;

                bool doubleLineWin = lineDiagonalWinCount == CONSTANT2 || lineHorizontalWinCount == CONSTANT2 || lineVerticalWinCount == CONSTANT2;
                bool singleLineWin = lineDiagonalWinCount == CONSTANT1 || lineHorizontalWinCount == CONSTANT1 || lineVerticalWinCount == CONSTANT1 && !doubleLineWin;

                bool quadrupleWinCheck = lineHorizontalWinCount == CONSTANT2 && lineVerticalWinCount == CONSTANT2 && !doubleLineWin;
                bool noWin = lineDiagonalWinCount == CONSTANT0 && lineHorizontalWinCount == CONSTANT0 && lineVerticalWinCount == CONSTANT0;

                int moneyWon = 0;

                if (lineHorizontalWinCount == ROW_COUNT && !quadrupleWinCheck)
                {
                    Console.WriteLine($"Jackpot!!!!! You won {TRIPLE_LINE_PRIZE}");
                    moneyWon += TRIPLE_LINE_PRIZE;
                }

                if (centreLineWin)
                {
                    Console.WriteLine("You randomly hit it at the middle!!!");
                }

                if (quadrupleWinCheck)
                {
                    Console.WriteLine($"You win {QUADRUPLE_DIRECTION_PRIZE}!!!");
                    moneyWon += QUADRUPLE_DIRECTION_PRIZE;
                }

                if (doubleLineWin && !quadrupleWinCheck)
                {
                    Console.WriteLine($"You win ${DOUBLE_LINE_HORIZONAL_VERTICAL_DIAGONAL_PRIZE}!!!!");
                    moneyWon += DOUBLE_LINE_HORIZONAL_VERTICAL_DIAGONAL_PRIZE;

                }

                if (singleLineWin)
                {
                    Console.WriteLine($"You win ${SINGLE_LINE_HORIZONTAL_VERTICAL_DIAGONAL_PRIZE}!!!!");
                    moneyWon += SINGLE_LINE_HORIZONTAL_VERTICAL_DIAGONAL_PRIZE;
                }


                if (noWin)
                {
                    Console.WriteLine("Better Luck Next Time!");
                }

                Console.WriteLine($"Total money won: ${moneyWon}");

                timesOfSpin--;

                if (timesOfSpin > 0)
                {
                    Console.WriteLine("Press Any Key to Spin!");
                    Console.ReadKey();
                }

                if (timesOfSpin == 0)
                {
                    Console.WriteLine(" Y to continue if you like to play, otherwise, press any other key to exit: ");
                    playChoice = Console.ReadKey().KeyChar;
                }

            }


            if (!playChoice.Equals('y'))
            {
                Console.WriteLine("Goodbye.");
            }
        }

    }
}