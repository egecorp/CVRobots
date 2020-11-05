using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class CommandSet
    {

        public List<OneCommand> CommandList { get;  private set; }

        public CommandSet(string commandString)
        {
            CommandList = new List<OneCommand>();

            foreach (char c in (commandString ?? ""))
            {
                if (c == 'L')
                {
                    CommandList.Add(OneCommand.L);
                }
                else if (c == 'R') 
                {
                    CommandList.Add(OneCommand.R);
                }
                else if (c == 'F')
                {
                    CommandList.Add(OneCommand.F);
                }
            }
        }        

    }
}
