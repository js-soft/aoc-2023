/* eslint-disable no-empty */
/* eslint-disable prettier/prettier */
export function GetHumanReadableTime(time: number) : string {
    
    if(time < 0 || time > 359_999)
        return "00:00:00"

    const hours: number = Math.floor(time / 3600);
    const minutes: number = Math.floor((time % 3600) / 60);
    const seconds: number = time % 60;

    return getDoubleDigits(hours) + ":" + getDoubleDigits(minutes) + ":" + getDoubleDigits(seconds);
}

function getDoubleDigits(time: number) : string{
    return time < 10 ? "0" + time : "" + time;
}