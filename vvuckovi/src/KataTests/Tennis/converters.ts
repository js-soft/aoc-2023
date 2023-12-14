/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
export class Converters {
    ConvertPlayerPoints(point: number) : string {
        let convertedPoint = "";

        switch(point) {
            case 1: convertedPoint = '15'; break;
            case 2: convertedPoint = '30'; break;
            case 3: convertedPoint = '40'; break;
            default: convertedPoint = 'love';
        }

        return convertedPoint;
    }
}