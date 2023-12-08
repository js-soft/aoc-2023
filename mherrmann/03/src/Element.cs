using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03;

public record Pos(int X, int Y)
{
    public override string ToString() => $"({X},{Y})";
}

public record Size(Pos Pos, int Width)
{
    public List<Pos> OccupiedPositions
    {
        get
        {
            List<Pos> ret = [];
            for (int i = 0; i < Width; i++) ret.Add(new(Pos.X + i, Pos.Y));
            return ret;
        }
    }

    public override string ToString() => $"({Pos.X},{Pos.Y},{Width})";
}

public enum ElementType: byte { Number, Symbol }

public class Element(Size size, ElementType type, int value = -1, bool isGear = false)
{
    public Element(Size size, int value) : this(size, ElementType.Number, value) {}
    public Element(Pos pos, bool isGear = false) : this(new(pos, 1), ElementType.Symbol, -1, isGear) {}

    public ElementType Type = type;
    public Size Size = size;
    public int Value = value;
    public bool IsGear = isGear;

    public override string ToString()
    {
        if (Type == ElementType.Symbol) return $"({Size.Pos.X},{Size.Pos.Y}{(IsGear ? ",g" : "")}";
        else return $"({Size.Pos.X},{Size.Pos.Y},{Size.Width}: {Value})";
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is Element)
        {
            Element other = (Element)obj;
            return Type == other.Type && Size == other.Size && Value == other.Value && IsGear == other.IsGear;
        }
        return base.Equals(obj);
    }
}
