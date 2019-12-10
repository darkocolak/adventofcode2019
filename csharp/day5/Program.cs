using System;
using System.Collections.Generic;
using System.IO;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
        }

        private static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var opcodes = Array.ConvertAll(input.Split(','), c => int.Parse(c));

            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    var copy = opcodes.Clone() as int[];
                    copy[1] = noun;
                    copy[2] = verb;
                    var result = runTheProgram(copy);
                    if (result[0] == 19690720)
                    {
                        Console.WriteLine(100 * noun + verb);
                        return;
                    }
                }
            }

        }

        private static void Part1()
        {
            var input = File.ReadAllText("input.txt");
            //input = "1002, 4, 3, 4, 33";
            var opcodes = Array.ConvertAll(input.Split(','), c => int.Parse(c));
            //opcodes[1] = 12;
            //opcodes[2] = 2;
            opcodes = runTheProgram(opcodes);
            //var result = opcodes[0];
            Console.WriteLine("Hello World!");
        }

        private static int[] runTheProgram(int[] opcodes)
        {
            for (int i = 0; i < opcodes.Length;)
            {
                (var opcode, var operand1, var operand2, var operand3) = Parse(opcodes, i);
                if (opcode == 1)
                {
                    opcodes[operand3] = operand1 + operand2;
                    i += 4;
                }
                else if (opcode == 2)
                {
                    opcodes[operand3] = operand1 * operand2;
                    i += 4;
                }
                else if (opcode == 3)
                {
                    opcodes[operand1] = 1;
                    //opcodes[value] = 0;//INPUT???
                    i += 2;
                }
                else if (opcode == 4)
                {
                    Console.WriteLine("OUTPUT:" + opcodes[operand1]);
                    //opcodes[value] = 0;//OUTPUT???
                    i += 2;
                }
                else if (opcode == 99)
                {
                    break;
                }
                else
                {
                    i++;
                }
            }
            return opcodes;
        }

        private static (int, int, int, int) Parse(int[] opcodes, int pos)
        {
            var input = opcodes[pos].ToString();
            if (input == "99") return (99, 0, 0, 0);
            var instruction = GetIntArray(int.Parse(input));
            
            if (input.Length == 5)
            {
                var opcode = instruction[3] * 10 + instruction[4];
                var operand1 = instruction[2] == 0 ? opcodes[opcodes[pos + 1]] : opcodes[pos + 1];
                var operand2 = instruction[1] == 0 ? opcodes[opcodes[pos + 2]] : opcodes[pos + 2];
                var operand3 = instruction[0] == 0 ? opcodes[opcodes[pos + 3]] : opcodes[pos + 3];
                return (opcode, operand1, operand2, operand3);
            }
            else if (input.Length == 4)
            {
                var opcode = instruction[2] * 10 + instruction[3];
                var operand1 = instruction[1] == 0 ? opcodes[opcodes[pos + 1]] : opcodes[pos + 1];
                var operand2 = instruction[0] == 0 ? opcodes[opcodes[pos + 2]] : opcodes[pos + 2];
                var operand3 = opcodes[pos + 3];
                return (opcode, operand1, operand2, operand3);
            }
            else if (input.Length == 3)
            {

                var opcode = instruction[1] * 10 + instruction[2];
                var operand1 = instruction[0] == 0 ? opcodes[opcodes[pos + 1]] : opcodes[pos + 1];
                if (opcode ==3 || opcode == 4)
                {
                    return (opcode, operand1, 0, 0);
                }
                return (opcode, operand1, opcodes[opcodes[pos + 2]], opcodes[pos + 3]);
            }
            else if (input.Length == 2)
            {
                var opcode = instruction[1];
                if (opcode == 3 || opcode == 4)
                {
                    return (opcode, opcodes[pos + 1], 0, 0);
                }
                return (opcode, opcodes[opcodes[pos + 1]], opcodes[opcodes[pos + 2]], opcodes[pos + 3]);
            }
            else if (input.Length == 1)
            {
                if(instruction[0] == 3 || instruction[0] == 4)
                {
                    return (instruction[0], opcodes[pos + 1], 0,0);
                }
                return (instruction[0], opcodes[opcodes[pos + 1]], opcodes[opcodes[pos + 2]], opcodes[pos + 3]);
            }
            else return (0, 0, 0, 0);
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
