namespace src.day08_haunted_wasteland
{
    public class Network
    {
        public string GetDirections(string filePath)
        {
            string initialDirection = File.ReadLines(filePath).First();
            return initialDirection;
        }

        public List<List<string>> GetNodes(string filePath)
        {
            List<List<string>> nodeList = new List<List<string>>();
            List<string> fileLines = ReadFileToList(filePath);

            for (int i = 2; i < fileLines.Count; i++)
            {
                List<string> nodeDetails = new List<string>
                {
                    fileLines[i].Substring(0, 3),
                    fileLines[i].Substring(7, 3),
                    fileLines[i].Substring(12, 3)
                };

                nodeList.Add(nodeDetails);
            }
            return nodeList;
        }

        public string GetNextDestionation(int index, string input, string filePath)
        {
            List<List<string>> nodeList = GetNodes(filePath);

            if (input == "L")
            {
                return nodeList[index][1];
            }
            else
            {
                return nodeList[index][2];
            }
        }

        public string GetFinalLocation(string nextIteration, string filePath)
        {
            List<List<string>> nodeList = GetNodes(filePath);
            string directions = GetDirections(filePath);

            for (int directionIndex = 0; directionIndex < directions.Length; directionIndex++)
            {
                string direction = char.ToString(directions[directionIndex]);

                for (int nodeIndex = 0; nodeIndex < nodeList.Count; nodeIndex++)
                {
                    if (nextIteration == nodeList[nodeIndex][0])
                    {
                        nextIteration = GetNextDestionation(nodeIndex, direction, filePath);
                        break;
                    }
                }
            }
            return nextIteration;
        }

        public int GetNumberOfSteps(string filePath)
        {
            string startLocation = "AAA";
            string destinationEnd = "ZZZ";

            string directions = GetDirections(filePath);

            int directionsLength = directions.Length;
            string currentLocation = startLocation;

            int stepCount = 1;
            while (currentLocation != destinationEnd)
            {
                if (stepCount == 1)
                {
                    currentLocation = GetFinalLocation(startLocation, filePath);
                }
                else
                {
                    currentLocation = GetFinalLocation(currentLocation, filePath);
                }

                if (currentLocation == destinationEnd)
                {
                    break;
                }

                stepCount++;
            }
            int result = directionsLength * stepCount;
            return result;
        }

        public int GetNumberOfStepsForGhosts(string startNode, string filePath)
        {
            string directions = GetDirections(filePath);

            int directionsLength = directions.Length;
            string currentNode = startNode;

            int iterations = 1;
            while (currentNode[2] != 'Z')
            {
                if (iterations == 1)
                {
                    currentNode = GetFinalLocation(startNode, filePath);
                }
                else
                {
                    currentNode = GetFinalLocation(currentNode, filePath);
                }

                if (currentNode[2] == 'Z')
                {
                    break;
                }

                iterations++;
            }
            int result = directionsLength * iterations;
            return result;
        }

        public ulong GetGCD(ulong firstNumber, ulong secondNumber)
        {
            while (secondNumber != 0)
            {
                ulong temp = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = temp;
            }
            return firstNumber;
        }

        public ulong GetLCM(ulong firstNumber, ulong secondNumber)
        {
            return firstNumber * secondNumber / GetGCD(firstNumber, secondNumber);
        }

        public List<string> GetNodesThatEndOnA(string filePath)
        {
            List<List<string>> nodeList = GetNodes(filePath);

            List<string> nodesEndingOnA = new List<string>();

            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i][0][2] == 'A')
                {
                    nodesEndingOnA.Add(nodeList[i][0]);
                }
            }
            return nodesEndingOnA;
        }

        public List<int> GetIndividualNumbers(string filePath)
        {
            List<string> nodesEndingOnA = GetNodesThatEndOnA(filePath);
            List<int> individualStepCounts = new List<int>();

            foreach (string node in nodesEndingOnA)
            {
                individualStepCounts.Add(GetNumberOfStepsForGhosts(node, filePath));
            }

            return individualStepCounts;
        }

        public ulong GetLCMFinalAnswer(string filePath)
        {
            List<int> stepCounts = GetIndividualNumbers(filePath);

            ulong finalLCMResult = (ulong)stepCounts[0];

            for (int i = 1; i < stepCounts.Count; i++)
            {
                finalLCMResult = (ulong)GetLCM(finalLCMResult, (ulong)stepCounts[i]);
            }

            return finalLCMResult;
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