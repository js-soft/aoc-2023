/* eslint-disable prettier/prettier */
export class Player {
    private playerScore: number;

    constructor() {
        this.playerScore = 0;
    }

    public getPlayerScore() : number {
        return this.playerScore;
    }

    public incrementPlayerScore() : void {
        this.playerScore++;
    }
}