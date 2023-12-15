/* eslint-disable prettier/prettier */
export class Player {
    private playerScore: number;

    constructor() {
        this.playerScore = 0;
    }

    public getPlayerPoints() : number {
        return this.playerScore;
    }

    public incrementPlayerPoints() : void {
        this.playerScore++;
    }
}