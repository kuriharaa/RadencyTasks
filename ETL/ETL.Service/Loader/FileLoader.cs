using ETL.Service.Logger;
using ETL.Service.Models;
using ETL.Service.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service.Loader
{
    public class FileLoader
    {
        private readonly LogWriter _logWriter;

        public FileLoader(LogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        public async Task ReadAndWriteAsync(FileSaver fileSaver, FileReader fileReader)
        {
            var inputs = await fileReader.ReadFileAsync();
            var logInfo = fileReader.GetLogs();
            await fileSaver.SaveFileAsync(OutputData.Map(inputs));
            await _logWriter.LogAsync(logInfo);
        }
    }
}
