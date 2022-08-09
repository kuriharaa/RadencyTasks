using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service
{
    public interface IETLService
    {
        Task StartETLAsync(CancellationTokenSource cancellationTokenSource);
    }
}
