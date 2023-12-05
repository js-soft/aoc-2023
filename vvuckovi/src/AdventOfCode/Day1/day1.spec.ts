import { calculateCalibrationValues, sumCalibrationValues } from './day1';

describe('Day 1 TDD begginer', () => {
  it('parseLinesIntoTwoDigitPair', () => {
    // Arrange
    const inputLines = ['1abc2', 'pqr3stu8vwx', 'a1b2c3d4e5f', 'treb7uchet'];
    const expectedValues = [12, 38, 15, 77];

    // Act
    const result = calculateCalibrationValues(inputLines);

    // Assert
    expect(result).toEqual(expectedValues);
  });

  it('calculateSumOfValues', () => {
    // Arrange
    const calibrationValues = [12, 38, 15, 77];
    const expectedSum = 142;

    // Act
    const result = sumCalibrationValues(calibrationValues);

    // Assert
    expect(result).toEqual(expectedSum);
  });

  it('calculateSumOfParsedLines', () => {
    // Arrange
    const inputLines = ['1abc2', 'pqr3stu8vwx', 'a1b2c3d4e5f', 'treb7uchet'];
    const expectedSum = 142;

    // Act
    const result = calculateCalibrationValues(inputLines);

    // Assert
    expect(sumCalibrationValues(result)).toEqual(expectedSum);
  });
});
