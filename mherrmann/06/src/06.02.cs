/**
 * Day 06 - Puzzle 02
 * Wait For It
 * Mika Herrmann
 */

using Advent2023;
using Day06;

string[] lines = FSUtil.ReadResource("input.txt");

RaceManager manager = RaceParser.ParseDocumentV2(lines);

long sum = manager.GetRecordErrorMargin();

Console.WriteLine($"\nThe result is {sum}");
