namespace Day11;

public static class GalaxyParser
{
    public static List<Galaxy> TransformGalaxies(List<Galaxy> galaxies, int expansion, int w = -1, int h = -1)
    {
        int width = Math.Max(w, galaxies.Select(g => g.X).Max() + 1);
        int height = Math.Max(h, galaxies.Select(g => g.Y).Max() + 1);
        List<int> emptyColumns = [];
        List<int> emptyRows = [];

        List<List<bool>> posRows = new(height); //Row first
        for (int y = 0; y < height; y++)
        {
            posRows.Add(new(width));
            for (int x = 0; x < width; x++)
                posRows[y].Add(false);
        }

        foreach (Galaxy g in galaxies) posRows[g.Y][g.X] = true;

        //Check Rows
        for (int y = 0; y < posRows.Count; y++)
        {
            if (posRows[y].All(a => a == false))
                emptyRows.Add(y);
        }

        //Transpose List
        List<List<bool>> posColumns = new(width);
        for (int x = 0; x < posRows[0].Count; x++)
        {
            posColumns.Add(new(posRows.Count));

            for (int y = 0; y < posRows.Count; y++) posColumns[x].Add(posRows[y][x]);
        }

        //Check columns
        for (int x = 0; x < posColumns.Count; x++)
        {
            if (posColumns[x].All(a => a == false))
                emptyColumns.Add(x);
        }

        //Create new list
        List<Galaxy> res = [];
        int newX;
        int newY;
        foreach (Galaxy g in galaxies)
        {
            newX = g.X;
            newY = g.Y;

            foreach (int emptyX in emptyColumns)
                if (g.X > emptyX)
                    newX += expansion;

            foreach (int emptyY in emptyRows)
                if (g.Y > emptyY)
                    newY += expansion;

            res.Add(new(newX, newY));
        }

        return res;
    }

    public static List<Galaxy> ParseLine(string line, int y)
    {
        List<Galaxy> res = [];

        for (int x = 0; x < line.Length; x++) 
            if (line[x] == '#')
                res.Add(new(x, y));

        return res;
    }

    public static Universe ParseDocument(ICollection<string> lines, int expansion = 1) => new(lines
        .SelectMany(ParseLine)
        .ToList(),
        expansion);
}
