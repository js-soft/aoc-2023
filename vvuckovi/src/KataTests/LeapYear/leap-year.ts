/* eslint-disable prettier/prettier */
/* eslint-disable @typescript-eslint/no-empty-function */
export function isLeapYear(year: number) : boolean{
    return year % 4 === 0 && year % 100 !== 0 || year % 400 === 0;
}