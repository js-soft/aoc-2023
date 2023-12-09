namespace src.day09
{
    public class Sensor
    {
        public List<int> GetNextRowCalculation(List<int> stringRow)
        {
            return stringRow.Zip(stringRow.Skip(1), (current, next) => next - current).ToList();
        }

        public List<List<int>> GetAllDifferencesForThatRow(List<int> row)
        {
            List<List<int>> storage = new List<List<int>> { row };

            while (true)
            {
                List<int> nextRow = GetNextRowCalculation(storage[^1]);
                storage.Add(nextRow);

                if (nextRow.All(value => value == 0))
                {
                    break;
                }
            }

            return storage;
        }

        public int AddStepsToAsALastElement(List<List<int>> input)
        {
            input[^1].Add(0);

            for (int i = input.Count - 1; i >= 1; i--)
            {
                int lastElement = input[i].Last();
                input[i - 1].Add(input[i - 1].Last() + lastElement);
            }

            return input[0][^1];
        }

        public int ReverseHistory(List<List<int>> input)
        {
            input[^1].Add(0);

            for (int i = input.Count - 1; i >= 1; i--)
            {
                int lastElement = input[i].Last();
                input[i - 1].Add(input[i - 1].First() - lastElement);
            }

            return input[0][^1];
        }


        public int CalcFinal(string filePath)
        {
            List<List<int>> data = newExtractor(filePath);

            int result = 0;

            foreach (List<int> row in data)
            {
                result += AddStepsToAsALastElement(GetAllDifferencesForThatRow(row));
            }

            return result;
        }

        public int CalcFinalBackwards(string filePath)
        {
            List<List<int>> data = newExtractor(filePath);

            int result = 0;

            foreach (List<int> row in data)
            {
                result += ReverseHistory(GetAllDifferencesForThatRow(row));
            }

            return result;
        }


        public List<List<int>> newExtractor(string filePath)
        {
            List<List<int>> result = ReadFile(filePath);

            return result;
        }

        static List<List<int>> ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath)
                       .Select(line => line.Split(' ')
                                            .Select(value => int.TryParse(value, out int intValue) ? intValue : 0)
                                            .ToList())
                       .ToList();
        }

    }
}