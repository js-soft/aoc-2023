using System.Text;

namespace Day02;

public record DrawBalls(int Red, int Green, int Blue)
{
    public int Power
    {
        get => Red * Green * Blue;
    }
}

public class Game(int id, List<DrawBalls> draws)
{
    public int Id = id;
    public List<DrawBalls> Draws = draws;
    public DrawBalls MinimumNumberOfBalls
    {
        get
        {
            int red = int.MinValue;
            int green = int.MinValue;
            int blue = int.MinValue;

            foreach (DrawBalls draw in Draws)
            {
                if (draw.Red > red) red = draw.Red;
                if (draw.Green > green) green = draw.Green;
                if (draw.Blue > blue) blue = draw.Blue;
            }

            return new(red, green, blue);
        }
    }

    public bool IsPossible(int red, int green, int blue)
    {
        foreach (DrawBalls draw in Draws)
        {
            if (
                draw.Red > red || 
                draw.Green > green ||
                draw.Blue > blue
            ) return false;
        }

        return true;
    }

    public override string ToString()
    {
        StringBuilder builder = new($"{Id}: ");
        foreach (DrawBalls draw in Draws) builder.Append($"({draw.Red},{draw.Green},{draw.Blue}) ");
        return builder.ToString().TrimEnd();
    }

    public static int GetPossibleGames(List<Game> games, int red, int green, int blue) => games
        .Where(game => game.IsPossible(red, green, blue))
        .Select(game => game.Id)
        .Aggregate((a, b) => a + b);

    public static int GetMinimimDraws(List<Game> games) => games
        .Select(game => game.MinimumNumberOfBalls.Power)
        .Aggregate((a, b) => a + b);
}