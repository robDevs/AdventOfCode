string[] lines = File.ReadAllLines("src/Year2025/Day05/input.txt");

Console.WriteLine($"Solving Day05 part01 {SolvePartOne(lines)}");
Console.WriteLine($"Solving Day05 part02 {SolvePartTwo(lines)}");

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

static long SolvePartTwo(string[] lines)
{
    List<Tuple<long, long>> ranges = [];
    List<Tuple<long, long>> combinedRanges = [];

    foreach (var line in lines)
    {
        if (line == string.Empty)
        {
            break;
        }

        var start = long.Parse(line.Split('-')[0]);
        var end = long.Parse(line.Split('-')[1]);

        ranges.Add(new Tuple<long, long>(start, end));
    }

    ranges.Sort((a, b) => a.Item1.CompareTo(b.Item1));

    foreach (var range in ranges)
    {
        long start = range.Item1;
        long end = range.Item2;

        if (combinedRanges.Count == 0)
        {
            combinedRanges.Add(new Tuple<long, long>(start, end));
            continue;
        }

        long? newStart = null;
        long? newEnd = null;

        long removeStart = 0;
        long removeEnd = 0;

        foreach (var compRange in combinedRanges) // the range to compare to
        {
            long compStart = compRange.Item1;
            long compEnd = compRange.Item2;

            if (start <= compEnd && end >= compStart)
            {
                removeStart = compStart;
                removeEnd = compEnd;
                if (start < compStart)
                {
                    newStart = start;
                }
                else
                {
                    newStart = compStart;
                }

                if (end > compEnd)
                {
                    newEnd = end;
                }
                else
                {
                    newEnd = compEnd;
                }
                break;
            }
        }

        if (newStart != null)
        {
            var toRemove = combinedRanges.First(r => r.Item1 == removeStart && r.Item2 == removeEnd);
            combinedRanges.Remove(toRemove);
            combinedRanges.Add(new Tuple<long, long>((long)newStart, (long)newEnd!));
        }
        else
        {
            combinedRanges.Add(range);
        }
    }

    long sum = 0;

    foreach (var range in combinedRanges)
    {
        sum += range.Item2 - range.Item1;
        sum += 1;
    }

    return sum;
}