using System;

namespace BattleShipConsole.Objects {
    public class HumanPlayer: Player {
        public HumanPlayer(string name) : base(name) {
        }

        public override Coordinates FireShot(/*Coordinates coordinates*/) {
            int row = 0, column = 0;

            while (true) {
                Console.WriteLine("\n Coordinates to fire at:");
                String stringCoordinates = Console.ReadLine();
                try {
                    string[] splittedCoordinates = stringCoordinates.Split(" ");
                    if (splittedCoordinates.Length == 2) {
                        row = int.Parse(splittedCoordinates[0]);
                        column = int.Parse(splittedCoordinates[1]);
                        break;
                    }
                    else {
                        Console.WriteLine("Error!\n Enter coordinates in format: |ROW COL|");
                    }
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                    throw;
                }
            }


            return new Coordinates(row, column);
        }
    }
}