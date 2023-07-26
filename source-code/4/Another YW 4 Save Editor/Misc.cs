using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_YW_4_Save_Editor
{
    internal class Misc
    {
        public string ToumaName { get; set; }

        public string SummerName { get; set; }

        public string AkinoriName { get; set; }

        public string JackName { get; set; }

        public string NateName { get; set; }

        public string KatieName { get; set; }

        public int Money { get; set; }

        public int MoneySpent { get; set; }

        public LocalParams LocalParams { get; set; } = new LocalParams();

        public Gatcha Gatcha { get; set; } = new Gatcha();
    }
}
