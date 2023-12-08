/**
 * Day 06 - Puzzle 01
 * Wait For It
 * Mika Herrmann
 */

using Advent2023;
using Day06;

string[] lines = FSUtil.ReadResource("input.txt");

RaceManager manager = RaceParser.ParseDocument(lines);

long sum = manager.GetRecordErrorMargin();

Console.WriteLine($"\nThe result is {sum}");