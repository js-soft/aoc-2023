/* eslint-disable @typescript-eslint/no-empty-function */
/* eslint-disable prettier/prettier */
export function getGameIds(lines: string[]): number[] {
    const gameNumberArray: number[] = [];

    lines.forEach((line) => {
        const game = line.split(':')[0].trim();
        const gameNumber = parseInt(game.split(' ')[1], 10);
          
        if (!isNaN(gameNumber)) {
            gameNumberArray.push(gameNumber);
        }
    });

    return gameNumberArray;
}

export function getPossibleGames(lines: string[]): number[] {
    const possibleGamesArray: number[] = [];

    lines.forEach((line,index ) => {
        let redCounter = 0;
        let blueCounter = 0;
        let greenCounter = 0;

        const games = line.split(':')[1].trim();
        const getCubes = games.split(';');
       
        for(let i = 0; i < getCubes.length; i++){
            const attempt = getCubes[i].trim().split(' ,');
            
            attempt.forEach((draw) => {
                const cubeNumberColor = draw.split(', ');
                
                cubeNumberColor.forEach((cube, index) => {
                    const [count, color] = cube.split(' ');
                    const cubeCount = parseInt(count, 10);
                
                    switch (color) {
                        case 'red':
                            redCounter += cubeCount;
                            break;
                        case 'blue':
                            blueCounter += cubeCount;
                            break;
                        case 'green':
                            greenCounter += cubeCount;
                            break;
                        default:
                            break;
                    }
                    })

            })
        }

        if (redCounter <= 12 && blueCounter <= 13 && greenCounter <= 14) {
            possibleGamesArray.push(index + 1); // Add 1 to convert from zero-based index to game ID
        }
    });

    // console.log(possibleGamesArray);
    return possibleGamesArray;
}