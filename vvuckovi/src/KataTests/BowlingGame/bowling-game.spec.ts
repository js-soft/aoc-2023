/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
import { Game } from './bowling-game'

describe('Kata TDD Bowling Game', () => {
    it('test', () => {
        // Arrange
        const game = new Game();

        // Act
        for(let i = 0; i < 20; i++){
            game.roll(0);
        }

        // Assert
        expect(game.score()).toEqual(0);
    });
});