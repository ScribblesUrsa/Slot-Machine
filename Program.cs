﻿using System.ComponentModel;

namespace Slot_Machine
{
    internal class Program
    {
        const int X = 3;
        const int Y = 3;
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
            'A', '1',  '5', '7', '$', 'M', '8', '9', '!', '#', 'Q', '%', 'C', 'S', 'Y', 'V', 'W', 'R', 'L', 'F'
            };

            List<char> characterHolder = new List<char>();                                                              //To Store Character Items Temporarily and placed into the slots    

            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
            Console.WriteLine("Slot Machine-Very Bad Gambling Habit");
            Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
            Console.WriteLine("\n");

            char[,] slots = new char[X, Y];                                                                             //Defining the slot matrices of the game

            foreach (char slot in slots)
            {
                slotIndex = slotCharacter.Next(reelCharacters.Count);
                characterHolder.Add(reelCharacters[slotIndex]);
            }

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

        }
    }
}