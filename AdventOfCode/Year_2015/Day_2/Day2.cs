namespace AdventOfCode.Year_2015.Day_2;

public class Day2 : IDay
{
    private const char DimensionDelimiter = 'x';

    public static void Solve()
    {
        const string path = @"Year_2015\Day_2\input.txt";
        var day = new Day2();
        day.Run(File.ReadLines(path));
    }

    public void Run(IEnumerable<string> input)
    {
        Console.WriteLine("Day 2");
        var boxes = Read(input);
        Part1(boxes);
        Part2(boxes);
    }

    private void Part1(IEnumerable<Box> boxes)
    {
        Console.WriteLine("\tPart 1");
        var totalSquareFootage = 0;
        foreach (var box in boxes)
        {
            var frontSurfaceArea = box.Width * box.Height;
            var topSurfaceArea = box.Width * box.Length;
            var rightSurfaceArea = box.Length * box.Height;

            var totalSurfaceArea = (topSurfaceArea + rightSurfaceArea + frontSurfaceArea) * 2;
            var slack = new[] { frontSurfaceArea, topSurfaceArea, rightSurfaceArea }.Min();

            totalSquareFootage += totalSurfaceArea;
            totalSquareFootage += slack;
        }

        Console.WriteLine($"\t\tSquare Footage: {totalSquareFootage}");
    }

    private void Part2(IEnumerable<Box> boxes)
    {
        Console.WriteLine("\tPart 2");
        var totalFootage = 0;
        foreach (var box in boxes)
        {
            var sideRibbon = 0;
            var sides = new[] { box.Length, box.Length, box.Width, box.Width, box.Height, box.Height }.Order().ToList();
            for (var index = 0; index < 4; index++)
            {
                sideRibbon += sides[index];
            }

            totalFootage += sideRibbon;
            var bowRibbon = box.Length * box.Width * box.Height;
            totalFootage += bowRibbon;
        }

        Console.WriteLine($"\t\tRibbon Footage: {totalFootage}");
    }

    private static IReadOnlyList<Box> Read(IEnumerable<string> lines)
        => lines.Select(line =>
        {
            var dimensions = line.Split(DimensionDelimiter);
            var length = int.Parse(dimensions[0]);
            var width = int.Parse(dimensions[1]);
            var height = int.Parse(dimensions[2]);

            return new Box(length, width, height);
        }).ToList().AsReadOnly();
}