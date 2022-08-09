using ETL.Service.Loader;
using ETL.Service.Logger;
using ETL.Service.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service.Reader
{
    public class AllFilesReader : IAllFilesReader
    {
        private readonly PathConfig _pathConfig;
        private readonly LogWriter _logWriter;

        public AllFilesReader(PathConfig pathConfig, LogWriter logWriter)
        {
            _pathConfig = pathConfig;
            _logWriter = logWriter;
        }

        public async Task ReadAsync(CancellationTokenSource cancellationTokenSource = default!)
        {
            int fileCounter = 1;
            var tasks = Directory.GetFiles(_pathConfig.inPath)
                 .Select(async l => await new FileLoader(_logWriter)
                                                .ReadAndWriteAsync
                                                (
                                                    new FileSaver($"output{fileCounter++}.json", _pathConfig.outPath),
                                                    new FileReader(l)
                                                )).ToArray();
            await Task.Run(() => Task.WaitAny(tasks, cancellationTokenSource.Token));
        }
    }
}
