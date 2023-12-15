/* eslint-disable @typescript-eslint/no-inferrable-types */
/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
export class Game {
    private rolls: number[];
    private currentRoll = 0;

    constructor() {
        this.rolls = [];
    }

    public roll(pins: number) : void {
        this.rolls[this.currentRoll++] = pins;
    }

    public score() : number {
        let score = 0;
        let frameIndex = 0;

        for(let frame = 0; frame < 10; frame++){
            if(this.isStrike(frameIndex)){
                score += 10 + this.strikeBonus(frameIndex);
                frameIndex++;
            }
            else if(this.isSpare(frameIndex)){
                score += 10 + this.spareBonus(frameIndex);
                frameIndex += 2;
            }else {
                score += this.sumOfBallsInFrame(frameIndex);
                frameIndex += 2;
            }
        }

        return score;
    }

    private isStrike(frameIndex: number) {
        return this.rolls[frameIndex] == 10;
    }

    private strikeBonus(frameIndex: number) {
       return this.rolls[frameIndex + 1] + this.rolls[frameIndex + 2]
    }

    private spareBonus(frameIndex: number) {
        return this.rolls[frameIndex + 2];
    }

    private sumOfBallsInFrame(frameIndex: number) {
        return this.rolls[frameIndex] + this.rolls[frameIndex + 1];
    }

    private isSpare(frameIndex: number) {
        return this.rolls[frameIndex] + this.rolls[frameIndex + 1] == 10;
    }

}