using System.ComponentModel;

namespace Slot_Machine
{
    internal class Program
    {
        const int ROW_COUNT = 3;
        const int COLUMN_COUNT = 3;
        const double PLAY_PER_LINE = 1.5;                                                                                //Either Horizonal, Vertical or DIagonal, does not matter
        const double PLAY_ALL_HORIZONTAL = 4;
        const double PLAY_ALL_VERTICAL = 4;
        const double PLAY_ALL_DIAGONAL = 2.5;
        const double PLAY_ALL = 9;
        const double SINGLE_LINE_HORIZONTAL_VERTICAL_DIAGONAL_PRIZE = 5;
        const double DOUBLE_LINE_HORIZONAL_VERTICAL_DIAGONAL_PRIZE = 15;
        const double TRIPLE_LINE_PRIZE = 30;
        static void Main(string[] args)
        {
            Random slotCharacter = new Random();

            int slotIndex = 0;
            int slotRow = 0;
            int slotColumn = 0;

            List<char> reelCharacters = new List<char>()                                                                //List of Slot Machine Character per Column/Reel
            {
            'A', '1',  '5', '7', '$', 'M', '8', '9', '!', '#', 'Q', '%', 'C', 'S', 'Y', 'V', 'W', 'R', 'L', 'F'
            };

            List<char> characterHolder = new List<char>();                                                              //To Store Character Items Temporarily and placed into the slots
            List<char> lineOne =  new List<char>();
            List<char> lineTwo = new List<char>();
            List<char> lineThree = new List<char>();

            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
            Console.WriteLine("Slot Machine-Very Bad Gambling Habit");
            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
            Console.WriteLine("\n");

            char[,] slots = new char[ROW_COUNT, COLUMN_COUNT];                                                                             //Defining the slot matrices of the game

            foreach (char slot in slots)
            {
                slotIndex = slotCharacter.Next(reelCharacters.Count);
                characterHolder.Add(reelCharacters[slotIndex]);
            }

            for(int i = 0; i < characterHolder.Count; i++)
            {
                while (i <= COLUMN_COUNT)
                {
                    slotRow = 0;
                    slotColumn++;
                }

                
            }

            lineOne.Add(characterHolder[0]);                                                                            //Added array for comparison
            lineOne.Add(characterHolder[1]);
            lineOne.Add(characterHolder[2]);

            lineTwo.Add(characterHolder[3]);
            lineTwo.Add(characterHolder[4]);
            lineTwo.Add(characterHolder[5]);

            lineThree.Add(characterHolder[6]);
            lineThree.Add(characterHolder[7]);
            lineThree.Add(characterHolder[8]);

            slots[0, 0] = characterHolder[0];
            slots[0, 1] = characterHolder[1];
            slots[0, 2] = characterHolder[2];
            slots[1, 0] = characterHolder[3];
            slots[1, 1] = characterHolder[4];
            slots[1, 2] = characterHolder[5];
            slots[2, 0] = characterHolder[6];
            slots[2, 1] = characterHolder[7];
            slots[2, 2] = characterHolder[8];

            Console.WriteLine(slots[0, 0] + " - " + slots[0, 1] + " - " + slots[0, 2]); 
            Console.WriteLine();
            Console.WriteLine(slots[1, 0] + " - " + slots[1, 1] + " - " + slots[1, 2]); 
            Console.WriteLine();
            Console.WriteLine(slots[2, 0] + " - " + slots[2, 1] + " - " + slots[2, 2]);

            //Horizonal Equality check
            if (characterHolder[0].Equals(characterHolder[1]) && characterHolder[1].Equals(characterHolder[2]))
            {
                Console.WriteLine("HLine 1 Aligns");                                                                        //Not Permanent
            }

            if (characterHolder[3].Equals(characterHolder[4]) && characterHolder[4].Equals(characterHolder[5]))
            {
                Console.WriteLine("HLine 2 Aligns");                                                                        //Not Permanent
            }

            if (characterHolder[6].Equals(characterHolder[7]) && characterHolder[7].Equals(characterHolder[8]))
            {
                Console.WriteLine("HLine 3 Aligns");                                                                        //Not Permanent
            }

            //Vertical Equality check
            if (characterHolder[0].Equals(characterHolder[3]) && characterHolder[3].Equals(characterHolder[6]))
            {
                Console.WriteLine("VLine 1 Aligns");                                                                        //Not Permanent
            }

            if (characterHolder[1].Equals(characterHolder[4]) && characterHolder[4].Equals(characterHolder[7]))
            {
                Console.WriteLine("VLine 2 Aligns");                                                                        //Not Permanent
            }

            if (characterHolder[2].Equals(characterHolder[5]) && characterHolder[5].Equals(characterHolder[8]))
            {
                Console.WriteLine("VLine 3 Aligns");                                                                        //Not Permanent
            }

            //Diagonal Equality Check
            if (characterHolder[0].Equals(characterHolder[4]) && characterHolder[4].Equals(characterHolder[8]))
            {
                Console.WriteLine("DLine 1 Aligns");                                                                        //Not Permanent
            }

            if (characterHolder[2].Equals(characterHolder[4]) && characterHolder[4].Equals(characterHolder[6]))
            {
                Console.WriteLine("DLine 3 Aligns");                                                                        //Not Permanent
            }
            
            //Checking for multiple line equality
            if (lineOne.Equals(lineTwo))
            {
                Console.WriteLine("Two Lines Match");
            }

            if (lineOne.Equals(lineThree))
            {
                Console.WriteLine("Two Lines Match");
            }

            if (lineTwo.Equals(lineThree))
            {
                Console.WriteLine("Two Lines Match");
            }

        }
    }
}