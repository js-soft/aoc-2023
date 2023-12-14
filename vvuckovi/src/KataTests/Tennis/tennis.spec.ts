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

