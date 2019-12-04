using System;
using System.IO;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Part2();
        }

        private static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var opcodes = Array.ConvertAll(input.Split(','), c => int.Parse(c));
            
            for (int noun = 0; noun < 100; noun++)
            {
                for(int verb =0; verb < 100; verb++)
                {
                    var copy = opcodes.Clone() as int[];
                    copy[1] = noun;
                    copy[2] = verb;
                    var result = runTheProgram(copy);
                    if(result[0] == 19690720)
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
            var opcodes = Array.ConvertAll(input.Split(','), c => int.Parse(c));
            opcodes[1] = 12;
            opcodes[2] = 2;
            opcodes = runTheProgram(opcodes);            
            var result = opcodes[0];
            Console.WriteLine("Hello World!");
        }

        private static int[] runTheProgram(int[] opcodes)
        {
            for (int i = 0; i < opcodes.Length;)
            {
                var opcode = opcodes[i];
                if (opcode == 1)
                {
                    var first = opcodes[i + 1];
                    var second = opcodes[i + 2];
                    var resultAddr = opcodes[i + 3];
                    opcodes[resultAddr] = opcodes[first] + opcodes[second];
                    i += 4;
                }
                else if (opcode == 2)
                {
                    var first = opcodes[i + 1];
                    var second = opcodes[i + 2];
                    var resultAddr = opcodes[i + 3];
                    opcodes[resultAddr] = opcodes[first] * opcodes[second];
                    i += 4;
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
    }
}
