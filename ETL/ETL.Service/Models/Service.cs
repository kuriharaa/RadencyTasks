using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service.Models
{
    public class Service
    {
        public string Name { get; set; } = String.Empty;
        public List<Payer> Payers { get; set; } = new();
        public decimal Total { get; set; }
    }
}
