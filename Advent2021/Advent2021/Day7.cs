using System.Collections;

namespace Advent2021
{
    internal class Day7
    {
        public async Task PuzzleOne()
        {
            var crabInput = (await File.ReadAllTextAsync("Input/Day7.txt")).Split(',').Select(int.Parse).ToList();
            var median = crabInput.OrderBy(x => x).ElementAt(crabInput.Count / 2);

            var fuelUsed = crabInput.Sum(x => Math.Max(median, x) - Math.Min(median, x));
            Console.WriteLine($"Fuel used: {fuelUsed} \n");
        }

        public async Task PuzzleTwo()
        {
            var crabInput = (await File.ReadAllTextAsync("Input/Day7.txt")).Split(',').Select(int.Parse).OrderBy(x => x).ToList();

            var minimumFuelValue = int.MaxValue;
            for (var i = crabInput[0]; i < crabInput[^1] + 1; i++)
            {
                //var fuelForAllSteps = crabInput.SelectMany(x => Enumerable.Range(1, Math.Abs(x - i))).Sum(); //Slow
                var fuelForAllSteps = crabInput.Select(x => Math.Abs(x - i) * (Math.Abs(x - i) + 1) / 2).Sum(); //1+2+3+4... formula
                if (fuelForAllSteps < minimumFuelValue)
                    minimumFuelValue = fuelForAllSteps;
                else
                    break;
            }

            Console.WriteLine($"Fuel used: {minimumFuelValue}");
        }
    }
}