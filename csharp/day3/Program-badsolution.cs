using System;
using System.IO;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var lines1 = input[0];
            var lines2 = input[1];
            //var lines1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72";
            //var lines2 = "U62,R66,U55,R34,D71,R55,D58,R83";
            //var lines1 = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51";
            //var lines2 = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7";

            var startX = 15000;
            var startY = 15000;

            var board1 = new int[40000, 40000];
            var board2 = new int[40000, 40000];
            DrawLine(board1,startX, startY, lines1);
            DrawLine(board2, startX, startY, lines2);
            //PrintBoard(board1);
            //PrintBoard(board2);

            
            var resultingBoard = MergeBoards(board1, board2);
            resultingBoard[startX, startY] = 1;
            //PrintBoard(resultingBoard);
            var distanceFromStart = CalculateShortestDistance(resultingBoard, startX, startY);//1431 - Works but is a terribly slow and memory hungry solution
        }

        private static int CalculateShortestDistance(int[,] board, int startX, int startY)
        {
            var minDistance = board.GetLength(0) * 2;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if(board[i,j] ==2)
                    {
                        var distanceFromStart = Math.Abs(startX - i) + Math.Abs(startY-j);
                        if (distanceFromStart < minDistance) minDistance = distanceFromStart;
                    }                    
                }
            }
            return minDistance;
        }

        private static int[,] MergeBoards(int[,] board1, int[,] board2)
        {
            var resultingBoard = new int[board1.GetLength(0), board1.GetLength(1)];

            for (int i = 0; i < board1.GetLength(0); i++)
            {
                for (int j = 0; j < board1.GetLength(1); j++)
                {
                    resultingBoard[i, j] = board1[i, j] + board2[i, j];
                }
            }
            return resultingBoard;
        }

        private static void PrintBoard(int[,] board)
        {
            for(int i = 0; i< board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.Write("\n");
            }
        }

        private static void DrawLine(int[,] board, int startX, int startY, string lines1)
        {
            var currentPositionX = startX;
            var currentPositionY = startY;
            board[startX, startY] = 1;
            foreach (var line in lines1.Split(','))
            {
                var direction = line[0];
                var steps = int.Parse(line.Substring(1));

                for (int i = 1; i < steps; i++)
                {
                    if (direction == 'L')
                    {
                        currentPositionY--;
                        board[currentPositionX, currentPositionY] = 1;
                    }
                    else if (direction == 'R')
                    {
                        currentPositionY++;
                        board[currentPositionX, currentPositionY] = 1;                        
                    }
                    else if (direction == 'U')
                    {
                        currentPositionX--;
                        board[currentPositionX, currentPositionY] = 1;
                        
                    }
                    else if (direction == 'D')
                    {
                        currentPositionX++;
                        board[currentPositionX, currentPositionY] = 1;
                    }
                }
            }
        }
    }



}
