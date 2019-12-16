using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day7
{
    class Program
    {
        static void Main(string[] args)
        {
            Part2();
        }

        private static void Part2()
        {
            var pixels = File.ReadAllText("input.txt");
            var width = 25;
            var height = 6;
            var pixelsPerLayer = width * height;
            var numberOfLayers = pixels.Length / pixelsPerLayer;
            var result = GetTransparentLayer(width, height);
            for (int i = 0; i < numberOfLayers; i++)
            {
                var layerPixes = pixels.Substring(pixelsPerLayer * i, pixelsPerLayer);
                for (int j = 0; j < height; j++)
                {
                    var rowPixels = layerPixes.Substring(j * width, width);
                    for(int p = 0;  p< width; p++)
                    {
                        if(result[j,p] == 2)
                        {
                            result[j, p] = rowPixels[p] - '0';
                        }
                    }
                }
            }
            Print(result, width, height);
        }

        private static int[,] GetTransparentLayer(int width, int height)
        {
            var layer = new int[height, width];
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    layer[i, j] = 2;
                }
            }
            return layer;
        }

        private static void Print(int[,] result, int width, int height)
        {
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if(result[i, j] ==1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.White;
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.Write(result[i, j]);
                }
                Console.Write("\n");
            }
        }

        private static void Part1()
        {
            var pixels = File.ReadAllText("input.txt");
            var width = 25;
            var height = 6;
            var pixelsPerLayer = width * height;
            var numberOfLayers = pixels.Length / pixelsPerLayer;
            var layers = new List<List<List<string>>>();
            var fewestZeores = int.MaxValue;
            var layerWithFewsetZeroes = -1;
            var zeroList = new List<int>();
            var multiplesList = new List<int>();
            for (int i = 0; i < numberOfLayers; i++)
            {
                int zeroes = 0;
                int ones = 0;
                int twos = 0;
                var layer = new List<List<string>>();
                var layerPixes = pixels.Substring(pixelsPerLayer * i, pixelsPerLayer);
                for (int j = 0; j < height; j++)
                {
                    var rowPixels = layerPixes.Substring(j * width, width);
                    zeroes += rowPixels.Count(x => x == '0');
                    ones += rowPixels.Count(x => x == '1');
                    twos += rowPixels.Count(x => x == '2');
                }
                if (zeroes < fewestZeores)
                {
                    layerWithFewsetZeroes = i;
                    fewestZeores = zeroes;
                }
                var multiples = ones * twos;
                zeroList.Add(zeroes);
                multiplesList.Add(multiples);
            }

            var part1Result = multiplesList[layerWithFewsetZeroes];
        }
    }
}

