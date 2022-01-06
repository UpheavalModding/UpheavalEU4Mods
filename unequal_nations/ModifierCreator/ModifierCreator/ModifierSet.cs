using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifierCreator
{
    public class ModifierSet
    {
        public string Name { get; set; }

        public string FileName { get; set; }

        public Dictionary<string, Modifier> Modifiers { get; set; } = new Dictionary<string, Modifier>();
    }
}
