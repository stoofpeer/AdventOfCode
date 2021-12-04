using System.Collections;

namespace Advent2021
{
    internal class Day4
    {
        public async Task PuzzleOne()
        {
            var inputs = (await File.ReadAllLinesAsync("Input/Day4.txt")).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var drawNumbers = inputs[0].Split(',').Select(int.Parse).ToList();
            var boards = new List<BoardPiece[][]>();

            for (var i = 1; i < (inputs.Length - 1) / 5; i++)
            {
                var temp = inputs.Skip(1).Skip((i - 1) * 5)
                        .Take(5);
                boards.Add(
                        temp
                        .Select(x => Enumerable.Range(0, 5).Select(j => x.Substring(j * 3, 2).Trim()).Select(x => new BoardPiece(int.Parse(x))).ToArray())
                        .ToArray()
                );
            }

            BoardPiece[][] winningBoard = null;
            var leastOptions = drawNumbers.Count;
            foreach (var board in boards)
            {
                for (var i = 0; i < drawNumbers.Count; i++)
                {
                    var number = drawNumbers[i];
                    for (var j = 0; j < board.Length; j++)
                        for (var k = 0; k < board[j].Length; k++)
                        {
                            if (board[j][k].Value == number)
                                board[j][k].Marked = true;
                        }

                    if (IsFinished(board) && i < leastOptions)
                    {
                        leastOptions = i;
                        winningBoard = board;
                        break;
                    }
                }

                //foreach (var row in board)
                //{
                //    int matchCount = 0, drawCount = 0;
                //    for (var i = 0; i < drawNumbers.Length; i++)
                //    {
                //        if (row.Contains(drawNumbers[i]))
                //            matchCount++;

                //        if (matchCount == 5)
                //            break;

                //        drawCount++;
                //    }

                //    if (drawCount < leastOptions)
                //    {
                //        leastOptions = drawCount;
                //        winningBoard = board;
                //    }
                //}

                //for (var j = 0; j < 5; j++)
                //{
                //    foreach (var vertical in board.Select(x => x[j]))
                //    {
                //        int matchCount = 0, drawCount = 0;
                //        for (var i = 0; i < drawNumbers.Length; i++)
                //        {
                //            if (vertical.Contains(drawNumbers[i]))
                //                matchCount++;

                //            if (matchCount == 5)
                //                break;

                //            drawCount++;
                //        }

                //        if (drawCount < leastOptions)
                //        {
                //            leastOptions = drawCount;
                //            winningBoard = board;
                //        }
                //    }
                //}
            }

            //var unmarkedOptions = winningBoard.SelectMany(x => x).ToList();
            //for (var i = 0; i <= leastOptions; i++)
            //{
            //    unmarkedOptions.Remove(drawNumbers[i]);
            //}
            int sum = winningBoard.SelectMany(x => x).Where(x => !x.Marked).Sum(x => x.Value), lastDrawnNumber = drawNumbers[leastOptions];
            Console.WriteLine($"Leftover sum: {sum} and winning number is {lastDrawnNumber} value is: {sum * lastDrawnNumber}");
        }

        private bool IsFinished(BoardPiece[][] board)
        {
            for (var i = 0; i < board.Length; i++)
                if (board[i].All(x => x.Marked))
                    return true;

            for (var i = 0; i < board[0].Length; i++)
                if (board.All(x => x[i].Marked))
                    return true;

            return false;
        }

        public async Task PuzzleTwo()
        {
            var inputs = (await File.ReadAllLinesAsync("Input/Day4.txt")).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var drawNumbers = inputs[0].Split(',').Select(int.Parse).ToList();
            var boards = new List<BoardPiece[][]>();

            for (var i = 1; i < (inputs.Length - 1) / 5; i++)
            {
                var temp = inputs.Skip(1).Skip((i - 1) * 5)
                        .Take(5);
                boards.Add(
                        temp
                        .Select(x => Enumerable.Range(0, 5).Select(j => x.Substring(j * 3, 2).Trim()).Select(x => new BoardPiece(int.Parse(x))).ToArray())
                        .ToArray()
                );
            }

            BoardPiece[][] winningBoard = null;
            var leastOptions = 0;
            foreach (var board in boards)
            {
                for (var i = 0; i < drawNumbers.Count; i++)
                {
                    var number = drawNumbers[i];
                    for (var j = 0; j < board.Length; j++)
                        for (var k = 0; k < board[j].Length; k++)
                        {
                            if (board[j][k].Value == number)
                                board[j][k].Marked = true;
                        }

                    if (IsFinished(board))
                    {
                        if (i > leastOptions)
                        {
                            leastOptions = i;
                            winningBoard = board;
                        }

                        break;
                    }
                }
            }

            int sum = winningBoard.SelectMany(x => x).Where(x => !x.Marked).Sum(x => x.Value), lastDrawnNumber = drawNumbers[leastOptions];
            Console.WriteLine($"Leftover sum: {sum} and winning number is {lastDrawnNumber} value is: {sum * lastDrawnNumber}");
        }
    }

    public class BoardPiece
    {
        public bool Marked { get; set; }
        public int Value { get; set; }

        public BoardPiece(int value)
        {
            this.Value = value;
        }
    }
}
