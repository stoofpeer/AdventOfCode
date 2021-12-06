using System.Collections;

namespace Advent2021
{
    internal class Day6
    {
        public async Task PuzzleOne()
        {
            var fishInput = (await File.ReadAllTextAsync("Input/Day6.txt")).Split(',').Select(int.Parse).ToList();
            for (var day = 1; day <= 80; day++)
            {
                var fishEOL = fishInput.Count(x => x == 0);
                fishInput = fishInput.Select(x => x - 1).ToList();
                if (fishEOL > 0)
                {
                    fishInput.AddRange(Enumerable.Range(0, fishEOL).Select(x => 8));
                    fishInput.AddRange(Enumerable.Range(0, fishEOL).Select(x => 6));
                    fishInput.RemoveAll(x => x < 0);
                }

                Console.WriteLine($"After day {day}, there are {fishInput.Count}");
            }
        }

        public async Task PuzzleTwo()
        {
            var fishInput = (await File.ReadAllTextAsync("Input/Day6.txt")).Split(',').Select(int.Parse).ToList();

            var timerInterval = new long[9];
            foreach (var fish in fishInput)
                timerInterval[fish]++;

            for (var day = 1; day <= 256; day++)
            {
                var eolFish = timerInterval[0];
                timerInterval[0] = 0;
                timerInterval = Enumerable.Range(0, 9).Select(x => x != 8 ? timerInterval[x + 1] : eolFish).ToArray();
                timerInterval[6] += eolFish;

                Console.WriteLine($"After day {day}, there are {timerInterval.Sum()}");
            }
        }
    }
}