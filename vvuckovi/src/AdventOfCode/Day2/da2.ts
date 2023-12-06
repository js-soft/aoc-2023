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

