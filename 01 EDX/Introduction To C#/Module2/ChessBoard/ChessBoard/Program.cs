using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the pattern of a chess board that is 8 x 8. Use X and O to represent the squares:

            for (int C = 0; C < 8; C++)  // will create 8 collumns (eigth positions/characters in a row)
            {
                for (int R = 0; R < 8; R++) // will create 8 rows (lines)
                {
                    if ((R + C) % 2 == 0) // if sum of positions is even
                    {
                        Console.Write("X"); // print "X"
                    }
                    else if ((R + C) % 2 == 1) // if sum of positions are odd
                    {
                        Console.Write("O"); // print "O"
                    }
                // it allows to print one at a time, alternating between the two of them
                }
                Console.WriteLine(); //breaks the line after each loop is completed (eache row is finished)
            }
            
            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();
        }
    }
}
