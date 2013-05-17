using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSim
{
    class Parser
    {
        List<string> program = new List<string>();
        

        public void SetProgram(List<string> program)
        {
            this.program = program;
        }

        private string CleanLine(string line)
        {
            //line = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Trim();
            int index = line.IndexOf("#");
            line.Replace(@"\t", "");
            if (index >= 0)
            {
                line = line.Substring(0, index);
                
                return System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Trim();
            }
            else
                return System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Trim();
        }

        private void CleanSourceFile()
        {
            foreach (string line in program)
            {

                string temp = line;
                //line = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Trim();
                int index = line.IndexOf("#");
                if (index >= 0)
                {
                    temp = line.Substring(0, index);
                    program[program.IndexOf(line)] = System.Text.RegularExpressions.Regex.Replace(temp, @"\s+", " ").Trim();
                }
                else
                    program[program.IndexOf(line)] = System.Text.RegularExpressions.Regex.Replace(temp, @"\s+", " ").Trim();
            }
        }

        private void ParseLabels()
        {

        }

        public List<string> GetParsedProgram()
        {
            ParseLabels();
            foreach (string line in program)
                CleanLine(line);
            //CleanSourceFile();
            return program;
            
        }

    }
}
