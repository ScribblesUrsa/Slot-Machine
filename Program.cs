using System.ComponentModel;

namespace Slot_Machine
{
    internal class Program
    {
        const int ROW_COUNT = 3;
        const int COLUMN_COUNT = 3;
        const double PLAY_PER_LINE = 1.5;                                                                                   //Either Horizonal, Vertical or DIagonal, does not matter
        const double PLAY_ALL_HORIZONTAL = 4;
        const double PLAY_ALL_VERTICAL = 4;
        const double PLAY_ALL_DIAGONAL = 2.5;
        const double PLAY_ALL = 9;
        const double SINGLE_LINE_HORIZONTAL_VERTICAL_DIAGONAL_PRIZE = 5;
        const double DOUBLE_LINE_HORIZONAL_VERTICAL_DIAGONAL_PRIZE = 15;
        const double TRIPLE_LINE_PRIZE = 30;
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

            for (slotRow = 0; slotRow < ROW_COUNT; slotRow++)
            {

                for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)
                {
                    slotIndex = randomPickGenerator.Next(reelCharacters.Count);
                    slots[slotRow, slotColumn] = reelCharacters[slotIndex];
                }

                for (int j = 0; j < COLUMN_COUNT; j++)                                                                      //Determining the winnings
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
                for (slotColumn = 0; slotColumn < COLUMN_COUNT; slotColumn++)                                                                      //Determining the winnings
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

                if (lineDiagonalWinCount == (ROW_COUNT - 1))
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

        }
    }
}