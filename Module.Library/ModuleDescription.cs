using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class ModuleDescription
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string[] Authors { get; set; }
        public string Website { get; set; }

        public ModuleDescription(string name, string version, string[] authors, string website)
        {
            this.Name = name;
            this.Version = version;
            this.Authors = authors;
            this.Website = website;
        }

        public string ToString(bool website)
        {
            return $"Module [Name={Name}/Version={Version}/Authors={string.Join(", ", Authors)}{(website == true ? $"/Website={Website}" : "")}]";
        }
    }
}
