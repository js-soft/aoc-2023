/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
import { isLeapYear } from './leap-year';

describe('Kata Test Leap Year', () => {
   it('Should_BeFalse_ForTypicalCommonYear', () => {
    // Arrange

    // Act
    const isLeapYearResult = isLeapYear(1997);

    // Assert
    expect(isLeapYearResult).toEqual(false);
   });

   it('Should_BeTrue_ForTypicalYear', () => {
    // Arrange

    // Act
    const isLeapYearResult = isLeapYear(1996);

    // Assert
    expect(isLeapYearResult).toEqual(true);
   });

   it.each(
    [
        [1900, false],
        [2000, true]
    ]
   )('Should_Decide_ForUncommonYear', (year, expectedResult) => {
    // Arrange

    // Act
    const isLeapYearResult = isLeapYear(year);

    // Assert
    expect(isLeapYearResult).toEqual(expectedResult);
   });
});