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

            Random slotCharacter = new Random();

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

            for (int i = 0; i < ROW_COUNT; i++)
            {
                slotRow = i;

                for (int j = 0; j < COLUMN_COUNT; j++)
                {
                    slotIndex = slotCharacter.Next(reelCharacters.Count);
                    slotColumn = j;
                    slots[slotRow, slotColumn] = reelCharacters[slotIndex];
                }

                for (int j = 0; j < COLUMN_COUNT; j++)                                                                      //Determining the winnings
                {
                    if (slots[i, (COLUMN_COUNT - 1)].Contains(slots[i, j]))
                    {
                        horizontalWinningCheck++;
                    }
                }

                if (horizontalWinningCheck == ROW_COUNT)
                {
                    lineHorizontalWinCount++;
                }

            }

            for (int i = 0; i < COLUMN_COUNT; i++)
            {
                slotColumn = i;

                for (int j = 0; j < COLUMN_COUNT; j++)                                                                      //Determining the winnings
                {
                    if (slots[i, (ROW_COUNT - 1)].Contains(slots[i, j]))
                    {
                        verticalWinningCheck++;
                    }
                }
                if (verticalWinningCheck == ROW_COUNT)
                {
                    lineVerticalWinCount++;
                }
            }

            for (int i = 0; i < COLUMN_COUNT; i++)
            {
                if (slots[0, 0].Contains(slots[i, i]))
                {
                    diagonalWinningCheck++;
                }

                if (slots[(ROW_COUNT - 1), (COLUMN_COUNT - 1)].Contains(slots[((ROW_COUNT - 1) - i), ((COLUMN_COUNT - 1) - i)]))
                {
                    diagonalWinningCheck++;
                }

                if (lineDiagonalWinCount == (ROW_COUNT - 1))
                {
                    lineDiagonalWinCount++;
                }

            }


            Console.WriteLine(slots[0, 0] + " - " + slots[0, 1] + " - " + slots[0, 2]);
            Console.WriteLine();
            Console.WriteLine(slots[1, 0] + " - " + slots[1, 1] + " - " + slots[1, 2]);
            Console.WriteLine();
            Console.WriteLine(slots[2, 0] + " - " + slots[2, 1] + " - " + slots[2, 2]);

        }
    }
}