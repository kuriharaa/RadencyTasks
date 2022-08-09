using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service.Logger
{
    public class LogDetails
    {
        public int Lines { get; set; }
        public int Errors { get; set; }
        public string FilePath { get; set; }
        public LogDetails(int errors, int inputLines, string path)
        {
            Lines = inputLines;
            Errors = errors;
            FilePath = path;
        }
    }
}
