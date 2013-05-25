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
        List<string> parsedprogram = new List<string>();
        private CPU cpu;
        Dictionary<string, int> labels;
        
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
            parsedprogram = parser.GetParsedProgram();
            labels = parser.GetParsedLabels();
            foreach (string line in parsedprogram)
                Console.WriteLine(line);
            Console.WriteLine("Program parsed");

            cpu = new CPU(parsedprogram, memory, input, labels);
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
