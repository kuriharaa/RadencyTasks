using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service.Reader
{
    public interface IAllFilesReader
    {
        Task ReadAsync(CancellationTokenSource cancellationTokenSource = default!);
    }
}
