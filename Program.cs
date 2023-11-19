

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
        static void PrintHeader()
        {

            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
            Console.WriteLine("Slot Machine-Very Bad Gambling Habit");
            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
            Console.WriteLine("\n");
            Console.WriteLine($"One line of the same characters of any direction wins you ${SINGLE_LINE_HORIZONTAL_VERTICAL_DIAGONAL_PRIZE}");
            Console.WriteLine();
            Console.WriteLine($"Two lines of the same characters of any direction wins you ${DOUBLE_LINE_HORIZONAL_VERTICAL_DIAGONAL_PRIZE}");
            Console.WriteLine();
            Console.WriteLine($"Four lines of the same characters of any direction wins you ${QUADRUPLE_DIRECTION_PRIZE}");
            Console.WriteLine();
            Console.WriteLine($"Jackpot! Is when 3 lines match! wins you ${TRIPLE_LINE_PRIZE}!!!");
            Console.WriteLine();
            Console.WriteLine($"Try your luck!(${PRICE_PER_SPIN} per spin)?");
        }

        static int SpinTimesOption()
        {
            int timesOfSpin = 0;
            if (timesOfSpin == 0)
            {
                Console.WriteLine("How many spins would you like to purchase?");
                while (!int.TryParse(Console.ReadLine(), out timesOfSpin))
                {
                    Console.WriteLine("Please type it a numerical input.");
                }
            }

            return timesOfSpin;

        }


        static void Main(string[] args)
        {

            PrintHeader();

            Random randomPickGenerator = new Random();

            List<string> reelCharacters = new List<string>()                                                                                                //List of Slot Machine Character per Column/Reel
            {
            "A", "1",  "5", "7", "$","M", "8", "9", "!", "#", "Q", "&", "C", "S", "Y", "V", "W", "R", "L", "F"
            };

            List<string> characterHolder = new List<string>();                                                                                              //To Store Character Items Temporarily and placed into the slots

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


                timesOfSpin = SpinTimesOption();

                for (slotRow = 0; slotRow < ROW_COUNT; slotRow++)
                {

                    for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
                    {
                        slotIndex = randomPickGenerator.Next(reelCharacters.Count);
                        slots[slotRow, slotColumn] = reelCharacters[slotIndex];
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

                int lineVerticalWinCount = 0;
                for (slotRow = 0; slotRow < ROW_COUNT; slotRow++)
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
                for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
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

                for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
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