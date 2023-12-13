/* eslint-disable prettier/prettier */
export function GetHumanReadableTime(time: number) : string {
    const humanReadableTime = "";
    
    const seconds = time % 60;
    if (seconds < 10)
        return "00:00:0" + seconds; 

    return "00:00:" + seconds;
}