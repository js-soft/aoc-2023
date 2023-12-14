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
    it('Should_ScorePoint_ForPlayer1', () => {
        // Arrange
        const game = new Game();
        const player1 = new Player();
        const player2 = new Player();

        // Act
        player1.incrementPlayerPoints();

        // Assert
        expect(game.PlayGameOfTennis(player1,player2)).toEqual('15-love');
    });

    it('Should_ScorePointsDeuce_WhenPlayersHave40', () => {
        // Arrange
        const game = new Game();
        const player1 = new Player();
        const player2 = new Player();

        // Act
        PlayerScore(player1, 3);
        PlayerScore(player2, 3);

        // Assert
        expect(game.PlayGameOfTennis(player1,player2)).toEqual('deuce');
    });

    function PlayerScore(player: Player, score: number) {
        for(let i = 0; i < score; i++){
            player.incrementPlayerPoints();
        }
    }
}) 