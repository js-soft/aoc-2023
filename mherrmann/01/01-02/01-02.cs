/**
 * Day 01 - Puzzle 02
 * Trebuchet?!
 * Mika Herrmann
 */

var lines = File.ReadAllLines("input.txt");

int sum = DigitParserV2.parseDocument(lines, true);

Console.WriteLine($"\nThe result is {sum}");