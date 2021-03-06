﻿using System;
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
            registers.Add("IO", 0);
            registers.Add("RL", 0);
            registers.Add("TP", 0);
            registers.Add("IO1", 0); //special magical registers, used as temp registers when using IO..
            registers.Add("IO2", 0);
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
                if (register == "IO1" || register == "IO2" || register == "PC")
                    return;
                else
                    Console.WriteLine("[{0} event]:{1}", register, this.GetValue(register));
            }
        }

        public void DumpRegisters()
        {
            foreach (var register in registers)
            {
                if (register.Key == "IO1" || register.Key == "IO2")
                    continue;
                Console.WriteLine("[{0}], [DEC:{1} HEX:{2}]", register.Key, register.Value, register.Value.ToString("X"));
            }
        }
        public void DumpRAM()
        {
            foreach (var memory in ram)
            {
                Console.WriteLine("[{0}], [DEC:{1} HEX:{2}]", memory.Key, memory.Value, memory.Value.ToString("X"));
            }
        }
        public void ResetTempIORegister()
        {
            SetValue("IO1", 0); 
            SetValue("IO2", 0); // We don't want to use these magical registers for storing
        }

        
    }
}
