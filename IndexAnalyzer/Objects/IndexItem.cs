using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexAnalyzer.Objects
{
    public class IndexItem
    {
        public string Value { get; set; }
        public string Flags { get; set; }
        public IndexDefinition IndexDefinition { get; set; }

        public IndexItem()
        {
            this.Value = null;
            this.Flags = null;
            this.IndexDefinition = null;
        }

        public IndexItem(string value = null, string flags = null, IndexDefinition indexDefinition = null)
        {
            this.Value = value;
            this.Flags = flags;
            this.IndexDefinition = indexDefinition;
        }
    }
}
