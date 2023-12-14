/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
import { Game } from './bowling-game'

describe('Kata TDD Bowling Game', () => {

    const game = new Game();

    
    function rollMany(n: number, pins: number) : void {
        for(let i = 0; i < n; i++){
            game.roll(pins);
        }
    }

    it('Should_Return_GutterGame', () => {
        // Arrange

        // Act
        rollMany(20, 0);

        // Assert
        expect(game.score()).toEqual(0);
    });

    it('Should_Return_AllOnes', () => {
        // Arrange

        // Act
        rollMany(20, 1);

        // Assert
        expect(game.score()).toEqual(20);
    });

    it('Should_Return_OneSpare', () => {
        // Arrange
        game.roll(5);
        game.roll(5);
        game.roll(3);
        
        // Act
        rollMany(17,0);

        //Assert
        expect(game.score()).toEqual(16);
    });
});