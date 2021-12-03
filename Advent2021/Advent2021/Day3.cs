using System.Collections;

namespace Advent2021
{
    internal class Day3
    {
        public async Task PuzzleOne()
        {
            int gammaRate = 0, epsilonRate = 0;
            var inputs = await File.ReadAllLinesAsync("Input/Day3.txt");

            Dictionary<int, int> counter = new Dictionary<int, int>();
            foreach (var input in inputs)
            {
                for (var i = 0; i < input.Length; i++)
                {
                    if (!counter.ContainsKey(i))
                        counter[i] = 0;

                    counter[i] += int.Parse(input[i].ToString());
                }
            }

            var bits = new bool[counter.Keys.Count];
            for (var i = 0; i < counter.Values.Count; i++)
            {
                bits[i] = counter[i] > (inputs.Length / 2);
            }

            var bitStr = string.Join("", bits.Select(x => x ? "1" : "0"));
            var bitStrInvert = string.Join("", bits.Select(x => !x ? "1" : "0"));

            gammaRate = Convert.ToInt32(bitStr, 2);
            epsilonRate = Convert.ToInt32(bitStrInvert, 2);

            Console.WriteLine($"Bit value: {string.Join("", bits.Select(x => x ? "1" : "0"))} with gammaRate: {gammaRate}");
            Console.WriteLine($"Bit value: {string.Join("", bits.Select(x => x ? "1" : "0"))} with numeric value: {epsilonRate}");
            Console.WriteLine($"Combined it is: {gammaRate * epsilonRate}\n");
        }

        public async Task PuzzleTwo()
        {
            int oxygen = 0, carbon = 0;
            var inputs = await File.ReadAllLinesAsync("Input/Day3.txt");

            Dictionary<int, int> counter = new Dictionary<int, int>();
            var oxInputs = GetMinimizedInputs(inputs, 0, x => x == '1', (x, y) => x>= y);
            var coInputs = GetMinimizedInputs(inputs, 0, x => x == '0', (x, y) => x <= y);

            Console.WriteLine($"Ox inputs: {oxInputs.Length} | Co inputs: {coInputs.Length}");
            oxygen = Convert.ToInt32(oxInputs[0], 2);
            carbon = Convert.ToInt32(coInputs[0], 2);

            Console.WriteLine($"Bit value: {oxInputs[0]} with gammaRate: {oxygen}");
            Console.WriteLine($"Bit value: {coInputs[0]} with numeric value: {carbon}");
            Console.WriteLine($"Combined it is: {oxygen * carbon}\n");
        }

        private string[] GetMinimizedInputs(string[] inputs, int position, Func<char, bool> eq, Func<int, int, bool> eq2)
        {
            if (position == 12 || inputs.Length == 1)
                return inputs;

            var mostlyEquals = inputs.Where(x => eq(x[position])).ToArray();
            if (eq2(mostlyEquals.Length, inputs.Length / 2))
                return GetMinimizedInputs(mostlyEquals, position + 1, eq, eq2);

            return GetMinimizedInputs(inputs.Where(x => !eq(x[position])).ToArray(), position + 1, eq, eq2);
        }
    }
}
