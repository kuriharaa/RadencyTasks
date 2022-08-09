using ETL.Service.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service
{
    public class ETLService : IETLService
    {
        private readonly IAllFilesReader _allFilesReader;
        public ETLService(IAllFilesReader allFilesReader)
        {
            _allFilesReader = allFilesReader;
        }

        public async Task StartETLAsync(CancellationTokenSource cancellationTokenSource = default!)
        {
            await _allFilesReader.ReadAsync(cancellationTokenSource);
        }
    }
}
