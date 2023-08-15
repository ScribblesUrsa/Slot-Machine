namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random slotCharacter = new Random();

            int slotIndex = 0;

            List<char> reelCharacters = new List<char>()                                                            //List of Slot Machine Character per Column/Reel
            {
            'A', '1', '7', '$', '*', '8', '9', '!', '#', '^', '%', '+', 'C', 'S', 'Y', 'V', 'W', 'R', 'L', 'F'
            };

            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
            Console.WriteLine("Slot Machine-Very Bad Gambling Habit");
            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");   
            
            slotIndex = slotCharacter.Next(reelCharacters.Count);

            char[,] slots = new char[3, 3];                                                                         //Defining the slot matrices of the game
        }
    }
}