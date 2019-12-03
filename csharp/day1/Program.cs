using System;
using System.IO;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input.txt");            
            var partOneResult = Part1(lines);
            Console.WriteLine(partOneResult);
            var partTwoResult = Part2(lines);
            Console.WriteLine(partTwoResult);
        }
        //8539195 too high ‭5123500‬ - not
        private static int Part1(string[] input)
        {
            var totalFuel = 0;
            foreach (var line in input)
            {
                var mass = int.Parse(line);
                totalFuel += mass / 3 - 2;
            }
            return totalFuel;
        }
        
        private static int Part2(string[] input)
        {
            var totalFuel = 0;
            foreach (var line in input)
            {
                var mass = int.Parse(line);
                var moduleFuelReq = mass / 3 - 2;
                totalFuel += moduleFuelReq;
                totalFuel += CalculateFuelWeight(moduleFuelReq);
            }
            return totalFuel;
        }

        private static int CalculateFuelWeight(int fuelWeight)
        {
            var totalWeight = 0;
            var remaining = fuelWeight;
            while(remaining > 0)
            {
                remaining = remaining / 3 - 2;
                if (remaining > 0)
                {
                    totalWeight += remaining;
                }
            }
            return totalWeight;
        }
    }
}
