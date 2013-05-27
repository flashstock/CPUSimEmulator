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
        Dictionary<string, string> aliases = new Dictionary<string, string>();

        public void SetProgram(List<string> program)
        {
            this.program = program;
        }

        private string ParseLine(string line)
        {
            int index = line.IndexOf("#");

            if (index >= 0)
                line = line.Substring(0, index);
            line = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Trim();

            
            if (line == "" || line.StartsWith("#"))
                return "";
            if (line.StartsWith("$"))
            {
                ParseAlias(line);
                return "";
            }
            else
            {
                parsedprogram.Add(line);
                return line;
            }
        }

        private void ParseLabel(string line, int i)
        {
            if (line.StartsWith("@"))
            {
                int index = line.IndexOf("@");
                if (index >= 0)
                {
                    labels.Add(line.Substring(0, line.IndexOf(":")), i != 0 ? i - 1 : i); //magic snort snort
                }
            }
        }
        
        private void ParseAlias(string line)
        {
            if (line.StartsWith("$"))
            {
                string[] alias = line.Split(' ');
                aliases.Add(alias[0].Substring(0, alias[0].IndexOf(":")), alias[1]);
            }
        }

        private void ReplaceAliasWithValue()
        {
            for (int i = parsedprogram.Count - 1; i >= 0; i--) //holy shit
            {
                if (parsedprogram[i].Contains("$"))
                {
                    string[] temp = parsedprogram[i].Split(' ');
                    for (int p = 0; p < temp.Length; p++)
                    {
                        if (temp[p].StartsWith("$"))
                            temp[p] = aliases[temp[p]];
                    }
                    parsedprogram[i] = string.Join(" ", temp);
                    
                }
            }
            
        }

        public List<string> GetParsedProgram()
        {

            foreach (string line in program)
                ParseLine(line);
            
            
            int i = 0;
            foreach (string line in parsedprogram)
            {
                if (line != "")
                {
                    ParseLabel(line, i);
                    i++;
                }
                else
                    continue;
            }
            RemoveLabels();
            ReplaceAliasWithValue();
            return parsedprogram;
            
        }

        public Dictionary<string, int> GetParsedLabels()
        {
            return labels;
        }

        private void RemoveLabels() 
        {
            //remove labels so that they don't get interpreted as commands
            //to iterate and remove items from a list in one loop iterate backwards
            for (int i = parsedprogram.Count - 1; i >= 0; i--)
            {
                if (parsedprogram[i].StartsWith("@"))
                    parsedprogram.RemoveAt(i);
            }
        }

        public Dictionary<string, string> GetParsedAliases()
        {
            return aliases;
        }

    }
}
