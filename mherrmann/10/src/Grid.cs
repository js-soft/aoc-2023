using System.Text;

namespace Day10;

public enum Orientation : byte { NorthSouth, EastWest, NorthWest, NorthEast, SouthWest, SouthEast, Start }

public record Pos(int X, int Y);

public struct Pipe(Pos id, Orientation type, Pos from, Pos to)
{
    public Pos Id = id;
    public Orientation Type = type;
    public Pos From = from;
    public Pos To = to;
    public long Steps = 0;
    public bool IsPartOfLoop = false;

    public readonly bool IsValid
    {
        get => Id.X >= 0 && Id.Y >= 0;
    }

    public Pipe() : this(new Pos(-1, -1), Orientation.NorthSouth, new Pos(-1, -1), new Pos(-1, -1)) { }

    public readonly Pos GetOtherPosition(Pos pos) => pos == From ? To : From;
}

public class Grid
{
    private static readonly Dictionary<Orientation, char> orientationFormatter = new()
    {
        { Orientation.Start, 'S' },
        { Orientation.EastWest, '─' },
        { Orientation.NorthSouth, '│' },
        { Orientation.SouthEast, '┌' },
        { Orientation.SouthWest, '┐' },
        { Orientation.NorthEast, '└' },
        { Orientation.NorthWest, '┘' }
    };

    private Pipe[,] Pipes;
    private Pipe StartPoint;
    private int Width;
    private int Height;

    public Grid(List<Pipe> pipes)
    {
        Width = pipes
            .Select(p => p.Id.X)
            .Max() + 1;

        Height = pipes
            .Select(p => p.Id.Y)
            .Max() + 1;

        Pipes = new Pipe[Height, Width];
        Pos startPos = new(0, 0);

        foreach (Pipe p in pipes)
        {
            Pipes.Access(p.Id) = p;
            if (p.Type == Orientation.Start)
            {
                StartPoint = p;
                StartPoint.IsPartOfLoop = true;
                startPos = p.Id;
            }
        }

        List<Pos> queries = [new(startPos.X, startPos.Y - 1), new(startPos.X + 1, startPos.Y), new(startPos.X, startPos.Y + 1), new(startPos.X- 1, startPos.Y)]; //Above, Right, Below, Left
        bool hasFrom = false;

        foreach (Pos pos in queries)
        {
            if (pos.X >= 0 && pos.X < Width && pos.Y >= 0 && pos.Y < Height)
            {
                Pipe p = Pipes.Access(pos);
                if (p.IsValid && (p.From == startPos || p.To == startPos))
                {
                    if (!hasFrom)
                    {
                        hasFrom = true;
                        StartPoint.From = pos;
                    }
                    else
                    {
                        StartPoint.To = pos;
                        break;
                    }
                }
            }
        }

        Pipes.Access(startPos) = StartPoint;
    }

    public long CalculateFurthestSteps()
    {
        void saveEntry(Pipe p) => Pipes.Access(p.Id) = p;

        Pipe left = Pipes.Access(StartPoint.From);
        Pipe right = Pipes.Access(StartPoint.To);
        Pos lastLeft = StartPoint.Id;
        Pos lastRight = StartPoint.Id;
        long stepsLeft = 1;
        long stepsRight = 1;
        Pos tempId;

        left.Steps = stepsLeft;
        left.IsPartOfLoop = true;
        saveEntry(left);

        right.Steps = stepsRight;
        right.IsPartOfLoop = true;
        saveEntry(right);

        while (true)
        {
            stepsLeft++;
            stepsRight++;

            //Update positions
            tempId = left.Id;
            left = Pipes.Access(left.GetOtherPosition(lastLeft));
            left.IsPartOfLoop = true;
            lastLeft = tempId;

            //Check left
            if (left.Steps == 0)
            {
                left.Steps = stepsLeft;
                saveEntry(left);
            }
            else if (left.Steps < stepsLeft) return left.Steps;
            else if (left.Steps == stepsLeft) return stepsLeft;

            tempId = right.Id;
            right = Pipes.Access(right.GetOtherPosition(lastRight));
            right.IsPartOfLoop = true;
            lastRight = tempId;

            //Check right
            if (right.Steps == 0)
            {
                right.Steps = stepsRight;
                saveEntry(right);
            }
            else if (right.Steps < stepsRight) return right.Steps;
            else if (right.Steps == stepsRight) return stepsRight;
        }
    }

    public override string ToString() => CreateGridString(false);

    public string ToLoopString() => CreateGridString(true);

    private string CreateGridString(bool checkLoop)
    {
        StringBuilder builder = new();

        for (int y = 0; y < Pipes.GetLength(0); y++)
        {
            for (int x = 0; x < Pipes.GetLength(1); x++)
            {
                if (checkLoop && !Pipes[y, x].IsPartOfLoop) builder.Append('.');
                else builder.Append(orientationFormatter.GetValueOrDefault(Pipes[y, x].Type, '.'));
            }
            builder.AppendLine();
        }

        return builder.ToString();
    }
}
