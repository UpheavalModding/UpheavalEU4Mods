using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifierCreator
{
    public class BuffOrNerf
    {
        public bool IsBuff = false;
        public string Name;
        public string ModifierName;
        public int Tier = 1;
        public List<string> Rows = new List<string>();

        public BuffOrNerf(string name, bool isBuff, int tier, string modifierName)
        {
            Name = name;
            IsBuff = isBuff;
            Tier = tier;
            ModifierName = modifierName;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{ModifierName} = {{");
            for (var i = 0; i < Rows.Count; i++)
            {
                sb.AppendLine($"    {Rows[i]}");
            }

            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
