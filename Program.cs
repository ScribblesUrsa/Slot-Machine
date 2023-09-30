

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
        const int COUNTER0 = 0;
        const int COUTNER1 = 1;
        const int COUNTER2 = 2;

        static void Main(string[] args)
        {
            int slotIndex = 0;
            int slotRow = 0;
            int slotColumn = 0;

      
            int diagonalWinningCheck = 0;

            int lineHorizontalWinCount = 0;
            int lineVerticalWinCount = 0;
            int lineDiagonalWinCount = 0;

            int centreLineCheck = 0;
            int moneyWagered = 0;
            int moneyWon = 0;
            int totalTakeHomeMoney = 0;
            int numberOfSpins = 0;

            bool singleCounts = lineDiagonalWinCount == COUTNER1 || lineHorizontalWinCount == COUTNER1;
            bool doubleCounts = lineDiagonalWinCount == COUNTER2 || lineHorizontalWinCount == COUNTER2 || lineVerticalWinCount == COUNTER2;

           
            bool doubleWinCheck = doubleCounts == true || lineVerticalWinCount == COUTNER1 && singleCounts == true;
            bool singleWinCheck = singleCounts == true || lineVerticalWinCount == COUTNER1 && doubleWinCheck == false;
            bool quadrupleWinCheck = lineHorizontalWinCount == COUNTER2 && lineVerticalWinCount == COUNTER2 && doubleWinCheck == false;
            bool noWin = lineDiagonalWinCount == COUNTER0 && lineHorizontalWinCount == COUNTER0 && lineVerticalWinCount == COUNTER0;

            char playChoice = ' ';

            Random randomPickGenerator = new Random();

            List<string> reelCharacters = new List<string>()                                                                                                //List of Slot Machine Character per Column/Reel
            {
            "A", "1",  "5", "7", "$","M", "8", "9", "!", "#", "Q", "&", "C", "S", "Y", "V", "W", "R", "L", "F"
            };

            List<string> characterHolder = new List<string>();                                                                                              //To Store Character Items Temporarily and placed into the slots

            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
            Console.WriteLine("Slot Machine-Very Bad Gambling Habit");
            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
            Console.WriteLine("\n");

            string[,] slots = new string[ROW_COUNT, COLUMN_COUNT];                                                                                          //Defining the slot matrices of the game

            Console.WriteLine($"One line of the same characters of any direction wins you ${SINGLE_LINE_HORIZONTAL_VERTICAL_DIAGONAL_PRIZE}");
            Console.WriteLine();
            Console.WriteLine($"Two lines of the same characters of any direction wins you ${DOUBLE_LINE_HORIZONAL_VERTICAL_DIAGONAL_PRIZE}");
            Console.WriteLine();
            Console.WriteLine($"Four lines of the same characters of any direction wins you ${QUADRUPLE_DIRECTION_PRIZE}");
            Console.WriteLine();
            Console.WriteLine($"Jackpot! Is when 3 lines match! wins you ${TRIPLE_LINE_PRIZE}!!!");
            Console.WriteLine();

            Console.WriteLine($"Try your luck! Would you like to spin (${PRICE_PER_SPIN} per spin)? Y for yes and any other key to exit:");
            playChoice = Console.ReadKey().KeyChar;
            Console.WriteLine("\n");

            while (playChoice.Equals('y'))
            {
             
                lineHorizontalWinCount =              
                lineVerticalWinCount =
                diagonalWinningCheck =
                lineDiagonalWinCount =
                centreLineCheck = 0;
                bool centreLineWin = false;

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
                }

                slotColumn = 0;                                                                                                                                 //Sets the value of slotRow and slotColumn to default

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

                slotRow = 0;                                                                                                                                    //Sets the value of slotRow and slotColumn to default

                for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
                {
                    if (slots[((ROW_COUNT - 1) / 2), 0] == slots[((ROW_COUNT - 1) / 2), slotColumn])
                    {
                        centreLineCheck++;
                    }

                    if (ROW_COUNT == centreLineCheck)
                    {
                        centreLineWin = true;
                    }

                }

                for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
                {
                    slotRow = slotColumn;

                    if (slots[0, 0] == slots[slotRow, slotColumn])
                    {
                        diagonalWinningCheck++;
                    }

                    if (diagonalWinningCheck == ROW_COUNT)
                    {
                        lineDiagonalWinCount++;
                    }

                }
                slotRow = 0;
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

                numberOfSpins++;
                moneyWagered = numberOfSpins * PRICE_PER_SPIN;


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

                if (doubleWinCheck && !quadrupleWinCheck)
                {
                    Console.WriteLine($"You win ${DOUBLE_LINE_HORIZONAL_VERTICAL_DIAGONAL_PRIZE}!!!!");
                    moneyWon += DOUBLE_LINE_HORIZONAL_VERTICAL_DIAGONAL_PRIZE;

                }

                if (singleWinCheck)
                {
                    Console.WriteLine($"You win ${SINGLE_LINE_HORIZONTAL_VERTICAL_DIAGONAL_PRIZE}!!!!");
                    moneyWon += SINGLE_LINE_HORIZONTAL_VERTICAL_DIAGONAL_PRIZE;
                }


                if (noWin)
                {
                    Console.WriteLine("Better Luck Next Time!");
                }

                totalTakeHomeMoney = moneyWagered - moneyWon;
                Console.WriteLine($"You have spent: ${moneyWagered}");
                Console.WriteLine($"Total money won: ${moneyWon}");

                if (totalTakeHomeMoney < 0)
                {
                    Console.WriteLine($"You owe: ${totalTakeHomeMoney}");
                }

                if (totalTakeHomeMoney > 0)
                {
                    Console.WriteLine($"You take home: ${totalTakeHomeMoney}");
                }

                Console.WriteLine("Try again? Y to continue and any other key to exit:");
                playChoice = Console.ReadKey().KeyChar;

                Console.WriteLine("\n"); 

            }
        }
    }
}