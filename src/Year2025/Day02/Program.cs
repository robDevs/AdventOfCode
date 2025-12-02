
string fileContent = File.ReadAllText("src/Year2025/Day02/input.txt");
string[] idRanges = fileContent.Split(",");

Console.WriteLine($"Solving Day02 part01: {SolvePartOne(idRanges)}");


static long SolvePartOne(string[] idRanges)
{
    long sum = 0;

    foreach (var range in idRanges)
    {
        // split on the dash
        string[] StartEnd = range.Split("-");
        long start = long.Parse(StartEnd[0]);
        long end = long.Parse(StartEnd[1]);

        for (long i = start; i < end; i++)
        {
            string id = i.ToString();
            if (id.Length % 2 != 0) continue;

            string firstHalf = id.Substring(0, id.Length / 2);
            string secondHalf = id.Substring(id.Length / 2);

            if (firstHalf.Equals(secondHalf)) sum += i;
        }
    }

    return sum;
}
