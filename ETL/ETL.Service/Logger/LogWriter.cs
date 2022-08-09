using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service.Logger
{
    public class LogWriter
    {
        private readonly LogResult _log = new();
        private readonly string _directoryPath;
        public LogWriter(string directoryPath)
        {
            _directoryPath = directoryPath;
        }
        public async Task LogAsync(LogDetails logDetails)
        {
            _log.Log(logDetails.FilePath, logDetails.Errors, logDetails.Lines);
            using (var writter = new StreamWriter($@"{_directoryPath}\{DateTime.Now:dd-MM-yyyy}\meta.log", false))
            {
                await writter.WriteLineAsync(_log.ToString());
            }
        }
    }
}
