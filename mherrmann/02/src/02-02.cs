/**
 * Day 02 - Puzzle 02
 * Cube Conundrum
 * Mika Herrmann
 */

using Advent2023;
using Day02;

string[] lines = File.ReadAllLines(FSUtil.GetResource("input.txt"));

List<Game> games = GameParser.ParseDocument(lines);

int result = Game.GetMinimimDraws(games);

Console.WriteLine($"\nThe result is {result}");