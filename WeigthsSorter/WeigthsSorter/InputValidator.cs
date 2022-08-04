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
        private const string NullOrWhiteSpaceError = "null || empty || whitespaces";
        private const string AllDigitsError = "contains >=1 no num substring/s";
        private const string PositiveValuesError = "contains >=1 not positive number/s";

        private static void SpacesRemover(ref string input) => input = Regex.Replace(input.Trim(), @"\s+", " ");
        private static bool AreAllDigits(ref string input) => input.Replace(" ", "").All(char.IsDigit);
        private static void AreAllPositiveValues(ref string input, out bool valid, out List<int> validatedValues)
        {
            validatedValues = input.Split(' ').Select(sn => int.Parse(sn)).ToList();
            valid = validatedValues.All(n => n > 0);
        }
        internal static List<int> GetValidatedNumValues(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new Exception(NullOrWhiteSpaceError);

            InputValidator.SpacesRemover(ref input!);

            if (!InputValidator.AreAllDigits(ref input)) throw new Exception(AllDigitsError);

            bool valid;
            List<int> validatedValues;
            InputValidator.AreAllPositiveValues(ref input, out valid, out validatedValues);

            if (!valid) throw new Exception(PositiveValuesError);

            return validatedValues;
        }
    }
}
