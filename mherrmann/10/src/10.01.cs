/**
 * Day 10 - Puzzle 01
 * Pipe Maze
 * Mika Herrmann
 */

using Advent2023;
using Day10;

string[] lines = FSUtil.ReadResource("input.txt");

Grid grid = GridParser.ParseDocument(lines);

Console.WriteLine(grid.ToString());

long sum = grid.CalculateFurthestSteps();

Console.WriteLine(grid.ToLoopString());

Console.WriteLine($"The result is {sum}");