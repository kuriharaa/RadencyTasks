using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service.Models
{
    public class OutputData
    {
        public string City { get; set; } = String.Empty;
        public List<Service> Services { get; set; } = new();
        public decimal Total { get; set; }

        public static List<OutputData> Map(List<InputData> inputData)
        {
            if (inputData.Count == 0)
                return new List<OutputData>();
            var listData = inputData
                .GroupBy(x => x.City)
                .Select(grp => new OutputData()
                {
                    City = grp.Key,
                    Services = grp
                        .GroupBy(s => s.ServiceName)
                        .Select(sGroup => new Service
                        {
                            Name = sGroup.Key,
                            Payers = sGroup.Select(s => new Payer()
                            {
                                Date = s.Date,
                                Name = $"{s.FirstName} {s.SecondName}",
                                Payment = s.Payment,
                                AccountNumber = s.AccountNumber
                            }).ToList(),
                            Total = sGroup.Sum(p => p.Payment)
                        }).ToList(),
                    Total = grp.Sum(p => p.Payment)
                }).ToList();
            return listData;
        }
    }
}
