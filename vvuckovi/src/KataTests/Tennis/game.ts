/* eslint-disable @typescript-eslint/no-empty-function */

import { Player } from "./player";
import { Converters } from "./converters";

/* eslint-disable prettier/prettier */
export class Game {
    
    PlayGameOfTennis(player1: Player, player2: Player) : string {
        const convert = new Converters();
        
        if(player1.getPlayerPoints() === player2.getPlayerPoints() && player1.getPlayerPoints() >= 3) {
            return "deuce";
        }

        return convert.ConvertPlayerPoints(player1.getPlayerPoints()) + "-" + convert.ConvertPlayerPoints(player2.getPlayerPoints());
    }

}