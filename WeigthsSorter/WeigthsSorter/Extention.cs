namespace WeightsSorter
{
    internal static class Extention
    {
        internal static int GetSum(int value)
        {
            int sum = 0;

            while (value != 0)
            {
                sum += value % 10;
                value /= 10;
            }

            return sum;
        }
    }
}