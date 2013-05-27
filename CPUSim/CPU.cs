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
        private List<string> program;
        private Input input;
        private Dictionary<string, int> labels;
        private Dictionary<string, string> aliases;
        private int clockcount;

        public CPU(List<string> program, Memory memory, Input input, Dictionary<string, int> labels, Dictionary<string, string> aliases)
        {
            this.program = program;
            this.memory = memory;
            this.input = input;
            this.labels = labels;
            this.aliases = aliases;
        }

        private string Fetch()
        {
            clockcount++;
            if (memory.GetValue("PC") == program.Count)
            {
                Execute(new string[] {"END"});
                return null; //If end doesn't exist, make it exist
            }
            return program[memory.GetValue("PC")];
        }
        private void AddressOut()
        {
            
        }
        public void ExecuteLoadedProgramExperimental()
        {
            while (true)
            {
                AddressOut(); //does nothing
                string operation = Fetch();
                if (operation != null)
                    Execute(Interpret(operation));
                else
                    return; //END
            }
        }
        private string[] Interpret(string operation) //purely for aesthetics
        {
            string[] splitoperation = operation.Split(' ');

            for (int i = 0; i < splitoperation.Length; i++)
            {
                if (splitoperation[i] == "IO" && i > 1)
                {
                    switch (i)
                    {
                        case 2:
                            memory.SetValue("IO1", input.GetInputToIO());
                            splitoperation[i] = "IO1";
                            break;
                        case 3:
                            memory.SetValue("IO2", input.GetInputToIO());
                            splitoperation[i] = "IO2";
                            break;
                    }
                }
            }
            return splitoperation;
        }

        private void Execute(string[] operation)
        {
            memory.SetValue("PC", memory.GetValue("PC") + 1);
            clockcount++;
            int numberOfArguments = operation.Length - 1;

            switch (operation[0])
                    {
                        case "END":
                            if (numberOfArguments > 0)
                                throw new ArgumentException();
                            else
                                return;
                        case "ADD":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) + memory.GetValue(operation[3]));
                            break;
                        case "SUB":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) - memory.GetValue(operation[3]));
                            break;
                        case "MUL":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) * memory.GetValue(operation[3]));
                            break;
                        case "DIV":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) / memory.GetValue(operation[3]));
                            break;
                        case "MOD":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) % memory.GetValue(operation[3]));
                            break;
                        case "AND":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) & memory.GetValue(operation[3]));
                            break;
                        case "ORO":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) | memory.GetValue(operation[3]));
                            break;
                        case "NOT":
                            memory.SetValue(operation[1], int.MaxValue - memory.GetValue(operation[2]));
                            break;
                        case "SLT":
                            if (memory.GetValue(operation[2]) < memory.GetValue(operation[3]))
                                memory.SetValue(operation[1], 1);
                            else
                                memory.SetValue(operation[1], 0);
                            break;
                        case "SGT":
                            if (memory.GetValue(operation[2]) > memory.GetValue(operation[3]))
                                memory.SetValue(operation[1], 1);
                            else
                                memory.SetValue(operation[1], 0);
                            break;
                        case "SEQ":
                            if (memory.GetValue(operation[2]) == memory.GetValue(operation[3]))
                                memory.SetValue(operation[1], 1);
                            else
                                memory.SetValue(operation[1], 0);
                            break;
                        case "CPY":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]));
                            break;
                        case "JMP":
                            memory.SetValue("PC", labels[operation[1]]);
                            break;
                        case "JPZ": 
                            if (memory.GetValue(operation[1]) == 0)
                                memory.SetValue("PC", labels[operation[2]]);
                            break;
                        case "JNZ": 
                            if (memory.GetValue(operation[1]) != 0)
                                memory.SetValue("PC", labels[operation[2]]);
                            break;
                        case "LOD": //Not implemented
                            break;
                        case "STO": //Not implemented
                            break;
                        case "IMM":
                            memory.SetValue(operation[1], Convert.ToInt32(operation[2]));
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
                            memory.SetValue(operation[1], memory.GetValue(operation[1]) + 1);
                            break;
                        case "DEC":
                            memory.SetValue(operation[1], memory.GetValue(operation[1]) - 1);
                            break;
                        case "NOP":
                            break;
                    }
            memory.ResetTempIORegister();
        }
       /* public void ExecuteLoadedProgram() //Retrieve - Interpret - Writeback
        {
        
            while (true)
            {
                
                string[] operation;


                try
                {
                    operation = program[memory.GetValue("PC")].Split(' ');
                }
                catch (ArgumentOutOfRangeException e)
                {
                    return;
                }
                try
                {
                        if (operation[2] == "IO" || operation[3] == "IO")
                        {
                            memory.SetValue(operation[1], input.GetInputToIO());
                            memory.SetValue("PC", memory.GetValue("PC") + 1);
                            continue;
                        }
                }
                catch (Exception e) {}

                int numberOfArguments = operation.Length - 1;
                if (!operation[0].StartsWith("@"))
                {
                    bool c = false;
                    for (int i = 0; i < operation.Length; i++)
                    {
                        if (operation[i].StartsWith("$"))
                        {
                            operation[i] = ReplaceAliasWithValue(operation[i]);
                        }
                    }
                    switch (operation[0])
                    {
                        case "END":
                            if (numberOfArguments > 0)
                                throw new ArgumentException();
                            else
                                return;
                        case "ADD":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) + memory.GetValue(operation[3]));
                            break;
                        case "SUB":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) - memory.GetValue(operation[3]));
                            break;
                        case "MUL":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) * memory.GetValue(operation[3]));
                            break;
                        case "DIV":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) / memory.GetValue(operation[3]));
                            break;
                        case "MOD":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) % memory.GetValue(operation[3]));
                            break;
                        case "AND":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) & memory.GetValue(operation[3]));
                            break;
                        case "ORO":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]) | memory.GetValue(operation[3]));
                            break;
                        case "NOT":
                            memory.SetValue(operation[1], int.MaxValue - memory.GetValue(operation[2]));
                            break;
                        case "SLT":
                            if (memory.GetValue(operation[2]) < memory.GetValue(operation[3]))
                                memory.SetValue(operation[1], 1);
                            else
                                memory.SetValue(operation[1], 0);
                            break;
                        case "SGT":
                            if (memory.GetValue(operation[2]) > memory.GetValue(operation[3]))
                                memory.SetValue(operation[1], 1);
                            else
                                memory.SetValue(operation[1], 0);
                            break;
                        case "SEQ":
                            if (memory.GetValue(operation[2]) == memory.GetValue(operation[3]))
                                memory.SetValue(operation[1], 1);
                            else
                                memory.SetValue(operation[1], 0);
                            break;
                        case "CPY":
                            memory.SetValue(operation[1], memory.GetValue(operation[2]));
                            break;
                        case "JMP":
                            memory.SetValue("PC", labels[operation[1]]);
                            c = true;
                            break;
                        case "JPZ": //Not implemented
                            if (memory.GetValue(operation[1]) == 0)
                            {
                                c = true;
                                memory.SetValue("PC", labels[operation[2]]);
                            }
                            break;
                        case "JNZ": //Not implemented
                            if (memory.GetValue(operation[1]) != 0)
                            {
                                c = true;
                                memory.SetValue("PC", labels[operation[2]]);
                            }
                            break;
                        case "LOD": //Not implemented
                            break;
                        case "STO": //Not implemented
                            break;
                        case "IMM":
                            memory.SetValue(operation[1], Convert.ToInt32(operation[2]));
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
                                memory.SetValue(operation[1], memory.GetValue(operation[1]) + 1);
                            break;
                        case "DEC":
                            if (numberOfArguments > 1)
                                throw new ArgumentException();
                            else
                                memory.SetValue(operation[1], memory.GetValue(operation[1]) - 1);
                            break;
                        case "NOP":
                            break;
                    }
                    if (!c) 
                        memory.SetValue("PC", memory.GetValue("PC") + 1);
                }
                else
                    continue;

            }
        }*/
    }
}
