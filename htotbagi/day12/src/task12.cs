namespace src.day12_hot_springs
{
    public class HotSpring
    {
        public (List<string>, List<List<int>>) ReadFile(string filePath)
        {
            var stringsList = new List<string>();
            var intsList = new List<List<int>>();

            foreach (var line in File.ReadLines(Path.Combine(filePath)))
            {
                var parts = line.Split(' ');
                stringsList.Add(parts[0]);
                intsList.Add(parts[1].Split(',').Select(int.Parse).ToList());
            }
            return (stringsList, intsList);
        }

        public List<string> SelectStringsWithMatching(string inputString, List<int> numbers)
        {
            var result = new List<string>();

            List<string> input = GenerateHotSpringConfigurations(inputString.Length);

            int count = numbers.Sum();

            foreach (string s in input)
            {
                if (CountDamagedSprings(s, '#') == count)
                {
                    result.Add(s);
                }
            }
            return FindMatchingConfigurations(inputString, result);
        }

        static List<string> GenerateHotSpringConfigurations(int n)
        {
            List<string> result = new List<string>();
            char[] combination = new char[n];
            GenerateConfigurationHelper(combination, 0, result);
            return result;
        }

        static void GenerateConfigurationHelper(char[] combination, int index, List<string> result)
        {
            if (index == combination.Length)
            {
                result.Add(new string(combination));
                return;
            }

            combination[index] = '.';
            GenerateConfigurationHelper(combination, index + 1, result);

            combination[index] = '#';
            GenerateConfigurationHelper(combination, index + 1, result);
        }

        static int CountDamagedSprings(string input, char target)
        {
            return input.Count(c => c == target);
        }

        static List<string> FindMatchingConfigurations(string pattern, List<string> stringsToCheck)
        {
            return stringsToCheck.Where(str => IsMatchingPattern(pattern, str)).ToList();
        }

        static bool IsMatchingPattern(string pattern, string str)
        {
            if (pattern.Length != str.Length)
            {
                return false;
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] != '?' && pattern[i] != str[i])
                {
                    return false;
                }
            }
            return true;
        }

        static List<string> FindValidConfigurations(List<string> strings, int[] condition)
        {
            List<string> result = new List<string>();
            foreach (string dobar in strings)
            {
                if (IsValidConfiguration(dobar, condition))
                {
                    result.Add(dobar);
                }
            }
            return result;
        }

        private static bool IsValidConfiguration(string dobar, int[] condition)
        {
            List<int> lista = new List<int>();
            int counter = 0;

            foreach (char c in dobar)
            {
                if (c == '#')
                {
                    counter++;
                }
                else if (counter != 0)
                {
                    lista.Add(counter);
                    counter = 0;
                }
            }

            if (counter != 0)
                lista.Add(counter);

            return lista.SequenceEqual(condition);
        }

        public int CalculateFinalCombinations(string input, int[] numbers)
        {
            List<string> help = SelectStringsWithMatching(input, numbers.ToList());
            List<string> result = FindValidConfigurations(help, numbers);

            return result.Count;
        }

        public int GetFinalArrangementCount(string filePath)
        {
            int result = 0;
            (List<string> stringResult, List<List<int>> intResult) = ReadFile(filePath);

            for (int i = 0; i < stringResult.Count; i++)
            {
                result += CalculateFinalCombinations(stringResult[i], intResult[i].ToArray());
            }

            return result;
        }
    }
}