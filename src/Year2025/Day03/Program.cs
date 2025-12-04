
string[] lines = File.ReadAllLines("src/Year2025/Day03/input.txt");

Console.WriteLine($"Solving part one: {SolvePartOne(lines)}");

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