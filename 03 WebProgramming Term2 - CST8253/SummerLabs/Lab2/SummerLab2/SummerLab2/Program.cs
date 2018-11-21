using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            while (playAgain)
            {
                bool loop = true;
                string number = "";
                int maxValue = 0;
                int minValue = 1000000;
                int number1 = 0;
                int totalOdd = 0;
                int sumOdd = 0;
                int totalEven = 0;
                int sumEven = 0;
                double averageOdd = 0.0;
                double averageEven = 0.0;
                int counterTimes = 0;                
                string answer = "";

                while (loop)
                {
                    Console.WriteLine("Please type a number: ");
                    number = Console.ReadLine();
                    if (number == "" && counterTimes == 0)
                    {
                        Console.WriteLine("You did not enter any integer!\n");
                        continue;
                    }
                    if (number == "")
                    {
                        loop = false;
                        break;
                    }
                    else
                    {
                        number1 = int.Parse(number);
                        if (number1 > maxValue)
                        {
                            maxValue = number1;
                            counterTimes++;
                        }
                        if (number1 < minValue)
                        {
                            minValue = number1;
                            counterTimes++;
                        }
                        if (number1 % 2 != 0)
                        {
                            totalOdd = totalOdd + 1;
                            sumOdd = sumOdd + number1;
                            counterTimes++;
                        }
                        if (number1 % 2 == 0)
                        {
                            totalEven = totalEven + 1;
                            sumEven = sumEven + number1;
                            counterTimes++;
                        }
                    }

                    if (totalOdd != 0)
                    {
                        averageOdd = sumOdd / totalOdd;
                    }
                    if (totalEven != 0)
                    {
                        averageEven = sumEven / totalEven;
                    }
                }

                Console.WriteLine($"The maximum number you typed was: {maxValue}");
                Console.WriteLine($"The minimum number you typed was: {minValue}");
                Console.WriteLine($"The total number of odds integers typed was: {totalOdd}");
                Console.WriteLine($"The sum of all odd integers typed was: {sumOdd}");
                Console.WriteLine($"The average of odd integers typed was: {averageOdd}");
                Console.WriteLine($"The total number of even integers typed was: {totalEven}");
                Console.WriteLine($"The sum of all even integers typed was: {sumEven}");
                Console.WriteLine($"The average of even integers typed was: {averageEven}");
                Console.WriteLine("\nPlay again (Y/N)?");
                answer = (Console.ReadLine()).ToUpper();
                if (answer == "N")
                {
                    playAgain = false;
                    break;
                }
            }
            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();
        }
    }
}
