using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSim
{
    class Input
    {
        public int GetInputToIO()
        {
            Console.WriteLine("Please input value for IO");
            string input = Console.ReadLine();
            return Convert.ToInt32(input);
        }
    }
}
