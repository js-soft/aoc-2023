using System;
using System.Text;

namespace Day05Src
{
    public class Alamac
    {
        public List<int> GetAllSeeds(string filePath)
        {
            string seedsLine = File.ReadAllText(filePath).Split('\n').FirstOrDefault(line => line.Contains("seeds:"));
            return ExtractNumbers(seedsLine);
        }

        public List<int> ExtractNumbers(string input)
        {
            return input?.Split(' ')
                         .Where(word => int.TryParse(word, out _))
                         .Select(int.Parse)
                         .ToList() ?? new List<int>();
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

        public List<List<int>> GetAllMappings(string filePath, string mappingName)
        {
            List<List<int>> result = new List<List<int>>();

            string[] lines = File.ReadAllLines(filePath);

            int mappingIndex = Array.IndexOf(lines, mappingName);

            for (int i = mappingIndex + 1; i < lines.Length && !string.IsNullOrWhiteSpace(lines[i]); i++)
            {
                List<int> mappingValues = lines[i].Split(' ').Select(int.Parse).ToList();
                result.Add(mappingValues);
            }

            return result;
        }

        public List<int> CreateEntireMapping(List<List<int>> mappings)
        {
            List<int> result = Enumerable.Range(0, 108).ToList();

            foreach (var mapping in mappings)
            {
                int destinationRange = mapping[0];
                int sourceRange = mapping[1];
                int rangeLength = mapping[2];

                for (int j = sourceRange; j < sourceRange + rangeLength; j++)
                {
                    result[j] = destinationRange++;
                }
            }

            return result;
        }


        public int GetSeedLoaction(int seedNumber, string filePath)
        {
            List<int> seedToSoilMap = CreateMap(filePath, "seed-to-soil map:");
            List<int> soilToFertilizerMap = CreateMap(filePath, "soil-to-fertilizer map:");
            List<int> fertilizerToWaterMap = CreateMap(filePath, "fertilizer-to-water map:");
            List<int> waterToLightMap = CreateMap(filePath, "water-to-light map:");
            List<int> lightToTemperatureMap = CreateMap(filePath, "light-to-temperature map:");
            List<int> temperatureToHumidityMap = CreateMap(filePath, "temperature-to-humidity map:");
            List<int> humidityToLocationMap = CreateMap(filePath, "humidity-to-location map:");

            int seedToSoil = GetValueFromMapping(seedToSoilMap, seedNumber);
            int soilToFertilizer = GetValueFromMapping(soilToFertilizerMap, seedToSoil);
            int fertilizerToWater = GetValueFromMapping(fertilizerToWaterMap, soilToFertilizer);
            int waterToLight = GetValueFromMapping(waterToLightMap, fertilizerToWater);
            int lightToTemperature = GetValueFromMapping(lightToTemperatureMap, waterToLight);
            int temperatureToHumidity = GetValueFromMapping(temperatureToHumidityMap, lightToTemperature);
            int humidityToLocation = GetValueFromMapping(humidityToLocationMap, temperatureToHumidity);

            return humidityToLocation;
        }

        private List<int> CreateMap(string filePath, string mappingKey)
        {
            return CreateEntireMapping(GetAllMappings(filePath, mappingKey));
        }

        private int GetValueFromMapping(List<int> mapping, int index)
        {
            return mapping[index];
        }


        public int GetLowestLocationNumber(string filePath)
        {
            List<int> allSeeds = GetAllSeeds(filePath);

            List<int> result = new List<int>();

            foreach (int seedNumber in allSeeds)
            {
                var res = GetSeedLoaction(seedNumber, filePath);
                result.Add(res);
            }

            return result.Min();
        }
    }
}