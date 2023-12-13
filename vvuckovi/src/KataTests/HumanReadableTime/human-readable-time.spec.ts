/* eslint-disable prettier/prettier */
/* eslint-disable @typescript-eslint/no-empty-function */

// Write a function, which takes a non-negative integer (seconds) as 
// input and returns the time in a human-readable format (HH:MM:SS)

// HH = hours, padded to 2 digits, range: 00 – 99
// MM = minutes, padded to 2 digits, range: 00 – 59
// SS = seconds, padded to 2 digits, range: 00 – 59
// The maximum time never exceeds 359999 (99:59:59).
import { GetHumanReadableTime } from './human-readable-time';

describe("Kata Test Human Readable Time", () => {
    it('Should_BeEqual_ToZeroTime', () => {
        // Arrange

        // Act
        const readableTimeResult = GetHumanReadableTime(0);

        // Assert
        expect(readableTimeResult).toEqual("00:00:00");
    })

    it('Should_Return_Seconds', () => {
        // Arrange

        // Act
        const readableTimeResult = GetHumanReadableTime(5);

        // Assert
        expect(readableTimeResult).toEqual("00:00:05");
    });

    it('Should_Return_Minutes', () => {
         // Arrange

        // Act
        const readableTimeResult = GetHumanReadableTime(60);

        // Assert
        expect(readableTimeResult).toEqual("00:01:00");
    });

    it('test', () => {
        // Arrange

       // Act
       const readableTimeResult = GetHumanReadableTime(86399);

       // Assert
       expect(readableTimeResult).toEqual("23:59:59");
   });
})