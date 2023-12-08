/**
 * Day 05 - Puzzle 01
 * If You Give A Seed A Fertilizer
 * Mika Herrmann
 */

using Advent2023;
using Day05;

string[] lines = File.ReadAllLines(FSUtil.GetResource("input.txt"));

AlmanacV1 a = AlmanacParser.ParseDocumentV1([.. lines]);

Console.WriteLine(a);

long sum = a.FindLowestLocationFromSeeds();

Console.WriteLine($"\nThe result is {sum}");