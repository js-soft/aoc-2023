namespace Day04Src
{
    public class Scratchcard
    {
        public int[] GetWinningNumbers(string input)
        {
            int colonIndex = input.IndexOf(':');
            int pipeIndex = input.IndexOf('|');

            string numbersSubstring = input.Substring(colonIndex + 1, pipeIndex - colonIndex - 1).Trim();

            int[] numbersArray = numbersSubstring.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(int.Parse)
                                                  .ToArray();

            return numbersArray;
        }

        public int[] GetCurrentNumbers(string input)
        {
            int pipeIndex = input.IndexOf('|');

            string numbersSubstring = input.Substring(pipeIndex + 1, input.Length - pipeIndex - 1).Trim();

            int[] numbersArray = numbersSubstring.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(int.Parse)
                                                  .ToArray();

            return numbersArray;
        }

        public int CalculateNumberOfPoints(string input)
        {
            int[] winningNumbers = GetWinningNumbers(input);
            int[] currentNumbers = GetCurrentNumbers(input);
            int points = 0;

            for (int i = 0; i < winningNumbers.Length; i++)
            {
                for (int j = 0; j < currentNumbers.Length; j++)
                {
                    if (winningNumbers[i] == currentNumbers[j])
                    {
                        if (points == 0)
                        {
                            points += 1;
                        }
                        else
                        {
                            points *= 2;
                        }
                    }
                }
            }

            return points;
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

        public int CalculateTotalNumberOfPoints(List<string> scratchboards)
        {
            int totalNumberOfPoints = 0;
            foreach (string line in scratchboards)
            {
                totalNumberOfPoints += CalculateNumberOfPoints(line);
            }

            return totalNumberOfPoints;
        }

        public int CalculateMatchingNumber(string input)
        {
            int[] winningNumbers = GetWinningNumbers(input);
            int[] currentNumbers = GetCurrentNumbers(input);
            int points = 0;

            for (int i = 0; i < winningNumbers.Length; i++)
            {
                for (int j = 0; j < currentNumbers.Length; j++)
                {
                    if (winningNumbers[i] == currentNumbers[j])
                    {
                        points += 1;
                    }
                }
            }

            return points;
        }

        public List<int> AddCopiesOfScratchCard(List<string> scratchboards, List<int> initialCardCounter, int iteration)
        {
            int matchingNumber = CalculateMatchingNumber(scratchboards[iteration]);

            for (int i = iteration + 1; i < matchingNumber + 1 + iteration; i++)
            {
                initialCardCounter[i] += 1 * initialCardCounter[iteration];
            }

            return initialCardCounter;
        }

        public int CountAllScratchBoards(List<string> scratchboards, int totalCardNumber, ref List<int> initialCardCounter)
        {
            for (int i = 0; i < totalCardNumber; i++)
            {
                initialCardCounter = AddCopiesOfScratchCard(scratchboards, initialCardCounter, i);
            }

            int sum = initialCardCounter.Sum();
            return sum;
        }
    }
}