namespace WeightsSorter
{
    internal static class Extention
    {
        internal static int GetSum(string value)
        {
            int sum = 0;

            char[] numbers = value.ToCharArray();

            foreach(char number in numbers)
            {
                sum += int.Parse(number.ToString());
            }

            return sum;
        }
    }
}