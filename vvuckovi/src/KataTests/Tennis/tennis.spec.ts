/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
import { Player } from './player';
import { Converters } from './converters';
import { Game } from './game';

describe('Kata TDD Tennis: Player', () => {
    it('Should_Return_IncrementedPlayerScore', () => {
        // Arrange
        const player = new Player();

        // Act
        player.incrementPlayerPoints();

        // Assert
        expect(player.getPlayerPoints()).toEqual(1);
    })
});

describe('Kata TDD Tennis: Score', () => {
    it('Should_Return_Love', () => {
        // Arrange
        const score = new Converters();

        // Act
        const result = score.ConvertPlayerPoints(0);

        // Assert
        expect(result).toEqual('love');
    })

    it('Should_Return_Fifteen', () => {
        // Arrange
        const score = new Converters();

        // Act
        const result = score.ConvertPlayerPoints(1);

        // Assert
        expect(result).toEqual('15');
    })

    it('Should_Return_Thirty', () => {
        // Arrange
        const score = new Converters();

        // Act
        const result = score.ConvertPlayerPoints(2);

        // Assert
        expect(result).toEqual('30');
    })

    it('Should_Return_Forty', () => {
        // Arrange
        const score = new Converters();

        // Act
        const result = score.ConvertPlayerPoints(3);

        // Assert
        expect(result).toEqual('40');
    })
})

describe('Kata TDD Tennis: Game', () => {
    it('Should_Return_FifteenLove', () => {
        // Arrange
        const game = new Game();
        const playerOne = new Player();
        const playerTwo = new Player();

        // Act
        playerOne.incrementPlayerPoints();

        // Assert
        expect(game.PlayGameOfTennis(playerOne,playerTwo)).toEqual('15-love');
    });
}) 