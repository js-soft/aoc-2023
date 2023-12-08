namespace test.day03_gear_ratios
{
    public class Schematic
    {
        public List<string> ExtendSchematicWithDots(string filePath)
        {
            List<string> matrix = ReadFileToList(filePath);

            int rows = matrix.Count;
            int cols = matrix[0].Length;

            List<string> extendedMatrix = new List<string>(rows + 2);

            extendedMatrix.Add(new string('.', cols + 2));

            for (int i = 0; i < rows; i++)
            {
                extendedMatrix.Add("." + matrix[i] + ".");
            }

            extendedMatrix.Add(new string('.', cols + 2));

            return extendedMatrix;
        }

        public bool IsTheNumberFirst(List<string> extendedSchema, int i, int j)
        {
            if (extendedSchema[i - 1][j] == '.' &&
                extendedSchema[i - 1][j - 1] == '.' &&
                extendedSchema[i][j - 1] == '.' &&
                extendedSchema[i + 1][j - 1] == '.' &&
                extendedSchema[i + 1][j] == '.')
            {
                return true;
            }
            return false;
        }

        public bool IsTheNumberMiddle(List<string> extendedSchema, int i, int j)
        {
            if (extendedSchema[i - 1][j] == '.' && extendedSchema[i + 1][j] == '.')
            {
                return true;
            }
            return false;
        }

        public bool IsTheNumberLast(List<string> extendedSchema, int i, int j)
        {
            if (extendedSchema[i - 1][j] == '.' &&
                extendedSchema[i - 1][j + 1] == '.' &&
                extendedSchema[i][j + 1] == '.' &&
                extendedSchema[i + 1][j + 1] == '.' &&
                extendedSchema[i + 1][j] == '.')
            {
                return true;
            }
            return false;
        }

        public bool Dimension1(string filePath, int i, int j)
        {
            List<string> matrix = ExtendSchematicWithDots(filePath);

            if (IsTheNumberFirst(matrix, i, j) && IsTheNumberLast(matrix, i, j))
            {
                return true;
            }
            return false;
        }

        public bool Dimension2(string filePath, int i, int j)
        {
            List<string> matrix = ExtendSchematicWithDots(filePath);

            if (IsTheNumberFirst(matrix, i, j - 1) && IsTheNumberLast(matrix, i, j))
            {
                return true;
            }
            return false;
        }

        public bool Dimension3(string filePath, int i, int j)
        {
            List<string> matrix = ExtendSchematicWithDots(filePath);

            if (IsTheNumberFirst(matrix, i, j - 2) && IsTheNumberMiddle(matrix, i, j - 1) && IsTheNumberLast(matrix, i, j))
            {
                return true;
            }
            return false; ;
        }

        public int GetFinalResult(string filePath)
        {
            List<string> linesList = ExtendSchematicWithDots(filePath);

            int row = linesList.Count();
            int col = linesList[0].Length;
            int totalSum = 0;
            int counter = 0;

            for (int i = 1; i < row - 1; i++)
            {
                for (int j = 1; j < col - 1; j++)
                {
                    if (char.IsDigit(linesList[i][j]))
                    {
                        counter++;

                        if (!char.IsDigit(linesList[i][j + 1]))
                        {
                            if (counter == 1 && !Dimension1(filePath, i, j))
                            {
                                string combination = linesList[i][j].ToString();
                                totalSum += int.Parse(combination);
                            }

                            if (counter == 2 && !Dimension2(filePath, i, j))
                            {
                                string combination = ConvertToDoubleNumber(linesList, i, j);
                                totalSum += int.Parse(combination);
                            }

                            if (counter == 3 && !Dimension3(filePath, i, j))
                            {
                                string combination = ConvertToTripleNumber(linesList, i, j);
                                totalSum += int.Parse(combination);
                            }
                            counter = 0;
                        }
                    }
                }
            }
            return totalSum;
        }

        private static string ConvertToDoubleNumber(List<string> linesList, int i, int j)
        {
            string lastChar = linesList[i][j].ToString();
            string secondLastChar = linesList[i][j - 1].ToString();

            string combination = secondLastChar + lastChar;
            return combination;
        }

        private static string ConvertToTripleNumber(List<string> linesList, int i, int j)
        {
            string lastChar = linesList[i][j].ToString();
            string secondLastChar = linesList[i][j - 1].ToString();
            string thirdLastChar = linesList[i][j - 2].ToString();

            string combination = thirdLastChar + secondLastChar + lastChar;
            return combination;
        }

        public List<string> ReadFileToList(string filePath)
        {
            List<string> linesList = new List<string>();

            string[] lines = File.ReadAllLines(filePath);
            linesList.AddRange(lines);

            return linesList;
        }
    }
}