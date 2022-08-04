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
            Dictionary<string, int> weightsDict = new Dictionary<string, int> { };
            foreach (int value in InputValidator.GetValidatedNumValues(input))
            {
                weightsDict.Add(value.ToString(), Extention.GetSum(value));
            }

            var sortedDictWeights = weightsDict.OrderBy(kv => kv.Value).ThenBy(kv => kv.Key);

            return string.Join(' ', sortedDictWeights.Select(kv => kv.Key));
        }
    }
}
