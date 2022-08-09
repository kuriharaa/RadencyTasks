using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.Service.Logger;
using ETL.Service.Reader;
using Microsoft.Extensions.DependencyInjection;

namespace ETL.Service.Settings
{
    public static class DI
    {
        public static IServiceCollection AddETLService(this IServiceCollection service) => service.AddTransient(service => new LogWriter(service.GetRequiredService<PathConfig>().outPath)).AddTransient<IAllFilesReader, AllFilesReader>().AddTransient<IETLService, ETLService>();
    }
}
