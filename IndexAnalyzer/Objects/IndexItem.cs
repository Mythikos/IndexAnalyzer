using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexViewer.Objects
{
    public class IndexItem
    {
        private string _Name;
        private int _StartPosition;
        private int _Length;
        private string _Value;

        #region Contructors
        public IndexItem(string Name, string StartPosition, string Length)
        {
            _Name = Name;
            _Value = string.Empty;

            if (!int.TryParse(StartPosition, out _StartPosition))
                _StartPosition = 0;

            if (!int.TryParse(Length, out _Length))
                _Length = 0;
        }

        public IndexItem(string Name, int StartPosition, int Length, string Value)
        {
            _Name = Name;
            _Value = Value;
            _StartPosition = StartPosition;
            _Length = Length;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _Name; }
        }

        public int StartPosition
        {
            get { return _StartPosition; }
        }

        public int Length
        {
            get { return _Length; }
        }

        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        #endregion
    }
}
