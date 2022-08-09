using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Service.Models
{
    public class Payer
    {
        public string Name { get; set; } = String.Empty;
        public decimal Payment { get; set; }
        public DateTime Date { get; set; }
        [JsonProperty("account_number")]
        public long AccountNumber { get; set; }
    }
}
