using System;

public static class UIMethods
{
    public static void PrintHeader()
    {

        const int SINGLE_LINE_HORIZONTAL_VERTICAL_DIAGONAL_PRIZE = 5;
        const int DOUBLE_LINE_HORIZONAL_VERTICAL_DIAGONAL_PRIZE = 15;
        const int QUADRUPLE_DIRECTION_PRIZE = 25;
        const int TRIPLE_LINE_PRIZE = 100;
        const int PRICE_PER_SPIN = 2;


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

    public static int SpinTimesOption()
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
}
public class UserInterface
{
	public UserInterface()
	{
	}
}
