using System;
using System.Collections.Generic;
using System.IO;

namespace day3
{
    public class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public int Length { get; set; }
        public bool IsUpright { get; set; }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var commandsOne = input[0];
            var commandsTwo = input[1];

            var lineOne = CommandsToLines(commandsOne);
            var lineTwo = CommandsToLines(commandsTwo);
            var intersections = GetIntersections(lineOne, lineTwo);

        }

        private static List<Point> GetIntersections(List<Line> lineOne, List<Line> lineTwo)
        {
            var intersectionPoints = new List<Point>();
            foreach (var partOfLineOne in lineOne)
            {
                foreach (var partOfLineTwo in lineTwo)
                {
                    var intersectionPoint = GetIntersectionPoint(partOfLineOne, partOfLineTwo);
                    if (intersectionPoint != null)
                    {
                        intersectionPoints.Add(intersectionPoint);
                    }
                }
            }
            return intersectionPoints;
        }

        private static Point GetIntersectionPoint(Line lineOne, Line lineTwo)
        {
            if (lineOne.IsUpright ^ lineTwo.IsUpright) return null;
            if (lineOne.IsUpright)
            {
                var max1x = Math.Max(lineOne.Start.X, lineOne.End.X);
                var min1x = Math.Min(lineOne.Start.X, lineOne.End.X);
                var max2x = Math.Max(lineTwo.Start.X, lineTwo.End.X);
                var min2x = Math.Min(lineTwo.Start.X, lineTwo.End.X);
                var max1y = Math.Max(lineOne.Start.Y, lineOne.End.Y);
                var min1y = Math.Min(lineOne.Start.Y, lineOne.End.Y);
                var max2y = Math.Max(lineTwo.Start.Y, lineTwo.End.Y);
                var min2y = Math.Min(lineTwo.Start.Y, lineTwo.End.Y);


                if (lineTwo.Start.X <= lineOne.Start.X && lineOne.Start.X <= lineTwo.End.X &&
                    lineOne.Start.Y <= lineOne.Start.Y && lineOne.Ene.Y <= lineOne.Start.Y)
                {
                    return new Point(lineOne.Start.X, lineTwo.Start.Y);
                }
            }
            else
            {
                //line 2 is upright
                if(lineOne.Start.X < )
            }
            return null;
        }

        private static List<Line> CommandsToLines(string commandsTwo)
        {
            var currentX = 0;
            var currentY = 0;
            var lines = new List<Line>();

            foreach (var line in commandsTwo.Split(','))
            {
                var direction = line[0];
                var lineLen = int.Parse(line.Substring(1));
                var newLine = new Line
                {
                    Start = new Point(currentX, currentY),
                    End = new Point(currentX, currentY),
                    Length = lineLen
                };
                if (direction == 'L')
                {
                    currentX -= lineLen;
                    newLine.End.X = currentX;
                    newLine.IsUpright = false;
                }
                else if (direction == 'R')
                {
                    currentX += lineLen;
                    newLine.End.X = currentX;
                    newLine.IsUpright = false;
                }
                else if (direction == 'U')
                {
                    currentY += lineLen;
                    newLine.End.Y = currentY;
                    newLine.IsUpright = true;
                }
                else if (direction == 'D')
                {
                    currentY -= lineLen;
                    newLine.End.Y = currentY;
                    newLine.IsUpright = true;
                }
            }
            return lines;
        }


    }




}
