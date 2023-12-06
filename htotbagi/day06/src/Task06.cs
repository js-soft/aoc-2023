namespace Day06Src
{
    public class Race
    {
        public List<int> GetTimes(string filePath)
        {
            string startsWith = "Time:";
            List<int> timeValues = ExtractTimeValues(filePath, startsWith);
            return timeValues;
        }

        public List<int> GetDistances(string filePath)
        {
            string startsWith = "Distance:";
            List<int> timeValues = ExtractTimeValues(filePath, startsWith);
            return timeValues;
        }

        public List<int> ExtractTimeValues(string filePath, string startsWith)
        {
            List<int> timeValues = new List<int>();

            string[] lines = File.ReadAllLines(filePath);

            string timeLine = lines.FirstOrDefault(line => line.StartsWith(startsWith));

            if (timeLine != null)
            {
                string[] words = timeLine.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < words.Length; i++)
                {
                    if (int.TryParse(words[i], out int timeValue))
                    {
                        timeValues.Add(timeValue);
                    }

                }
            }

            return timeValues;
        }

        public int CalculateDifferentWaysForSpecificRace(string filePath, int raceNumber)
        {
            List<int> times = GetTimes(filePath);
            List<int> distances = GetDistances(filePath);

            List<int> result = new List<int>();

            int firstTime = times[raceNumber];
            int counter = times[raceNumber];
            int firstDistance = distances[raceNumber];

            for (int i = 0; i < firstTime; i++)
            {
                if (i * counter > firstDistance)
                {
                    result.Add(i * counter);
                }
                counter -= 1;
            }

            return result.Count();
        }

        public int GetMarginError(string filePath)
        {
            List<int> times = GetTimes(filePath);

            int result = 1;

            for (int i = 0; i < times.Count; i++)
            {
                result *= CalculateDifferentWaysForSpecificRace(filePath, i);
            }

            return result;
        }
    }
}