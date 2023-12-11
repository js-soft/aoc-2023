/**
 * Day 07 - Puzzle 02
 * Camel Cards
 * Mika Herrmann
 */

using Advent2023;
using Day07;

string[] lines = FSUtil.ReadResource("input.txt");

Game game = CardParser.ParseDocument(lines, true);

int sum = game.GetTotalWinnings();


Console.WriteLine($"\nThe result is {sum}");
