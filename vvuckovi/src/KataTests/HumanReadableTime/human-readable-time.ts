/* eslint-disable no-empty */
/* eslint-disable prettier/prettier */
export function GetHumanReadableTime(time: number) : string {
    
    
    const minutes = Math.floor(time / 60);
    const seconds = time - (minutes * 60);

    return "00:" + getDoubleDigits(minutes) + ":" + getDoubleDigits(seconds);
}

function getDoubleDigits(time: number) : string{
    if(time < 10)
        return "0" + time;

    return "" + time;
}