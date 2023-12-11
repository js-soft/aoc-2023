namespace src.day11
{
    public class Universe
    {
        private List<List<char>> galaxy;

        public Universe()
        {
            galaxy = ReadFileToGrid("C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day11-cosmic-expansion\\data\\inputExample.txt");
        }

        public List<List<ulong>> GetCoordinates()
        {
            List<List<ulong>> coordinates = new List<List<ulong>>();

            for (int i = 0; i < galaxy.Count; i++)
            {
                for (int j = 0; j < galaxy[0].Count; j++)
                {
                    if (galaxy[i][j] == '#')
                    {
                        coordinates.Add(new List<ulong> { (ulong)i, (ulong)j });
                    }
                }
            }
            return coordinates;
        }

        public bool RowIsEmpty(ulong rowIndex)
        {
            int rowIndexInt = (int)rowIndex;
            return galaxy[rowIndexInt].All(cell => cell == '.');
        }

        public bool ColISEmpty(ulong colIndex)
        {
            int colIndexInt = (int)colIndex;
            return galaxy.All(row => row[colIndexInt] == '.');
        }

        public ulong GetDistanceBetweenGalaxies(List<ulong> firstPoint, List<ulong> secondPoint, ulong orderOfExpansion)
        {
            ulong x1 = firstPoint[0], y1 = firstPoint[1];
            ulong x2 = secondPoint[0], y2 = secondPoint[1];

            (x1, x2) = (Math.Min(x1, x2), Math.Max(x1, x2));
            (y1, y2) = (Math.Min(y1, y2), Math.Max(y1, y2));

            ulong result = 0;
            for (ulong i = x1; i < x2; i++)
            {
                result += 1;
                if (RowIsEmpty(i))
                {
                    result += orderOfExpansion - 1;
                }
            }
            for (ulong j = y1; j < y2; j++)
            {
                result += 1;
                if (ColISEmpty(j))
                {
                    result += orderOfExpansion - 1;
                }
            }
            return result;
        }

        public ulong GetTotalDistance(ulong orderOfExpansion)
        {
            ulong result = 0;

            List<List<ulong>> coordinates = GetCoordinates();

            for (int i = 0; i < coordinates.Count; i++)
            {
                for (int j = i + 1; j < coordinates.Count; j++)
                {
                    result = result + GetDistanceBetweenGalaxies(coordinates[i], coordinates[j], orderOfExpansion);
                }
            }
            return result;
        }

        public List<List<char>> ReadFileToGrid(string filePath)
        {
            List<List<char>> grid = new List<List<char>>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    List<char> row = new List<char>(line.ToCharArray());
                    grid.Add(row);
                }
            }
            return grid;
        }
    }
}