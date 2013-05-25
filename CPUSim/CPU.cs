using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSim
{
    class CPU
    {
        private Memory memory;
        //private List<string> program;
        private List<string> program;
        private Input input;
        private Dictionary<string, int> labels;
        private int index;
        public CPU(List<string> program, Memory memory, Input input, Dictionary<string, int> labels)
        {
            this.program = program;
            this.memory = memory;
            this.input = input;
            this.labels = labels;

        }

        private void RemoveLabels()
        {
            //remove labels so that they don't get interpreted as commands
            for (int i = program.Count - 1; i >= 0; i--)
            {
                if (program[i].StartsWith("@"))
                    program.RemoveAt(i);
            }

        }
        public void ExecuteLoadedProgram()
        {
            RemoveLabels();
            while (true)//foreach (string instruction in instructions)
            {
                //memory.SetValue("PC", memory.GetValue("PC") + 1);
                //string cleanedString = System.Text.RegularExpressions.Regex.Replace(instructions[memory.GetValue("PC")], @"\s+", " ").Trim();
                //string[] instructionAndArgument = cleanedString.Split(' ');
                string[] instrandops;

                /*try
                {
                    
                }*/

                try
                {
                    instrandops = program[memory.GetValue("PC")].Split(' ');
                }
                catch (ArgumentOutOfRangeException e)
                {
                    return;
                }
                try
                {
                        if (instrandops[2] == "IO" || instrandops[3] == "IO")
                        {
                            memory.SetValue(instrandops[1], input.GetInputToIO());
                            memory.SetValue("PC", memory.GetValue("PC") + 1);
                            continue;
                        }
                }
                catch (Exception e) {}

                int numberOfArguments = instrandops.Length - 1;
                if (!instrandops[0].StartsWith("@"))
                {
                    switch (instrandops[0])
                    {
                        case "END":
                            if (numberOfArguments > 0)
                                throw new ArgumentException();
                            else
                                return;
                        case "ADD":
                            memory.SetValue(instrandops[1], memory.GetValue(instrandops[2]) + memory.GetValue(instrandops[3]));
                            break;
                        case "SUB":
                            memory.SetValue(instrandops[1], memory.GetValue(instrandops[2]) - memory.GetValue(instrandops[3]));
                            break;
                        case "MUL":
                            memory.SetValue(instrandops[1], memory.GetValue(instrandops[2]) * memory.GetValue(instrandops[3]));
                            break;
                        case "DIV":
                            memory.SetValue(instrandops[1], memory.GetValue(instrandops[2]) / memory.GetValue(instrandops[3]));
                            break;
                        case "MOD":
                            memory.SetValue(instrandops[1], memory.GetValue(instrandops[2]) % memory.GetValue(instrandops[3]));
                            break;
                        case "AND":
                            memory.SetValue(instrandops[1], memory.GetValue(instrandops[2]) & memory.GetValue(instrandops[3]));
                            break;
                        case "ORO":
                            memory.SetValue(instrandops[1], memory.GetValue(instrandops[2]) | memory.GetValue(instrandops[3]));
                            break;
                        case "NOT":
                            memory.SetValue(instrandops[1], int.MaxValue - memory.GetValue(instrandops[2]));
                            break;
                        case "SLT":
                            if (memory.GetValue(instrandops[2]) < memory.GetValue(instrandops[3]))
                                memory.SetValue(instrandops[1], 1);
                            else
                                memory.SetValue(instrandops[1], 0);
                            break;
                        case "SGT":
                            if (memory.GetValue(instrandops[2]) > memory.GetValue(instrandops[3]))
                                memory.SetValue(instrandops[1], 1);
                            else
                                memory.SetValue(instrandops[1], 0);
                            break;
                        case "SEQ":
                            if (memory.GetValue(instrandops[2]) == memory.GetValue(instrandops[3]))
                                memory.SetValue(instrandops[1], 1);
                            else
                                memory.SetValue(instrandops[1], 0);
                            break;
                        case "CPY":
                            memory.SetValue(instrandops[1], memory.GetValue(instrandops[2]));
                            break;
                        case "JMP":
                            memory.SetValue("PC", labels[instrandops[1]]);
                            break;
                        case "JPZ": //Not implemented
                            if (memory.GetValue(instrandops[1]) == 0)
                                memory.SetValue("PC", labels[instrandops[2]]);
                            break;
                        case "JNZ": //Not implemented
                            if (memory.GetValue(instrandops[1]) != 0)
                                memory.SetValue("PC", labels[instrandops[2]]);
                            break;
                        case "LOD": //Not implemented
                            break;
                        case "STO": //Not implemented
                            break;
                        case "IMM":
                            memory.SetValue(instrandops[1], Convert.ToInt32(instrandops[2]));
                            break;
                        case "CAL": //Not implemented
                            break;
                        case "RET": //Not implemented
                            break;
                        case "PSH": //Not implemented
                            break;
                        case "POP": //Not implemented
                            break;
                        case "INC":
                            if (numberOfArguments > 1)
                                throw new ArgumentException();
                            else
                                memory.SetValue(instrandops[1], memory.GetValue(instrandops[1]) + 1);
                            break;
                        case "DEC":
                            if (numberOfArguments > 1)
                                throw new ArgumentException();
                            else
                                memory.SetValue(instrandops[1], memory.GetValue(instrandops[1]) - 1);
                            break;
                        case "NOP":
                            break;
                    }
                    memory.SetValue("PC", memory.GetValue("PC") + 1);
                }
                else
                    continue;

            }
        }
    }
}
