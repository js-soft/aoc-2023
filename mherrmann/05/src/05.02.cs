/**
 * Day 05 - Puzzle 02
 * If You Give A Seed A Fertilizer
 * Mika Herrmann
 */

using Advent2023;
using Day05;

string[] lines = File.ReadAllLines(FSUtil.GetResource("input.txt"));

AlmanacV2 a = AlmanacParser.ParseDocumentV2([.. lines]);

long count = a.Seeds
    .Select(s => s.Count)
    .Sum();

Console.WriteLine($"Found {count} seeds");

long sum = a.FindLowestLocationFromSeeds();

Console.WriteLine($"\nThe result is {sum}");
