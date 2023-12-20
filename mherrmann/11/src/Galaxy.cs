namespace Day11;

public record Galaxy(int X, int Y);

/// <summary>
/// Contains the path information for a straight line from (0, 0) to (x, y).
/// <br/>
/// x and y are always positive, as the path can be flipped horizontically and vertically.
/// </summary>
/// <param name="X">The x offset value</param>
/// <param name="Y">The y offset value</param>
public record BresenhamPath(int X, int Y)
{

    public static BresenhamPath FromGalaxies(Galaxy a, Galaxy b)
    {
        int x = Math.Abs(b.X - a.X);
        int y = Math.Abs(b.Y - a.Y);

        //Exploit symmetry by "rotating axes"
        if (y > x) return new(y, x);
        else return new(x, y);
    }
}

public class Universe(List<Galaxy> galaxies, int expansion, int width = -1, int height = -1)
{
    private List<Galaxy> Galaxies = GalaxyParser.TransformGalaxies(galaxies, expansion, width, height);

    private List<BresenhamPath> CreatePaths()
    {
        List<BresenhamPath> res = [];

        for (int i = 0; i < Galaxies.Count; i++)
            for (int j = i + 1; j < Galaxies.Count; j++)
                res.Add(BresenhamPath.FromGalaxies(Galaxies[i], Galaxies[j]));

        return res;
    }

    public long CalculateBresenham(BresenhamPath path)
    {
        //Test
        return path.X + path.Y;

        /*double m = (double) path.Y / path.X; //Gradient of linear function f(x) = mx

        int yInt = 0;
        double y;
        double yOffset = yInt + 0.5;
        int steps = 0;

        for (int x = 1; x <= path.X; x++)
        {
            steps++;
            y = m * x;
            if (y >= yOffset)
            {
                yInt++;
                steps++;
                yOffset = yInt + 0.5;
            }
        }

        return steps;*/
    }

    public long CalculateShortestPaths() => CreatePaths()
        .Select(CalculateBresenham)
        .Sum();
}
