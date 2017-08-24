using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexViewer.Objects
{
    public class AnalyzerConfiguration
    {
        private string _FilePath;
        private int _Offset;
        private bool _IgnoreHeaderRow;
        private bool _IgnoreTrailerRow;

        #region Constructors
        public AnalyzerConfiguration(string FilePath, int Offset, bool IgnoreHeaderRow, bool IgnoreTrailerRow)
        {
            _FilePath = FilePath;
            _Offset = Offset;
            _IgnoreHeaderRow = IgnoreHeaderRow;
            _IgnoreTrailerRow = IgnoreTrailerRow;
        }
        #endregion

        #region Properties
        public string FilePath
        {
            get { return _FilePath; }
        }

        public int Offset
        {
            get { return _Offset; }
        }

        public bool IgnoreHeaderRow
        {
            get { return _IgnoreHeaderRow; }
        }

        public bool IgnoreTrailerRow
        {
            get { return _IgnoreTrailerRow; }
        }
        #endregion
    }
}
