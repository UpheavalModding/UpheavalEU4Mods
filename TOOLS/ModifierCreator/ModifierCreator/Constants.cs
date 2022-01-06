using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ModifierCreator
{
    public sealed class Constants
    {
        private Constants() { }

        static Constants() { }

        private static readonly Constants _instance = new Constants();

        public static Constants Instance => _instance;

        private List<string> _modifiers;

        public List<string> GetModifiers()
        {
            if (_modifiers == null)
            {
                GenerateModifiers();
            }

            return new List<string>(_modifiers);
        }

        private void GenerateModifiers()
        {
            var lines = File.ReadAllLines("ModifiersList.txt");
            _modifiers = lines.ToList();
        }

        public static Version CurrentVersion = new Version(1, 0, 0, 0);

        public const string SaveFileName = "lastconfig.txt";
        public const string OutputDirectoryName = "event_modifiers";
        public const int MaxTier = 3;
        public const string FileNamePrefix = "unequal_nations_2_";
    }
}
