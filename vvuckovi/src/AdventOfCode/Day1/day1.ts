export function calculateCalibrationValues(lines: string[]): number[] {
  return lines.map((line) => {
    const firstDigitMatch = line.match(/\d/); // Find the first digit in the line
    const lastDigitMatch = line.match(/\d(?=\D*$)/); // Find the last digit in the line

    console.log(firstDigitMatch, lastDigitMatch);
    
    if (firstDigitMatch && lastDigitMatch) {
      const firstDigit = parseInt(firstDigitMatch[0], 10);
      const lastDigit = parseInt(lastDigitMatch[0], 10);
      return firstDigit * 10 + lastDigit;
    } else {
      return NaN;
    }
  });
}

export function sumCalibrationValues(calibrationValues: number[]): number {
  return calibrationValues.reduce((acc, value) => acc + value, 0);
}
