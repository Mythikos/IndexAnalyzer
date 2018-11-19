using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IndexAnalyzer.Objects
{
    public class IndexDefinition
    {
        public string Name { get; set; }
        public int? Position { get; set; }
        public int? Length { get; set; }
        public string DataType { get; set; }

        public IndexDefinition()
        {
            this.Name = null;
            this.Position = null;
            this.Length = null;
            this.DataType = "None";
        }

        public IndexDefinition(string name = null, int? position = null, int? length = null, string datatype = "None")
        {
            this.Name = name;
            this.Position = position;
            this.Length = length;
            this.DataType = datatype;
        }
    }
}