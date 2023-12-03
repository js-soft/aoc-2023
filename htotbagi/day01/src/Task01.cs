
namespace advent_of_code
{
    public class Calibration
    {
        public int DecypherSingleDocument(string userInput)
        {
            int firstNumber = 0;
            int lastNumber = 0;

            firstNumber = getFirstNumber(userInput);
            lastNumber = getLastNumber(userInput);

            return firstNumber * 10 + lastNumber;
        }

        private static int getFirstNumber(string userInput)
        {
            int userInputLength = userInput.Length;
            int firstNumber;
            int i = 0;
            while (i < userInputLength && !char.IsDigit(userInput[i]))
            {
                i++;
            }

            firstNumber = int.Parse(userInput[i].ToString());
            return firstNumber;
        }

        private static int getLastNumber(string userInput)
        {
            int lastNumber;
            int j = userInput.Length - 1;
            while (j >= 0 && !char.IsDigit(userInput[j]))
            {
                j--;
            }

            lastNumber = int.Parse(userInput[j].ToString());
            return lastNumber;
        }

        public int DecypherMultipleDocuments(List<string> documents)
        {
            int result = 0;

            foreach (string singleDocument in documents)
            {
                result += DecypherSingleDocument(singleDocument);
            }

            return result;
        }
    }
}