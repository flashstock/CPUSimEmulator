using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSim
{
    class Memory
    {
        Dictionary<string, int> registers = new Dictionary<string, int>();
        Dictionary<int, int> ram = new Dictionary<int, int>();
        List<int> stack = new List<int>();

        public Memory()
        {
            //Initialize registers
            registers.Add("R0", 0);
            registers.Add("R1", 0);
            registers.Add("R2", 0);
            registers.Add("R3", 0);
            registers.Add("R4", 0);
            registers.Add("R5", 0);
            registers.Add("R6", 0);
            registers.Add("R7", 0);
            registers.Add("SP", 0);
            registers.Add("PC", 0);
            registers.Add("IR", 0);
            //registers.Add("IO", 0);
            registers.Add("RL", 0);
            registers.Add("TP", 0);
            
           
        }

        public int GetValue(string register)
        {
            return registers[register];
        }

        public void SetValue(string register, int value)
        {
            if (GetValue(register) + value < 0)
                throw new ArgumentException();
            else
            {
                registers[register] = value;
                if (register == "IO")
                    Console.WriteLine("[IO event]:" + this.GetValue("IO"));
                else if (register != "PC")
                    Console.WriteLine("[{0} event]:{1}", register, this.GetValue(register));
            }
        }

        public void DumpRegisters()
        {
            foreach (var register in registers)
            {
                if (register.Key == "IO1" || register.Key == "IO2")
                    continue;
                Console.WriteLine("[{0}], [DEC:{1} HEX:{2} BIN:{3}]", register.Key, register.Value, register.Value.ToString("X"),
                    Convert.ToString(register.Value, 2));
            }
        }
        public void DumpRAM()
        {
            foreach (var memory in ram)
            {
                Console.WriteLine("[{0}], [DEC:{1} HEX:{2} BIN:{3}]", memory.Key, memory.Value, memory.Value.ToString("X"),
                    Convert.ToString(memory.Value, 2));
            }
        }

        
    }
}
