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
        private string[] program;
        private Input input;

        public CPU(List<string> program, Memory memory, Input input)
        {
            this.program = program.ToArray();
            this.memory = memory;
            this.input = input;
        }
        public void ExecuteLoadedProgram()
        {
            while (true)//foreach (string instruction in instructions)
            {
                memory.SetValue("PC", memory.GetValue("PC") + 1);
                //string cleanedString = System.Text.RegularExpressions.Regex.Replace(instructions[memory.GetValue("PC")], @"\s+", " ").Trim();
                //string[] instructionAndArgument = cleanedString.Split(' ');
                string[] instructionAndArgument;

                try
                {
                    instructionAndArgument = program[memory.GetValue("PC") - 1].Split(' ');
                }

                catch (Exception e)
                {
                    return;
                }

                try
                {
                    if (instructionAndArgument[2] == "IO" || instructionAndArgument[3] == "IO")
                    {
                        memory.SetValue(instructionAndArgument[1], input.GetInputToIO());
                        continue;
                    }
                }
                catch (Exception e) {}

                int numberOfArguments = instructionAndArgument.Length - 1;
                if (!instructionAndArgument[0].StartsWith("@"))
                    switch (instructionAndArgument[0])
                    {
                        case "END":
                            if (numberOfArguments > 0)
                                throw new ArgumentException();
                            else
                                return;
                        case "ADD":
                            memory.SetValue(instructionAndArgument[1], memory.GetValue(instructionAndArgument[2]) + memory.GetValue(instructionAndArgument[3]));
                            break;
                        case "SUB":
                            memory.SetValue(instructionAndArgument[1], memory.GetValue(instructionAndArgument[2]) - memory.GetValue(instructionAndArgument[3]));
                            break;
                        case "MUL":
                            memory.SetValue(instructionAndArgument[1], memory.GetValue(instructionAndArgument[2]) * memory.GetValue(instructionAndArgument[3]));
                            break;
                        case "DIV":
                            memory.SetValue(instructionAndArgument[1], memory.GetValue(instructionAndArgument[2]) / memory.GetValue(instructionAndArgument[3]));
                            break;
                        case "MOD":
                            memory.SetValue(instructionAndArgument[1], memory.GetValue(instructionAndArgument[2]) % memory.GetValue(instructionAndArgument[3]));
                            break;
                        case "AND":
                            memory.SetValue(instructionAndArgument[1], memory.GetValue(instructionAndArgument[2]) & memory.GetValue(instructionAndArgument[3]));
                            break;
                        case "ORO":
                            memory.SetValue(instructionAndArgument[1], memory.GetValue(instructionAndArgument[2]) | memory.GetValue(instructionAndArgument[3]));
                            break;
                        case "NOT":
                            memory.SetValue(instructionAndArgument[1], int.MaxValue - memory.GetValue(instructionAndArgument[2]));
                            break;
                        case "SLT":
                            if (memory.GetValue(instructionAndArgument[2]) < memory.GetValue(instructionAndArgument[3]))
                                memory.SetValue(instructionAndArgument[1], 1);
                            else
                                memory.SetValue(instructionAndArgument[1], 0);
                            break;
                        case "SGT":
                            if (memory.GetValue(instructionAndArgument[2]) > memory.GetValue(instructionAndArgument[3]))
                                memory.SetValue(instructionAndArgument[1], 1);
                            else
                                memory.SetValue(instructionAndArgument[1], 0);
                            break;
                        case "SEQ":
                            if (memory.GetValue(instructionAndArgument[2]) == memory.GetValue(instructionAndArgument[3]))
                                memory.SetValue(instructionAndArgument[1], 1);
                            else
                                memory.SetValue(instructionAndArgument[1], 0);
                            break;
                        case "CPY":
                            memory.SetValue(instructionAndArgument[1], memory.GetValue(instructionAndArgument[2]));
                            break;
                        case "JMP": //Not implemented
                            break;
                        case "JPZ": //Not implemented
                            break;
                        case "JNZ": //Not implemented
                            break;
                        case "LOD": //Not implemented
                            break;
                        case "STO": //Not implemented
                            break;
                        case "IMM":
                            memory.SetValue(instructionAndArgument[1], Convert.ToInt32(instructionAndArgument[2]));
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
                                memory.SetValue(instructionAndArgument[1], memory.GetValue(instructionAndArgument[1]) + 1);
                            break;
                        case "DEC":
                            if (numberOfArguments > 1)
                                throw new ArgumentException();
                            else
                                memory.SetValue(instructionAndArgument[1], memory.GetValue(instructionAndArgument[1]) - 1);
                            break;
                        case "NOP":
                            break;
                    }

            }
        }
    }
}
