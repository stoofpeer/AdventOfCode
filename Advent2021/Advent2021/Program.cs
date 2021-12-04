// See https://aka.ms/new-console-template for more information
using Advent2021;

Console.WriteLine("Hi Advent of code 2021\n");

var day1 = new Day1();
await day1.PuzzleOne();
await day1.PuzzleTwo();

var day2 = new Day2();
await day2.PuzzleOne();
await day2.PuzzleTwo();

var day3 = new Day3();
await day3.PuzzleOne();
await day3.PuzzleTwo();

var day4 = new Day4();
await day4.PuzzleOne();
await day4.PuzzleTwo();

Console.ReadLine();