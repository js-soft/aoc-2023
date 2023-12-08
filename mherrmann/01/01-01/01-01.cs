/**
 * Day 01 - Puzzle 01
 * Trebuchet?!
 * Mika Herrmann
 */

var lines = File.ReadAllLines("input.txt");

int sum = DigitParser.parseDocument(lines, true);

Console.WriteLine($"\nThe result is {sum}");