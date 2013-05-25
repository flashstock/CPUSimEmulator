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
        List<string> parsedprogram = new List<string>();
        Dictionary<string, int> labels = new Dictionary<string, int>();

        public void SetProgram(List<string> program)
        {
            this.program = program;
        }

        private string ParseLine(string line)
        {
            if (line.StartsWith("#"))
                return "";
            int index = line.IndexOf("#");
           
            if (index >= 0)
            {
                line = line.Substring(0, index);
                line = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Trim();
                if (line == "")
                    return "";
                else
                {
                    parsedprogram.Add(line);
                    return line;
                }
            }
            else
            {
                line = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Trim();
                if (line == "")
                    return "";
                else
                {
                    parsedprogram.Add(line);
                    return line;
                }
            }
        }

        private void ParseLabel(string line, int i)
        {
            if (line.StartsWith("@"))
            {
                int index = line.IndexOf("@");
                if (index >= 0)
                {
                    labels.Add(line.Substring(0, line.IndexOf(":")), i != 0 ? i - 1 : i); 
                }
                //labels.Add(line.Substring(1, line.IndexOf(":") - 1), i);
            }
        }

        public List<string> GetParsedProgram()
        {
            int i = 0;
            foreach (string line in program)
            {
                string parsedline = ParseLine(line);
                if (parsedline != "")
                {
                    ParseLabel(parsedline, i);
                    i++;
                }
                else
                    continue;
             
            }
            
            return parsedprogram;
            
        }

        public Dictionary<string, int> GetParsedLabels()
        {
            return labels;
        }

    }
}
