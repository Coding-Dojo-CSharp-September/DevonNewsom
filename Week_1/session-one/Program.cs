// imports Classes from System namespace
using System;
using System.Collections.Generic;

// defining a namespace 'lecture'
namespace lecture
{
    // Program class contains our program's entry point function "Main"
    class Program
    {
        // entry point function
        static void Main(string[] args)
        {
            // numbers => int, double
            // int num = 5;
            // double dub = 5.5;

            // // character => string, char
            // string name = "Devon";
            // char character = 'd';

            // bool isFunky = true;

            // collections => arrays, Lists, Dictionaries tuples?
            
            // initialize int array with literal expression
            int[] nums = {1,43,5,2,4,2};

            nums[0] = 1000;
            nums[5] = 10;

            // intialize empty int array, declaring size of 5 
            int[] moreNums = new int[5];

            // initialze empty int List
            List<int> numList = new List<int>();

            // initialize int list with literal expression
            List<int> numList2 = new List<int> {2,4,2,4,5,2};

            // List's can be added to! (unlike arrays)
            numList.Add(2);
            numList.Add(299);




            MyFunction(nums);
            
        }
        static void MyFunction(int[] someNums)
        {
            for(int i=0; i<someNums.Length; i++)
            {
                Console.WriteLine($"Index{i}: {someNums[i]}");
            }
        }
    }
}
