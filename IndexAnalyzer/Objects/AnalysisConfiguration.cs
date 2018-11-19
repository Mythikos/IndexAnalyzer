using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexAnalyzer.Objects
{
    public enum IndexOffset { Zero = 0, One = 1 }

    public class AnalysisConfiguration
    {

        public FileInfo File { get; set; }
        public IndexOffset IndexOffset { get; set; }
        public bool? ShouldIgnoreHeaderRow { get; set; }
        public bool? ShouldIgnoreTrailerRow { get; set; }
        public bool? ShouldIncludeRowIdColumn { get; set; }
        public bool? ShouldIncludeFlagColumn { get; set; }
        public List<IndexDefinition> IndexDefinitions { get; set; }

        public AnalysisConfiguration()
        {
            this.File = null;
            this.IndexOffset = IndexOffset.Zero;
            this.ShouldIgnoreHeaderRow = null;
            this.ShouldIgnoreTrailerRow = null;
            this.ShouldIncludeRowIdColumn = null;
            this.ShouldIncludeFlagColumn = null;
            this.IndexDefinitions = null;
        }

        public AnalysisConfiguration(FileInfo file = null, IndexOffset zeroBaseOffset = IndexOffset.Zero, bool? shouldIgnoreHeaderRow = null, bool? shouldIgnoreTrailerRow = null, bool? shouldIncludeRowIdColumn = null, bool? shouldIncludeFlagColumn = null, List<IndexDefinition> indexDefinitions = null)
        {
            this.File = file;
            this.IndexOffset = zeroBaseOffset;
            this.ShouldIgnoreHeaderRow = shouldIgnoreHeaderRow;
            this.ShouldIgnoreTrailerRow = shouldIgnoreTrailerRow;
            this.ShouldIncludeRowIdColumn = shouldIncludeRowIdColumn;
            this.ShouldIncludeFlagColumn = shouldIncludeFlagColumn;
            this.IndexDefinitions = indexDefinitions;
        }

        public AnalysisConfiguration SortIndexDefinitionsByPosition()
        {
            this.IndexDefinitions = this.IndexDefinitions.OrderBy(x => x.Position).ToList();
            return this;
        }
    }
}
