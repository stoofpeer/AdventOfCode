namespace Advent2021
{
    internal class Day1
    {
        public async Task PuzzleOne()
        {
            var ups = 0;
            var input = (await File.ReadAllLinesAsync("Input/Day1_1.txt")).Select(int.Parse).ToList();

            Console.WriteLine($"Number of inputs = {input.Count}");
            for (var i = 1; i < input.Count; i++)
            {
                if (Increased(input[i - 1], input[i]))
                    ups++;
            }

            Console.WriteLine($"The amount of ups is {ups}\n");
        }

        public async Task PuzzleTwo()
        {
            var ups = 0;
            var input = (await File.ReadAllLinesAsync("Input/Day1_1.txt")).Select(int.Parse).ToList();

            Console.WriteLine($"Number of inputs = {input.Count}");
            for (var i = 3; i < input.Count; i++) //1,2,3 - 0,1,2 || 4,5,6 - 3,4,5
            {
                if (Increased(input[i - 3] + input[i - 2] + input[i - 1], input[i - 2] + input[i - 1] + input[i]))
                    ups++;
            }

            Console.WriteLine($"The amount of ups is {ups}\n");
        }

        private bool Increased(int v1, int v2)
        {
            Console.WriteLine($"Checking {v2} > {v1}: {v2 > v1}");
            return v2 > v1;
        }
    }
}
