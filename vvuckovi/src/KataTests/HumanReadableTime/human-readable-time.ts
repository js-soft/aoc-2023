/* eslint-disable no-empty */
/* eslint-disable prettier/prettier */
export function GetHumanReadableTime(time: number) : string {
    
    const hours: number = Math.floor(time / 3600);
    const minutes: number = Math.floor((time % 3600) / 60);
    const seconds: number = time % 60;

    return getDoubleDigits(hours) + ":" + getDoubleDigits(minutes) + ":" + getDoubleDigits(seconds);
}

function getDoubleDigits(time: number) : string{
    if(time < 10)
        return "0" + time;

    return "" + time;
}