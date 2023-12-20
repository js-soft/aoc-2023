using System.Text;

namespace Day10;

public static class GridUtil
{

    public static ref Pipe Access(this Pipe[,] arr, Pos pos) {
        return ref arr[pos.Y, pos.X];
    }
}
