namespace Advent2021
{
    internal class Day2
    {
        public async Task PuzzleOne()
        {
            int horizontal = 0, vertical = 0;
            var inputs = await File.ReadAllLinesAsync("Input/Day2.txt");

            foreach(var input in inputs)
            {
                if (input.StartsWith("forward"))
                    horizontal += int.Parse(input.Replace("forward ", ""));
                if (input.StartsWith("down"))
                    vertical += int.Parse(input.Replace("down ", ""));
                if (input.StartsWith("up"))
                    vertical -= int.Parse(input.Replace("up ", ""));
            }

            Console.WriteLine($"Horizontal: {horizontal}, Vertical: {vertical}, Combined: {horizontal * vertical}\n");
        }

        public async Task PuzzleTwo()
        {
            int horizontal = 0, depth = 0, aim = 0;
            var inputs = await File.ReadAllLinesAsync("Input/Day2.txt");

            foreach (var input in inputs)
            {
                if (input.StartsWith("forward"))
                {
                    var x = int.Parse(input.Replace("forward ", ""));
                    horizontal += x;
                    depth += x * aim;
                }
                if (input.StartsWith("down"))
                    aim += int.Parse(input.Replace("down ", ""));
                if (input.StartsWith("up"))
                    aim -= int.Parse(input.Replace("up ", ""));
            }

            Console.WriteLine($"Horizontal: {horizontal}, Depth: {depth}, Combined: {horizontal * depth}\n");
        }
    }
}
