using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightsSorter
{
    internal static class WeightSorter
    {
        internal static string Order(string? input)
        {
            List<KeyValuePair<string, int>> weightsDict = new List<KeyValuePair<string, int>>() { }; 

            foreach (string value in InputValidator.GetValidatedNumValues(input))
            {
                weightsDict.Add(new KeyValuePair<string, int>(value, Extention.GetSum(value)));
            }

            var sortedDictWeights = weightsDict.OrderBy(kv => kv.Value).ThenBy(kv => kv.Key);

            return string.Join(' ', sortedDictWeights.Select(kv => kv.Key));
        }
    }
}
