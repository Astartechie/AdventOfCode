namespace AdventOfCode.Year_2015.Day_1;

internal class Day1 : IDay
{
    public static void Solve()
    {
        const string path = @"Year_2015\Day_1\input.txt";
        var day = new Day1();
        day.Run(File.ReadLines(path));
    }

    public void Run(IEnumerable<string> input)
    {
        var lines = input.ToList();
        Console.WriteLine("Day 1:");
        Part1(lines);
        Part2(lines);
    }

    public void Part1(IEnumerable<string> input)
    {
        Console.WriteLine("\tPart 1:");
        var floor = 0;
        foreach (var line in input)
        {
            foreach (var c in line)
            {
                switch (c)
                {
                    case '(':
                        floor++;
                        break;
                    case ')':
                        floor--;
                        break;
                }
            }
        }

        Console.WriteLine($"\t\tFloor: {floor}");
    }

    public void Part2(IEnumerable<string> input)
    {
        Console.WriteLine("\tPart 2:");
        var floor = 0;
        var position = 0;
        foreach (var line in input)
        {
            foreach (var c in line)
            {
                position++;
                switch (c)
                {
                    case '(':
                        floor++;
                        break;
                    case ')':
                        floor--;
                        break;
                }

                if (floor < 0)
                {
                    Console.WriteLine($"\t\tPosition: {position}");
                    return;
                }
            }
        }

        
    }
}