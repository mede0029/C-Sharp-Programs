using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Solution
{
    class Lab3
    {
        static int[] intArray = {17,  166,  288,  324,  531,  792,  946,  157,  276,  441, 533, 355, 228, 879, 100, 421, 23, 490, 259, 227,
                                 216, 317, 161, 4, 352, 463, 420, 513, 194, 299, 25, 32, 11, 943, 748, 336, 973, 483, 897, 396,
                                 10, 42, 334, 744, 945, 97, 47, 835, 269, 480, 651, 725, 953, 677, 112, 265, 28, 358, 119, 784,
                                 220, 62, 216, 364, 256, 117, 867, 968, 749, 586, 371, 221, 437, 374, 575, 669, 354, 678, 314, 450,
                                 808, 182, 138, 360, 585, 970, 787, 3, 889, 418, 191, 36, 193, 629, 295, 840, 339, 181, 230, 150 };

        static void Main(string[] args)
        {
            Console.WriteLine("This is the current array:\n");
            PrintArray(intArray);            
            Console.WriteLine("\nPlease type an integer: ");
            int input = int.Parse(Console.ReadLine());
            
            //Calling Linear Search:
            int numOfComparison = 0;
            int linear = LinearSearch(intArray, input, ref numOfComparison);
            if (linear == -1)
                {
                Console.WriteLine($"\nThe linear search made {numOfComparison} comparisons to find out that {input} is not in this unsorted array.");
                }
            else 
            {
                Console.WriteLine($"\nThe linear search made {numOfComparison} comparisons to find out that {input} is at index {linear} in this unsorted array.");
            }

            //Calling Bubble Sort:
            int bubble = BubbleSort(intArray);
            Console.WriteLine($"\n{bubble} swaps were made to the origial array. This is the sorted array: \n");
            PrintArray(intArray);    

            //Calling Binary Search:
            Console.WriteLine("\nPlease type another integer: ");
            int input1 = int.Parse(Console.ReadLine());
            int numOfComparison1 = 0;
            int binary = BinarySearch(intArray, input1, ref numOfComparison1);
            if (binary == -1)
            {
                Console.WriteLine($"\nThe binary search made {numOfComparison1} comparisons to find out that {input1} is not in this sorted array.");
            }
            else 
            {
                Console.WriteLine($"\nThe binary search made {numOfComparison1} comparisons to find out that {input1} is at index {binary} in the sorted array.");
            }              
            
            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();
        }

        //This method returns the index of a given niddle (an int) in the haystack (an int array)
        //by using linear search. It also returns the value of the number of comparison used to 
        //find the given niddle through the reference parameter numOfComparison.
        static int LinearSearch(int[] haystack, int niddle, ref int numOfComparison)
        {
            //Here you search the niddle in the haystack.
            int niddleIndex = 0;         
            int N = haystack.Length;
            for (int i = 0; i < N; i++)
			{
                numOfComparison++;
                if (haystack[i] == niddle)
                {
                    niddleIndex = i; 
                    break;
                }
                else
                {
                    niddleIndex = -1;
                }                 
			}
            return niddleIndex;
        }
        
        static int BubbleSort(int[] arr)
        {
            int numOfSwaps = 0;
            int temp = 0;
            //Here you implement the bubble sort to sort the integer array arr.
            int N = arr.Length;
            for (int i = 0; i < N; i++)
			{
                for (int sort = 0; sort < N-1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        numOfSwaps++;
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
	        }
            return numOfSwaps;
        }

        //This method returns the index of a given niddle (an int) in the haystack (an int array)
        //by using binary search. It also returns the value of the number of comparison used to 
        //find the given niddle through the reference parameter numOfComparison.
        static int BinarySearch(int[] haystack, int niddle, ref int numOfComparison)
        {
            int niddleIndex = -1;
            //Here you implement the binary search to find the niddle in the haystack.
            int min = 0;
            int N = haystack.Length;
            int max = N -1;
            do
            {
                int mid = (min + max) / 2;
                if (niddle > haystack[mid])
                {
                    min = mid + 1;
                    numOfComparison++;
                }
                else
                {
                    max = mid - 1;
                    numOfComparison++;
                }

                if (haystack[mid] == niddle)
                {
                    niddleIndex = mid;
                    numOfComparison++;
                    break;
                }
                if (min > max)
                { 
                    numOfComparison++;
                    break;
                }
            } while (min <= max);
            return niddleIndex; 
        }

        //call this method to print an integer array to the console.
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    Console.Write("{0}, ", arr[i]);
                }
                else
                {
                    Console.Write("{0} ", arr[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
