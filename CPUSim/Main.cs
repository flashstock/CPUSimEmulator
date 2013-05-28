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
        private List<string> program = new List<string>();
        private List<string> parsedprogram = new List<string>();
        private CPU cpu;
        private Dictionary<string, int> labels;
        private Dictionary<string, string> aliases;
        
        public Main(string[] args)
        {
            this.filename = args[0];
            memory = new Memory();
            input = new Input();
            parser = new Parser();
        }

        public void Run()
        {
            Console.WriteLine("Reading program from {0}.\n", filename);
            ReadFile(filename);

            Console.WriteLine("Parsing program:\n");
            parser.SetProgram(program);
            parsedprogram = parser.GetParsedProgram();
            labels = parser.GetParsedLabels();
            aliases = parser.GetParsedAliases();
            foreach (string line in parsedprogram)
                Console.WriteLine(line);
            Console.WriteLine("\nProgram parsed\n");

            cpu = new CPU(parsedprogram, memory, input, labels, aliases);
            Console.WriteLine("Executing program\n");
            cpu.ExecuteLoadedProgram();
            //cpu.ExecuteLoadedProgram();
            Console.WriteLine("\nProgram executed!\n");

            Console.WriteLine("Dumping registers:\n");
            memory.DumpRegisters();
            memory.DumpRAM();

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadLine();
        }

        private void ReadFile(string filename)
        {
            foreach (string line in System.IO.File.ReadAllLines(filename))
            {
                if (line != "")
                    program.Add(line);
            }
        }
    }
}
