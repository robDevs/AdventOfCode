
string[] lines = File.ReadAllLines("src/Year2025/Day03/input.txt");

Console.WriteLine($"Solving part one: {SolvePartOne(lines)}");

static int SolvePartOne(string[] input)
{
    int sumLargestPairs = 0;

    foreach (string line in input)
    {
        int largest = 0;
        for (int i = 0; i < line.Length - 1; i++)
        {
            for (int x = i + 1; x < line.Length; x++)
            {
                int pair = int.Parse(line[i].ToString() + line[x].ToString());

                if (pair > largest) largest = pair;
            }
        }
        sumLargestPairs += largest;
    }

    return sumLargestPairs;
}