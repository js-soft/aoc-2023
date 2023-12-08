namespace Day03;

public class Grid()
{

    private Dictionary<Pos, Element> elements = [];
    private List<Element> numbers = [];
    private List<Element> gears = [];

    public List<Pos> OccupiedPositions
    {
        get => elements.Keys.ToList();
    }

    public Grid(List<Element> elements) : this() => AddElements(elements);

    public void AddElement(Element element)
    {
        foreach (Pos p in element.Size.OccupiedPositions)
        {
            elements.Add(p, element);
        }
        
        if (element.Type == ElementType.Number) numbers.Add(element);
        else if (element.Type == ElementType.Symbol && element.IsGear) gears.Add(element);
    }

    public void AddElements(List<Element> e) => e.ForEach(AddElement);

    public List<Pos> GetAdjacentPositions(Element element)
    {
        List<Pos> ret = [];
        List<Pos> elPos = element.Size.OccupiedPositions;

        for (int y = element.Size.Pos.Y - 1; y <= element.Size.Pos.Y + 1; y++)
        {
            for (int x = element.Size.Pos.X - 1; x <= element.Size.Pos.X + element.Size.Width; x++)
            {
                Pos p = new(x, y);
                if (!elPos.Contains(p)) ret.Add(p);
            }
        }

        return ret;
    }

    public List<Element> GetAdjacentElements(Element element, ElementType filterType) => GetAdjacentPositions(element)
        .Where(p => elements.ContainsKey(p) && elements[p].Type == filterType)
        .Select(p => elements[p])
        .Distinct()
        .ToList();

    public bool IsAdjacentToSymbol(Element element) => GetAdjacentPositions(element)
        .Where(p => elements.ContainsKey(p) && elements[p].Type == ElementType.Symbol)
        .Any();

    public bool IsValidGear(Element element)
    {
        if (element.Type != ElementType.Symbol || !element.IsGear) return false;

        return GetAdjacentElements(element, ElementType.Number).Count == 2;
    }

    public int GetGearValue(Element element)
    {
        if (!IsValidGear(element)) return -1;

        return GetAdjacentElements(element, ElementType.Number)
        .Select(p => p.Value)
        .Aggregate((a, b) => a * b);
    }

    public int CalculateEngineParts() => numbers
        .Where(IsAdjacentToSymbol)
        .Select(el => el.Value)
        .Aggregate((a, b) => a + b);

    public int CalculateGearValues() => gears
        .Where(IsValidGear)
        .Select(GetGearValue)
        .Aggregate((a, b) => a + b);
}
