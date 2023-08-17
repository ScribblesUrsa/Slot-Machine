namespace Slot_Machine
{
    internal class Program
    {
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

            List<char> reelCharacters = new List<char>()                                                                //List of Slot Machine Character per Column/Reel
            {
            'A', '1', '7', '$', '*', '8', '9', '!', '#', '^', '%', '+', 'C', 'S', 'Y', 'V', 'W', 'R', 'L', 'F'
            };

            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
            Console.WriteLine("Slot Machine-Very Bad Gambling Habit");
            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");   
            
            char[,] slots = new char[3, 3];                                                                             //Defining the slot matrices of the game

            foreach (char slot in slots)
            {
                slotIndex = slotCharacter.Next(reelCharacters.Count);
            }
        }
    }
}