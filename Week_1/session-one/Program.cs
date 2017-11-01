// imports Classes from System namespace
using System;
using System.Collections.Generic;

namespace lecture
{
    class Program
    {
        // entry point function
        static void Main(string[] args)
        {
            int[] nums = {1,43,5,2,4,2};
            int[] moreNums = new int[5];

            List<int> numList = new List<int>();
            List<int> numList2 = new List<int> {2,4,2,4,5,2};
            
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
