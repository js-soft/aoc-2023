/**
 * Day 08 - Puzzle 01
 * Haunted Wasteland
 * Mika Herrmann
 */

using Advent2023;
using Day08;

string[] lines = FSUtil.ReadResource("input.txt");

Map map = MapParser.ParseDocument([.. lines]);

long steps = map.CalculateSteps();

Console.WriteLine($"\nThe result is {steps}");
