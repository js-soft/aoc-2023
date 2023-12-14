/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
import { Player } from './player';

describe('Kata TDD Tennis Game: Player', () => {
    it('Should_Return_IncrementedPlayerScore', () => {
        // Arrange
        const player = new Player();

        // Act
        player.incrementPlayerScore();

        // Assert
        expect(player.getPlayerScore()).toEqual(1);
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