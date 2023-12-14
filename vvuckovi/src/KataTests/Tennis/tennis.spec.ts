/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
import { Player } from './player';
import { Score } from './score';

describe('Kata TDD Tennis Game: Player', () => {
    it('Should_Return_IncrementedPlayerScore', () => {
        // Arrange
        const player = new Player();

        // Act
        player.incrementPlayerPoints();

        // Assert
        expect(player.getPlayerPoints()).toEqual(1);
    })
});

describe('Kata TDD Tennis Game: Score', () => {
    it('test', () => {
        // Arrange
        const score = new Score();

        // Act
        const result = score.ConvertPlayerPoints(0);

        // Assert
        expect(result).toEqual("love");
    })
});