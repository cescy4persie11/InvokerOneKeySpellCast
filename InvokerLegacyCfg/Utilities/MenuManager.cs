using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensage.Common.Menu;
using SharpDX;

namespace InvokerLegacyCfg.Utilities
{
    public class MenuManager
    {
        public Menu Menu { get; private set; }

        public MenuManager(string heroName)
        {
            this.Menu = new Menu("InvokerSharp", "InvokerSharp", true, heroName, true);
        }


    }
}
