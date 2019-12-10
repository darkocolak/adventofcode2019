using System;
using System.Collections.Generic;
using System.Linq;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputStart = 356261;
            var inputEnd = 846303;
            var numberOfMatches = FilterMatches(inputStart, inputEnd);
        }

        private static int FilterMatches(int inputStart, int inputEnd)
        {
            var numberOfMatches = 0;
            for(int i = inputStart; i<= inputEnd; i++)
            {
                    if(NumbersDontDecrease(i) && HasTwoSameNumbers(i))
                {
                    numberOfMatches++;
                }
            }
            return numberOfMatches;
        }

        private static bool HasTwoSameNumbers(int input)
        {
            var intArray = GetIntArray(input);
            var intList = intArray.ToList();
            bool foundAtLeastOne = false;
            for (int i = 0; i < intArray.Length; i++)
            {
                try { 
                if (intArray[i] == intArray[i + 1])
                {
                    var count = intList.Where(x => x == intArray[i]).Select(x => x).Count();
                    if (count % 2 == 0 && count < 3)
                    {
                        foundAtLeastOne = true;
                    } else
                    {
                        //return false;
                    }
                };
                }
                catch (Exception ex)
                {

                }
            }
            return foundAtLeastOne;

                //var x = input.ToString();
                //for (int i = 0; i < x.Length - 1; i++)
                //{
                //    if (x[i] == x[i + 1]) return true;
                //}
                //return false;
        }
        private static bool NumbersDontDecrease(int input)
        {
            var intArray = GetIntArray(input);
            for (int i = 0; i < intArray.Length - 1; i++)
            {
                if (intArray[i] > intArray[i + 1]) return false;
            }
            return true;
        }

        private static int[] GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num /= 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }
    }
}
