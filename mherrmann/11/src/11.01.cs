/**
 * Day 11 - Puzzle 01
 * Cosmic Expansion
 * Mika Herrmann
 */

using Advent2023;
using Day11;

string[] lines = FSUtil.ReadResource("input.txt");

Universe u = GalaxyParser.ParseDocument(lines);

long sum = u.CalculateShortestPaths();

Console.WriteLine($"The result is {sum}");
