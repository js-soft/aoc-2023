/**
 * Day 09 - Puzzle 01
 * Mirage Maintenance
 * Mika Herrmann
 */

using Advent2023;
using Day09;

string[] lines = FSUtil.ReadResource("input.txt");

SensorData data = SequenceParser.ParseDocument(lines);

long sum = data.CalculateForwardExtrapolatedSum();

Console.WriteLine($"The result is {sum}");
