/**
 * Day 02 - Puzzle 01
 * Cube Conundrum
 * Mika Herrmann
 */

using Advent2023;
using Day02;

string[] lines = File.ReadAllLines(FSUtil.GetResource("input.txt"));

List<Game> games = GameParser.ParseDocument(lines, true);

int red = 12;
int green = 13;
int blue = 14;

int sum = Game.GetPossibleGames(games, red, green, blue);

Console.WriteLine($"\nThe result is {sum}");