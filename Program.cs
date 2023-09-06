﻿using System.ComponentModel;
using System.Data;

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
        static void Main(string[] args)
        {
            int slotIndex = 0;
            int slotRow = 0;
            int slotColumn = 0;
            int horizontalWinningCheck = 0;
            int verticalWinningCheck = 0;
            int diagonalWinningCheck = 0;
            int lineHorizontalWinCount = 0;
            int lineVerticalWinCount = 0;
            int lineDiagonalWinCount = 0;
            int moneyWagered = 0;
            int numberOfSpins = 0;

            char playChoice = ' ';

            Random randomPickGenerator = new Random();

            List<string> reelCharacters = new List<string>()                                                                //List of Slot Machine Character per Column/Reel
            {
            "*A*", "*1*",  "*5*", "*7*", "*$*", "*M*", "*8*", "*9*", "*!*", "*#*", "*Q*", "*&*", "*C*", "*S*", "*Y*", "*V*", "*W*", "*R*", "*L*", "*F*"
            };

            List<string> characterHolder = new List<string>();                                                              //To Store Character Items Temporarily and placed into the slots

            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
            Console.WriteLine("Slot Machine-Very Bad Gambling Habit");
            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
            Console.WriteLine("\n");

            string[,] slots = new string[ROW_COUNT, COLUMN_COUNT];                                                          //Defining the slot matrices of the game

            Console.WriteLine($"One line of the same characters of any direction wins you ${SINGLE_LINE_HORIZONTAL_VERTICAL_DIAGONAL_PRIZE}");
            Console.WriteLine();
            Console.WriteLine($"Two lines of the same characters of any direction wins you ${DOUBLE_LINE_HORIZONAL_VERTICAL_DIAGONAL_PRIZE}");
            Console.WriteLine();
            Console.WriteLine($"Four lines of the same characters of any direction wins you ${QUADRUPLE_DIRECTION_PRIZE}");
            Console.WriteLine();
            Console.WriteLine($"Jackpot! Is when all is the same! wins you ${TRIPLE_LINE_PRIZE}!!!");
            Console.WriteLine();

            Console.WriteLine($"Try your luck! Would you like to spin (${PRICE_PER_SPIN} per spin)? Y for yes and any other key to exit:");
            playChoice = Console.ReadKey().KeyChar;
            Console.WriteLine("\n");

            while (playChoice.Equals('y'))
            {
                horizontalWinningCheck = lineHorizontalWinCount = verticalWinningCheck = lineVerticalWinCount = diagonalWinningCheck = lineDiagonalWinCount = 0;

                for (slotRow = 0; slotRow < ROW_COUNT; slotRow++)
                {

                    for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
                    {
                        slotIndex = randomPickGenerator.Next(reelCharacters.Count);
                        slots[slotRow, slotColumn] = reelCharacters[slotIndex];
                    }

                    for (int j = 0; j < COLUMN_COUNT -2; j++)                                                                      //Determining the winnings
                    {
                        if (slots[slotRow, (COLUMN_COUNT - 1)].Contains(slots[slotRow, j]))
                        {
                            horizontalWinningCheck++;
                        }
                    }

                    if (horizontalWinningCheck == ROW_COUNT)
                    {
                        lineHorizontalWinCount++;
                    }

                }

                for (slotRow = 0; slotRow < COLUMN_COUNT; slotRow++)
                {
                    for (slotColumn = 0; slotColumn < COLUMN_COUNT -2 ; slotColumn++)                                               //Determining the winnings
                    {
                        if (slots[slotRow, (ROW_COUNT - 1)].Contains(slots[slotRow, slotColumn]))
                        {
                            verticalWinningCheck++;
                        }
                    }

                    if (verticalWinningCheck == ROW_COUNT)
                    {
                        lineVerticalWinCount++;
                    }
                }

                for (slotColumn = 0; slotRow < COLUMN_COUNT; slotRow++)
                {
                    slotRow = slotColumn;

                    if (slots[0, 0].Contains(slots[slotRow, slotColumn]))
                    {
                        diagonalWinningCheck++;
                    }

                    if (slots[(ROW_COUNT - 1), (COLUMN_COUNT - 1)].Contains(slots[((ROW_COUNT - 1) - slotRow), ((COLUMN_COUNT - 1) - slotColumn)]))
                    {
                        diagonalWinningCheck++;
                    }

                    if (diagonalWinningCheck == (ROW_COUNT - 1))
                    {
                        lineDiagonalWinCount++;
                    }

                }

                for (slotRow = 0; slotRow < ROW_COUNT; slotRow++)
                {
                    for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
                    {
                        Console.Write("  " + slots[slotRow, slotColumn] + "  ");

                    }
                    Console.WriteLine("\n");
                }
                numberOfSpins++;
                moneyWagered = numberOfSpins * PRICE_PER_SPIN;

                if (lineDiagonalWinCount == 1 || lineHorizontalWinCount == 1 || lineVerticalWinCount == 1)
                {
                    Console.WriteLine($"You win ${SINGLE_LINE_HORIZONTAL_VERTICAL_DIAGONAL_PRIZE}!!!!");
                }

                if (lineDiagonalWinCount == 2 || lineHorizontalWinCount == 2 || lineVerticalWinCount == 2)
                {
                    Console.WriteLine($"You win ${DOUBLE_LINE_HORIZONAL_VERTICAL_DIAGONAL_PRIZE}!!!!");
                }

                if (lineDiagonalWinCount == 2 && lineHorizontalWinCount == 2 && lineVerticalWinCount == 2)
                {
                    Console.WriteLine($"You win {QUADRUPLE_DIRECTION_PRIZE}!!!");
                }

                if (lineDiagonalWinCount == ROW_COUNT || lineHorizontalWinCount == ROW_COUNT || lineVerticalWinCount == ROW_COUNT)
                {
                    Console.WriteLine($"Jackpot!!!!!");
                }

                Console.WriteLine($"You have spent: ${moneyWagered}");
                Console.WriteLine("Try again? Y to continue and any other key to exit:");
                playChoice = Console.ReadKey().KeyChar;

                Console.WriteLine("\n");

            }
        }
    }
}