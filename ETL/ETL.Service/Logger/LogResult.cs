using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service.Logger
{
    public class LogResult
    {
        private List<string> paths { get; set; } = new();
        private int LinesAmount { get; set; }
        private int FilesAmount { get; set; }
        private int ErrorsAmount { get; set; }
        public void Log(string path, int errors, int lines)
        {
            FilesAmount++;
            LinesAmount += lines;
            ErrorsAmount += errors;
            paths.Add(path);
        }

        public override string ToString() => $"parsed_files: {FilesAmount}\nparsed_lines: {LinesAmount}\nfound_errors: {ErrorsAmount}\ninvalid_files -> [{string.Join(",", paths)}]";
    }
}
