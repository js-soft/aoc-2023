/**
 * Day 03 - Puzzle 01
 * Gear Ratios
 * Mika Herrmann
 */

using Advent2023;
using Day03;

string[] lines = File.ReadAllLines(FSUtil.GetResource("input.txt"));

Grid g = GridParser.ParseDocument(lines, true);

int sum = g.CalculateGearValues();

Console.WriteLine($"\nThe result is {sum}");