using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSim
{
    class Main
    {
        private string filename;
        private Input input;
        private Memory memory;
        private Parser parser;
        List<string> program = new List<string>();
        private CPU cpu;
        
        public Main(string filename)
        {
            this.filename = filename;
            memory = new Memory();
            input = new Input();
            parser = new Parser();
        }

        public void Run()
        {
            Console.WriteLine("Reading program from {0}.", filename);
            ReadFile(filename);

            Console.WriteLine("Parsing program");
            parser.SetProgram(program);
            parser.GetParsedProgram();
            Console.WriteLine("Program parsed");

            cpu = new CPU(program, memory, input);
            Console.WriteLine("Executing program");
            cpu.ExecuteLoadedProgram();
            Console.WriteLine("Program executed!");

            Console.WriteLine("\nDumping registers.\n");
            memory.DumpRegisters();
            
            Console.ReadLine();
        }

        private void ReadFile(string filename)
        {
            foreach (string line in System.IO.File.ReadAllLines(filename))
            {
                if (line != "")
                    program.Add(line);
                /*
                if (line != "")
                {
                    int index = line.IndexOf("#");
                    if (index > 0)
                        instructions.Add(line.Substring(0, index));
                    else
                        instructions.Add(line);
                }*/
            }

        }


    }
}
