/* eslint-disable @typescript-eslint/no-inferrable-types */
/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
export class Game {
    private rolls!: Array<number>;
    private currentRoll = 0;

    public roll(pins: number) : void {
        this.rolls[this.currentRoll++] = pins;
    }

    public score() : number {
        let score = 0;

        for(let i = 0; this.rolls.length; i++){
            score += this.rolls[i];
        }

        return score;
    }
}