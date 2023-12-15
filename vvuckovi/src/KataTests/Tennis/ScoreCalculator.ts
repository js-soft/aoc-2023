/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
import { Player } from "./player";

export class ScoreCalculator {

    PlayGameOfTennis(player1: Player, player2: Player) : string {
        
        if(this.isAdvantage(player1,player2)){
            return "player2 AD";
        }

        if(this.Deuce(player1, player2)) {
            return "deuce";
        }

        return this.ConvertPlayerPoints(player1.getPlayerPoints()) + "-" + this.ConvertPlayerPoints(player2.getPlayerPoints());
    }

    private isAdvantage(player1: Player,player2: Player) {
        return player1.getPlayerPoints() < player2.getPlayerPoints()
    }

    private Deuce(player1: Player, player2: Player) {
        return player1.getPlayerPoints() === player2.getPlayerPoints() 
                && player1.getPlayerPoints() == 3;
    }

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