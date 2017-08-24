using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexViewer
{
    // Im aware I can do enumerations instead, but I wanted to do it this way for categorization and neatness.
    public static class Constants
    {
        public class Index
        {
            public static int Undefined = -1;
        }
        public class Logging
        {
            public static string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Index Viewer";
            public static string FileName = "log.txt";
            public static string FullPath = FilePath + @"\" + FileName;
        }

        public class Configuration
        {
            public static string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Index Viewer";
            public static string FileName = "config.cfg";
            public static string FullPath = FilePath + @"\" + FileName;
        }

        public class Working
        {
            public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Index Viewer\Temporary";
        }
    }
}