using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeightsSorter
{
    internal static class InputValidator
    {
        private const string AllDigitsError = "contains >=1 no num substring/s || contains >=1 not positive number/s";
        private static void SpacesRemover(ref string input) => input = Regex.Replace(input.Trim(), @"\s+", " ");
        private static bool AreAllDigits(ref string input) => input.Replace(" ", "").All(char.IsDigit);
        private static List<string> GetValidatedValues(ref string input) => input.Split(' ').ToList();
        private static bool AreAllPositiveValues(ref List<string> inputValues) => inputValues.All(n => n != "0");
        
        internal static List<string> GetValidatedNumValues(string? input)
        {
            List<string> validatedValues = new List<string>();

            if (string.IsNullOrWhiteSpace(input)) return validatedValues;

            InputValidator.SpacesRemover(ref input!);

            validatedValues = GetValidatedValues(ref input);

            if (!InputValidator.AreAllDigits(ref input) || 
                !InputValidator.AreAllPositiveValues(ref validatedValues))
            {
                throw new Exception(AllDigitsError);
            }

            return validatedValues;
        }
    }
}
