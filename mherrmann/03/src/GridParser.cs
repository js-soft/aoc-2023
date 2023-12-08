namespace Day03;

public static class GridParser
{

    public static List<Element> ParseLine(string line, int y, bool printLine = false)
    {
        List<Element> ret = [];
        List<char> temp = [];
        int startX = 0;
        bool isDecodingNumber = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (char.IsDigit(c))
            {
                if (!isDecodingNumber)
                {
                    isDecodingNumber = true;
                    startX = i;
                }
                temp.Add(c);
            } else
            {
                if (isDecodingNumber)
                {
                    isDecodingNumber = false;
                    int number = int.Parse(temp
                        .Select(x => x.ToString())
                        .Aggregate(string.Concat)
                        );

                    ret.Add(new Element(new Size(new Pos(startX, y), temp.Count), number));
                    temp.Clear();
                }

                if (c == '.' || c == '\n') continue;
                else ret.Add(new Element(new Pos(i, y), c == '*'));
            }
        }

        if (isDecodingNumber)
        {
            isDecodingNumber = false;
            int number = int.Parse(temp
                .Select(x => x.ToString())
                .Aggregate(string.Concat)
                );

            ret.Add(new Element(new Size(new Pos(startX, y), temp.Count), number));
            temp.Clear();
        }

        if (printLine)
        {
            Console.WriteLine(line);
            Console.Write($"\t-> ");
            foreach (Element e in ret) Console.Write($"{e} ");
            Console.WriteLine();
        }

        return ret;
    }

    public static Grid ParseDocument(ICollection<string> lines, bool printLines = false)
    {
        List<Element> elements = [];
        int y = 0;

        foreach (string line in lines)
        {
            elements.AddRange(ParseLine(line, y, printLines));
            y++;
        }

        return new Grid(elements);
    }
}
