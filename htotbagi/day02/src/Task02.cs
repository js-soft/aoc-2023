namespace Day02Src
{
    public class Bag
    {
        public int GetGameId(string input)
        {
            Match match = Regex.Match(input, @"\d+");

            if (match.Success)
            {
                if (int.TryParse(match.Value, out int result))
                {
                    return result;
                }
            }

            return -1;
        }

        public List<string> ReadFileToList(string filePath)
        {
            List<string> linesList = new List<string>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                linesList.AddRange(lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return linesList;
        }

        public string GetCubesString(string input)
        {
            return input.Substring(8);
        }

        public string GetCubesWithoutEmptySpaces(string input)
        {
            string cubeString = GetCubesString(input);
            return cubeString.Replace(" ", string.Empty);
        }

        public List<string> GetCubesStringSegments(string input)
        {
            List<string> result = new List<string>();

            string cubeWithoutEmptySapces = GetCubesWithoutEmptySpaces(input);

            string[] segmentArray = cubeWithoutEmptySapces.Split(';');

            for (int i = 0; i < segmentArray.Length; i++)
            {
                result.Add(segmentArray[i].Trim());
            }
            return result;
        }

        public string GetSegmentByIndex(string input, int i)
        {
            List<string> cubesStringSegments = GetCubesStringSegments(input);
            return cubesStringSegments[i];
        }

        public Dictionary<string, int> CreateDictionaryOutOfSegment(string input, int index)
        {
            Dictionary<string, int> resultDictionary = new Dictionary<string, int>()
            {
                {"red", 0 },
                {"green", 0 },
                {"blue", 0 }
            };

            string firstSegment = GetSegmentByIndex(input, index);

            string[] parts = firstSegment.Split(',');

            foreach (string part in parts)
            {
                string color = "";
                int value = 0;

                for (int i = 0; i < part.Length; i++)
                {
                    if (char.IsDigit(part[i]))
                    {
                        value = value * 10 + int.Parse(part[i].ToString());
                    }
                    else
                    {
                        color += part[i];
                    }
                }

                if (color == "red")
                {
                    resultDictionary["red"] = value;
                }
                else if (color == "green")
                {
                    resultDictionary["green"] = value;
                }
                else if (color == "blue")
                {
                    resultDictionary["blue"] = value;
                }
            }

            return resultDictionary;
        }

        public bool IsGameSegmentPossible(string input, int index, Dictionary<string, int> loadedBag)
        {
            Dictionary<string, int> createdDictionary = CreateDictionaryOutOfSegment(input, index);

            string[] colorsToCheck = { "red", "green", "blue" };

            foreach (string color in colorsToCheck)
            {
                if (createdDictionary.TryGetValue(color, out int createdDictionaryValue) && loadedBag.TryGetValue(color, out int loadedBagValue))
                {
                    if (createdDictionaryValue > loadedBagValue)
                        return false;
                }
            }

            return true;
        }

        public int IsGamePossible(string input, Dictionary<string, int> loadedBag)
        {
            List<string> cubesStringSegments = GetCubesStringSegments(input);

            for (int i = 0; i < cubesStringSegments.Count; i++)
            {
                if (!IsGameSegmentPossible(input, i, loadedBag))
                {
                    return 0;
                }
            }

            return GetGameId(input);
        }

        public List<int> GetMaximumValuePerColor(string input)
        {
            List<int> result = new List<int>();

            int red = 0;
            int green = 0;
            int blue = 0;

            List<string> stringSegments = GetCubesStringSegments(input);

            for (int i = 0; i < stringSegments.Count; i++)
            {
                Dictionary<string, int> storage = CreateDictionaryOutOfSegment(input, i);

                if (storage["red"] > red)
                {
                    red = storage["red"];
                }
                if (storage["green"] > green)
                {
                    green = storage["green"];
                }
                if (storage["blue"] > blue)
                {
                    blue = storage["blue"];
                }
            }

            result.Add(red);
            result.Add(green);
            result.Add(blue);

            return result;
        }

        public int CalculatePowerOfCubes(string input)
        {
            List<int> maximumColors = GetMaximumValuePerColor(input);
            int result = 1;

            for (int i = 0; i < maximumColors.Count; i++)
            {
                result *= maximumColors[i];
            }

            return result;
        }

        public int CalculateSumOfCubePowers(string filePath)
        {
            List<string> games = ReadFileToList(filePath);

            int result = 0;

            foreach (string lines in games)
            {
                result += CalculatePowerOfCubes(lines);
            }

            return result;
        }
    }
}