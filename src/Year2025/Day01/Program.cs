string[] lines = File.ReadAllLines("src/Year2025/Day01/input.txt");

Console.WriteLine($"Solving Day01 Part01: {SolvePartOne(lines)}");
Console.WriteLine($"Solving Day01 Part02: {SolvePartTwo(lines)}");

static int SolvePartOne(string[] lines)
{
    int count = 0; // count how many times the dial lands on 0;
    int position = 50; // current dial position, starts at 50. Range = 0-99

    foreach (var line in lines)
    {
        var direction = line.Substring(0, 1);
        int steps = int.Parse(line.Substring(1));

        if (direction.Equals("L")) // L means turn left, R means turn right
        {
            steps *= -1;
        }

        position += steps;

        // steps could be greater than the size of the "wheel" 
        // so we adjust by the size of the wheel until it's whithin range. 
        while (position < 0)
        {
            position = 100 - Math.Abs(position);
        }
        while (position > 99)
        {
            position -= 100;
        }
        if (position == 0)
        {
            count += 1;
        }
    }

    return count;
}

static int SolvePartTwo(string[] lines)
{
    int count = 0;
    int position = 50; // start at 50, range = 0-99

    // this time we want to count how many times the dial points at 0, not just when it lands on 0;

    foreach (var line in lines)
    {
        var direction = line.Substring(0, 1);
        int steps = int.Parse(line.Substring(1));

        for (int i = 0; i < steps; i++)
        {
            if (direction.Equals("L"))
            {
                position -= 1;
            }
            else
            {
                position += 1;
            }

            if (position < 0) position = 99;
            if (position > 99) position = 0;

            if (position == 0) count++;
        }
    }

    return count;
}