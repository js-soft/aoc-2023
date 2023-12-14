/* eslint-disable @typescript-eslint/no-inferrable-types */
/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
export class Game {

    private gameScore: number = 0;

    public roll(pins: number) : void {
        this.gameScore += pins;
    }

    public score() : number {
        return this.gameScore;
    }
}