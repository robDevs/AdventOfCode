
string[] lines = File.ReadAllLines("src/Year2025/Day03/input.txt");

Console.WriteLine($"Solving part one: {SolvePartOne(lines)}");
Console.WriteLine($"Solving part two: {SolvePartTwo(lines)}");

// find the largest ordered pair on each line. 
// add it to the sum. return sum
static int SolvePartOne(string[] input)
{
    int sumLargestPairs = 0;

    foreach (string line in input)
    {
        int first = LargestIntPos(line.Substring(0, line.Length - 1));
        int second = first + 1 + LargestIntPos(line.Substring(first + 1));
        sumLargestPairs += int.Parse(line[first].ToString() + line[second].ToString());
    }

    return sumLargestPairs;
}

// same as part 1 but with an ordered sequence 12 digits long. 
// find the largest possible ordered sequence in each line
// then add it to the sum. 
static long SolvePartTwo(string[] input)
{
    long sumLargestPairs = 0;

    foreach (string line in input)
    {
        List<int> posList = [];

        for (int i = 0; i < 12; i++)
        {
            if (i == 0)
            {
                posList.Add(LargestIntPos(line.Substring(0, line.Length - 11)));
                continue;
            }

            string sub = line.Substring(posList.Last() + 1);
            string searchArea = sub.Substring(0, sub.Length - (11 - posList.Count()));
            posList.Add(posList.Last() + 1 + LargestIntPos(searchArea));
        }

        string final = "";
        foreach (var item in posList)
        {
            final += line[item];
        }

        sumLargestPairs += long.Parse(final);
    }

    return sumLargestPairs;
}

static int LargestIntPos(string input)
{
    int largest = 0;

    for (int i = 0; i < input.Length; i++)
    {
        int num = int.Parse(input[i].ToString());

        if (num > int.Parse(input[largest].ToString())) largest = i;
    }

    return largest;
}