/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
import { Game } from './bowling-game'

describe('Kata TDD Bowling Game', () => {

    let game: Game; 

    function setUp() : void {
        game = new Game();
    }
    
    function rollMany(n: number, pins: number) : void {
        for(let i = 0; i < n; i++){
            game.roll(pins);
        }
    }

    
    function rollSpare(game: Game) {
        game.roll(5);
        game.roll(5);
    }

    function rollStrike() {
        game.roll(10);
    }

    it('Should_Return_GutterGame', () => {
        // Arrange
        setUp();

        // Act
        rollMany(20, 0);

        // Assert
        expect(game.score()).toEqual(0);
    });

    it('Should_Return_AllOnes', () => {
        // Arrange
        setUp();

        // Act
        rollMany(20, 1);

        // Assert
        expect(game.score()).toEqual(20);
    });

    it('Should_Return_OneSpare', () => {
        // Arrange
        setUp();

        // Act
        rollSpare(game);
        game.roll(3);
        rollMany(17,0);

        // Assert
        expect(game.score()).toEqual(16);
    });

    it('Should_Return_OneStrike', () => {
        // Arrange
        setUp();

        // Act
        rollStrike();
        game.roll(3);
        game.roll(4);
        rollMany(16,0);

        // Assert
        expect(game.score()).toEqual(24);
    });

    it('Should_Return_PerfectGame', () => {
        // Arrange
        setUp();

        // Act
        rollMany(12,10);

        // Assert
        expect(game.score()).toEqual(300); 
    });
});

