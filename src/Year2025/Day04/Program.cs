// input is a grid of . and @
// @ represents occupied space
// . represents free space
// a @ can be accessed if there are fewer than 4 occupied spaces around it
// how many @s are accesible? 


string[] lines = File.ReadAllLines("src/Year2025/Day04/input.txt");

// get the x and y axis sizes
int x_axis = lines[0].Length;
int y_axis = lines.Length;

string[,] grid = new string[x_axis, y_axis];

for (int x = 0; x < x_axis; x++)
{
    for (int y = 0; y < y_axis; y++)
    {
        grid[x, y] = lines[y][x].ToString();
    }
}

Console.WriteLine($"Solving Day04 part01: {SolvePartOne(grid)}");
Console.WriteLine($"Solving Day04 part02: {SolvePartTwo(grid)}");


static int SolvePartOne(string[,] input)
{
    int sum = 0;

    int x_axis = input.GetLength(0);
    int y_axis = input.GetLength(1);

    for (int x = 0; x < x_axis; x++)
    {
        for (int y = 0; y < y_axis; y++)
        {
            if (input[x, y].Equals("@") && CountSurroundingOccupiedSpaces(input, x, y) < 4)
            {
                sum += 1;
            }
        }
    }

    return sum;
}

static int CountSurroundingOccupiedSpaces(string[,] input, int x_pos, int y_pos)
{
    int sum = 0;

    int x_start = Math.Max(0, x_pos - 1);
    int x_end = Math.Min(input.GetLength(0) - 1, x_pos + 1);

    int y_start = Math.Max(0, y_pos - 1);
    int y_end = Math.Min(input.GetLength(1) - 1, y_pos + 1);

    for (int x = x_start; x <= x_end; x++)
    {
        for (int y = y_start; y <= y_end; y++)
        {
            if (input[x, y].Equals("@"))
            {
                if (x == x_pos && y == y_pos) continue;

                sum += 1;
            }
        }
    }

    return sum;
}

static int SolvePartTwo(string[,] input)
{
    int sum = 0;
    List<int[]> accesible = [];

    int x_axis = input.GetLength(0);
    int y_axis = input.GetLength(1);

    for (int x = 0; x < x_axis; x++)
    {
        for (int y = 0; y < y_axis; y++)
        {
            if (input[x, y].Equals("@") && CountSurroundingOccupiedSpaces(input, x, y) < 4)
            {
                sum += 1;
                accesible.Add([x, y]);
            }
        }
    }

    foreach (var item in accesible)
    {
        input[item[0], item[1]] = ".";
    }

    if (sum > 0) sum += SolvePartTwo(input);
    return sum;
}
