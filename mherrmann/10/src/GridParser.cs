using System.IO.Pipes;

namespace Day10;

public static class GridParser
{

    public static List<Pipe> ParseLine(string line, int y)
    {
        int x = -1;
        Orientation o = Orientation.Start;
        Pos from = new(0,0);
        Pos to = new(-1, -1);
        List<Pipe> res = [];

        foreach (char c in line)
        {
            x++;

            switch (c)
            {
                case '.':
                    continue;

                case '|':
                    o = Orientation.NorthSouth;
                    from = new(x, y - 1);
                    to = new(x, y + 1);
                    break;

                case '-':
                    o = Orientation.EastWest;
                    from = new(x - 1, y);
                    to = new(x + 1, y);
                    break;

                case 'L':
                    o = Orientation.NorthEast;
                    from = new(x, y - 1);
                    to = new(x + 1, y);
                    break;

                case 'J':
                    o = Orientation.NorthWest;
                    from = new(x, y - 1);
                    to = new(x - 1, y);
                    break;

                case '7':
                    o = Orientation.SouthWest;
                    from = new(x, y + 1);
                    to = new(x - 1, y);
                    break;

                case 'F':
                    o = Orientation.SouthEast;
                    from = new(x, y + 1);
                    to = new(x + 1, y);
                    break;

                case 'S':
                    o = Orientation.Start;
                    from = new(-1, -1);
                    to = new(-1, -1);
                    break;
            }

            res.Add(new(new Pos(x, y), o, from, to));
        }

        return res;
    }

    public static Grid ParseDocument(ICollection<string> lines)
    {
        /*List<Pipe> pipes = [];
        int startX = -1;
        int startY = -1;

        for (int y = 0; y < lines.Count; y++)
        {
            pipes.AddRange(ParseLine(lines.ElementAt(y), y, out int tempX));
            if (tempX != -1)
            {
                if (startY == -1)
                {
                    startY = y;
                    startX = tempX;
                }
                else throw new ArgumentException("Only one start pipe is allowed");
            }
        }*/

        List<Pipe> pipes = lines
            .SelectMany(ParseLine)
            .ToList();

        return new(pipes);
    }
}
