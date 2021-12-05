using System.Collections;

namespace Advent2021
{
    public record Direction(int X, int Y);
    internal class Day5
    {
        public async Task PuzzleOne()
        {
            var directions = (await File.ReadAllLinesAsync("Input/Day5.txt")).Select(x => 
            {
                var dirs = x.Split(" -> ");
                var from = dirs[0].Split(',').Select(int.Parse).ToArray();
                var to = dirs[1].Split(',').Select(int.Parse).ToArray();
                return new Tuple<Direction, Direction>(new Direction(from[0], from[1]), new Direction(to[0], to[1]));
            });
            
            var minX = Math.Min(directions.Min(x => x.Item1.X), directions.Min(x => x.Item2.X));
            var minY = Math.Min(directions.Min(x => x.Item1.Y), directions.Min(x => x.Item2.Y));
            var maxX = Math.Max(directions.Max(x => x.Item1.X), directions.Max(x => x.Item2.X));
            var maxY = Math.Max(directions.Max(x => x.Item1.Y), directions.Max(x => x.Item2.Y));

            var board = new int[maxX + 1, maxY + 1];
            foreach(var direction in directions)
            {
                if (direction.Item1.X == direction.Item2.X)
                {
                    var move = direction.Item1.Y > direction.Item2.Y ? -1 : 1;
                    var diff = Math.Max(direction.Item1.Y, direction.Item2.Y) - Math.Min(direction.Item1.Y, direction.Item2.Y);
                    
                    //Console.WriteLine($"Move {move} - Diff {diff} - Y {direction.Item1.Y}");
                    // Y moves
                    for (int i = 0; i <= diff; i++)
                        board[direction.Item1.X, direction.Item1.Y + (i * move)]++;
                }
                else if (direction.Item1.Y == direction.Item2.Y)
                {
                    var move = direction.Item1.X > direction.Item2.X ? -1 : 1;
                    var diff = Math.Max(direction.Item1.X, direction.Item2.X) - Math.Min(direction.Item1.X, direction.Item2.X);
                    
                    //Console.WriteLine($"Move {move} - Diff {diff} - Y {direction.Item1.X}");
                    // X moves
                    for (int i = 0; i <= diff; i++)
                        board[direction.Item1.X + (i * move), direction.Item1.Y]++;
                }
            }

            int overlappingPoints = 0;
            foreach (var field in board)
                if (field >= 2)
                    overlappingPoints++;

            Console.WriteLine($"Two lines overlap at {overlappingPoints} points");
        }

        public async Task PuzzleTwo()
        {
            var directions = (await File.ReadAllLinesAsync("Input/Day5.txt")).Select(x =>
            {
                var dirs = x.Split(" -> ");
                var from = dirs[0].Split(',').Select(int.Parse).ToArray();
                var to = dirs[1].Split(',').Select(int.Parse).ToArray();
                return new Tuple<Direction, Direction>(new Direction(from[0], from[1]), new Direction(to[0], to[1]));
            });

            var minX = Math.Min(directions.Min(x => x.Item1.X), directions.Min(x => x.Item2.X));
            var minY = Math.Min(directions.Min(x => x.Item1.Y), directions.Min(x => x.Item2.Y));
            var maxX = Math.Max(directions.Max(x => x.Item1.X), directions.Max(x => x.Item2.X));
            var maxY = Math.Max(directions.Max(x => x.Item1.Y), directions.Max(x => x.Item2.Y));

            var board = new int[maxX + 1, maxY + 1];
            foreach (var direction in directions)
            {
                if (direction.Item1.X == direction.Item2.X)
                {
                    var move = direction.Item1.Y > direction.Item2.Y ? -1 : 1;
                    var diff = Math.Max(direction.Item1.Y, direction.Item2.Y) - Math.Min(direction.Item1.Y, direction.Item2.Y);

                    //Console.WriteLine($"Move {move} - Diff {diff} - Y {direction.Item1.Y}");
                    // Y moves
                    for (int i = 0; i <= diff; i++)
                        board[direction.Item1.X, direction.Item1.Y + (i * move)]++;
                }
                else if (direction.Item1.Y == direction.Item2.Y)
                {
                    var move = direction.Item1.X > direction.Item2.X ? -1 : 1;
                    var diff = Math.Max(direction.Item1.X, direction.Item2.X) - Math.Min(direction.Item1.X, direction.Item2.X);

                    //Console.WriteLine($"Move {move} - Diff {diff} - Y {direction.Item1.X}");
                    // X moves
                    for (int i = 0; i <= diff; i++)
                        board[direction.Item1.X + (i * move), direction.Item1.Y]++;
                }
                else
                {
                    var diffX = Math.Max(direction.Item1.X, direction.Item2.X) - Math.Min(direction.Item1.X, direction.Item2.X);
                    var diffY = Math.Max(direction.Item1.Y, direction.Item2.Y) - Math.Min(direction.Item1.Y, direction.Item2.Y);

                    if (diffX == diffY)
                    {
                        var moveX = direction.Item1.X > direction.Item2.X ? -1 : 1;
                        var moveY = direction.Item1.Y > direction.Item2.Y ? -1 : 1;

                        for (int i = 0; i <= diffX; i++)
                            board[direction.Item1.X + (i * moveX), direction.Item1.Y + (i * moveY)]++;
                    }
                }
            }

            int overlappingPoints = 0;
            foreach (var field in board)
                if (field >= 2)
                    overlappingPoints++;

            Console.WriteLine($"Two lines overlap at {overlappingPoints} points");
        }

        private IEnumerable<Direction> GetDiagonalPoints(int x, int y, int maxX, int maxY)
        {
            for(var i = Math.Min(x, y); i >= 0; i--) //left top
                yield return new Direction(x-i, y-i);

            for (var i = Math.Min(x, y); i < 0; i++) //right top
                yield return new Direction(x - i, y - i);
        }
    }
}
