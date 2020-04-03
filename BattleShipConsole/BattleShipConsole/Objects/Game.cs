using System;

namespace BattleShipConsole.Objects {
    public class Game {
        public Player firstPlayer { get; set; }
        public Player secondPlayer { get; set; }

        public Game() {
            firstPlayer = new HumanPlayer("Human");
            secondPlayer = new Player("AI");
            
            firstPlayer.PlaceShips();
            secondPlayer.PlaceShips();
            
            firstPlayer.OutputBoards();
            // secondPlayer.OutputBoards();
        }

        public void PlayRound() {
            firstPlayer.OutputBoards();
            
            var firedCell = firstPlayer.FireShot();
            var result = secondPlayer.ProcessShot(firedCell);
            firstPlayer.ProcessShotResult(firedCell, result);

            if (!secondPlayer.HasLost) {
                firedCell = secondPlayer.FireShot();
                result = firstPlayer.ProcessShot(firedCell);
                secondPlayer.ProcessShotResult(firedCell, result);
            }
        }

        public void PlayToEnd() {
            var roundCount = 1;
            while (!firstPlayer.HasLost && !secondPlayer.HasLost) {
                Console.WriteLine("Round " + roundCount + " in progress");
                PlayRound();
                roundCount++;
            }
            
            // firstPlayer.OutputBoards();
            // secondPlayer.OutputBoards();

            if (firstPlayer.HasLost) {
                Console.WriteLine(secondPlayer.Name + " has won the game!");
            }
            else if (secondPlayer.HasLost) {
                Console.WriteLine(firstPlayer.Name + " has won the game!");
            }
        }
    }
}