using WeightsSorter;

Start:

try
{
    Console.WriteLine(WeightSorter.Order(Console.ReadLine()));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("end of sorting");

goto Start;