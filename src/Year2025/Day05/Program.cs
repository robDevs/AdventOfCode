string[] lines = File.ReadAllLines("src/Year2025/Day05/input.txt");

Console.WriteLine($"Solving Day05 part01 {SolvePartOne(lines)}");

static int SolvePartOne(string[] lines)
{
    int sum = 0;
    bool readRanges = true;

    List<string> ranges = [];
    List<long> idList = [];

    foreach (var line in lines)
    {
        if (readRanges)
        {
            if (line == string.Empty)
            {
                readRanges = false;
                continue;
            }

            ranges.Add(line);
        }
        else
        {
            idList.Add(long.Parse(line));
        }
    }

    foreach (long id in idList)
    {
        bool fresh = false;
        foreach (var range in ranges)
        {
            long start = long.Parse(range.Split('-')[0]);
            long end = long.Parse(range.Split('-')[1]);

            if (id >= start && id <= end)
            {
                sum += 1;
                fresh = true;
                break;
            }
        }
        if (fresh) continue;
    }

    return sum;
}