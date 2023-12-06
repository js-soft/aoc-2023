namespace Day06Src
{
    public class Race
    {
        public List<ulong> GetTimes(string filePath)
        {
            string startsWith = "Time:";
            List<ulong> timeValues = ExtractTimeValues(filePath, startsWith);
            return timeValues;
        }

        public List<ulong> GetDistances(string filePath)
        {
            string startsWith = "Distance:";
            List<ulong> timeValues = ExtractTimeValues(filePath, startsWith);
            return timeValues;
        }

        public List<ulong> ExtractTimeValues(string filePath, string startsWith)
        {
            List<ulong> timeValues = new List<ulong>();

            string[] lines = File.ReadAllLines(filePath);

            string timeLine = lines.FirstOrDefault(line => line.StartsWith(startsWith));

            if (timeLine != null)
            {
                string[] words = timeLine.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < words.Length; i++)
                {
                    if (ulong.TryParse(words[i], out ulong timeValue))
                    {
                        timeValues.Add(timeValue);
                    }

                }
            }

            return timeValues;
        }

        public ulong CalculateDifferentWaysForSpecificRace(string filePath, int raceNumber)
        {
            List<ulong> times = GetTimes(filePath);
            List<ulong> distances = GetDistances(filePath);

            List<ulong> result = new List<ulong>();

            ulong firstTime = times[raceNumber];
            ulong counter = times[raceNumber];
            ulong firstDistance = distances[raceNumber];

            for (ulong i = 0; i < firstTime; i++)
            {
                if (i * counter > firstDistance)
                {
                    result.Add(i * counter);
                }
                counter -= 1;
            }

            return (ulong)result.Count();
        }

        public ulong GetMarginError(string filePath)
        {
            List<ulong> times = GetTimes(filePath);

            ulong result = 1;

            for (ulong i = 0; i < (ulong)times.Count; i++)
            {
                result *= CalculateDifferentWaysForSpecificRace(filePath, (int)i);
            }

            return result;
        }
    }
}