/**
 * Day 04 - Puzzle 01
 * Scratchcards
 * Mika Herrmann
 */

using Advent2023;
using Day04;

string[] lines = File.ReadAllLines(FSUtil.GetResource("input.txt"));

CardGame game = CardParser.ParseDocument(lines);

int sum = game.CalculateCardMatches();

Console.WriteLine($"\nThe result is {sum}");