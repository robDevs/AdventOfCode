
string fileContent = File.ReadAllText("src/Year2025/Day02/input.txt");
string[] idRanges = fileContent.Split(",");

Console.WriteLine($"Solving Day02 part01: {SolvePartOne(idRanges)}");
Console.WriteLine($"Solving Day02 part02: {SolvePartTwo(idRanges)}");


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

/*
input: string[] representing id ranges. 
EG: start-end

invalid IDs are invalid if made of only repeating sequences
sequence could be any lenght < length of string
*/

static long SolvePartTwo(string[] idRanges)
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

            // scan the string
            for (int x = 1; x < id.Length; x++) // x is the size of the scan window`
            {
                if (id.Length % x != 0)
                {
                    continue; // skip when not all sequences will be equal size
                }

                var sequences = SplitStringSize(id, x);

                // assume all are equal 
                bool repeating = true;
                foreach (var sequence in sequences)
                {
                    if (sequence.Equals(id.Substring(0, x)) == false)
                    {
                        repeating = false;
                        break;
                    }
                }

                if (repeating)
                {
                    sum += i;
                    break;
                }
            }
        }
    }

    return sum;
}

static List<string> SplitStringSize(string input, int size)
{
    List<string> values = [];
    for (int i = 0; i < input.Length; i += size)
    {
        int currentChunkLength = Math.Min(size, input.Length - i);
        values.Add(input.Substring(i, currentChunkLength));
    }

    return values;
}
