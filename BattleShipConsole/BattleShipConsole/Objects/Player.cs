using System;
using System.Collections.Generic;
using System.Linq;
using BattleShipConsole.Objects.Extensions;

namespace BattleShipConsole.Objects {
    public class Player {
        public string Name { get; set; }
        public GameBoard GameBoard { get; set; }
        public FiringBoard FiringBoard { get; set; } 
        public List<Ship> Ships { get; set; }
        
        public int shipsLost { get; set; }
        
        public bool HasLost {
            get { return Ships.All(x => x.IsSunk); }
        }

        public void PlaceShips() {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            Console.WriteLine("\t\t total ships" + Ships.Count);
            
            foreach (var ship in Ships) {
                // Console.WriteLine("КОРабль : " + ship.Name + "    " + (char) ship.OccupationType);
                bool notPlacedYet = true;
                
                while (notPlacedYet) {

                    var startColumn = rand.Next(1, 11);
                    var startRow = rand.Next(1, 11);

                    int endRow = startRow, endColumn = startColumn;

                    var orientation = rand.Next(1, 101) % 2; // 0 for Horizonal

                    // List<int> cellNumbers = new List<int>();

                    if (orientation == 0) {
                        endRow += ship.Width - 1;
                    }
                    else {
                        endColumn += ship.Width - 1;
                    }

                    // Boundaries
                    if (endRow > 10 || endColumn > 10) {
                        notPlacedYet = true;
                        continue;
                    }

                    var affectedCells = GameBoard.Cells.Range(startRow, startColumn, endRow, endColumn);
                    if (affectedCells.Any(x => x.IsOccupied)) {
                        notPlacedYet = true;
                        continue;
                    } 
                            // Console.WriteLine("*Length = *" + affectedCells.Count);
                    // if eventually possible to place cur ship
                    foreach (var cell in affectedCells) {
                        cell.OccupationType = ship.OccupationType;
                    }
                    
                    notPlacedYet = false;
                }

            }
        }
        
        public void OutputBoards()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Own Board:                                                          Firing Board:");
            for(int row = 1; row <= 10; row++)
            {
                for(int ownColumn = 1; ownColumn <= 10; ownColumn++)
                {
                    Console.Write(GameBoard.Cells.At(row, ownColumn).Status + "  ");
                }
                Console.Write("                ");
                for (int firingColumn = 1; firingColumn <= 10; firingColumn++)
                {
                    Console.Write(FiringBoard.Cells.At(row, firingColumn).Status + "  ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }    
        
        // FIRING
        public virtual Coordinates FireShot() {
            var hitNeighbours = FiringBoard.GetHitNeighbours();
            Coordinates coordinatesToShotAt;

            if (hitNeighbours.Any())
                coordinatesToShotAt = SearchingShot();
            else 
                coordinatesToShotAt = RandomShot();
            
            Console.WriteLine(Name + " says: \"Firing shot at "
                                    + coordinatesToShotAt.row.ToString() + ":"
                                   + coordinatesToShotAt.column.ToString()
                                   + "\"");
            
            return coordinatesToShotAt;
        }

        public Coordinates RandomShot() {
            var availableCells = FiringBoard.GetOpenRandomCells();
            Random random = new Random(Guid.NewGuid().GetHashCode());
            var cellToFireIndex = random.Next(availableCells.Count);
            
            Console.WriteLine(" CUR IND: " + cellToFireIndex + "\t" + " CUR COUNT: " + availableCells.Count);
            
            return availableCells[cellToFireIndex];
        }

        public Coordinates SearchingShot() { // returns Coordinates the Player wants to fire
            Random random = new Random(Guid.NewGuid().GetHashCode());
            var hitNeighbours = FiringBoard.GetHitNeighbours();
            var neighbourIndex = random.Next(hitNeighbours.Count);

            return hitNeighbours[neighbourIndex];
        }

        public Player(string name) {
            this.Name = name;
            Ships = new List<Ship>() {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new Battleship(),
                new Carrier()
            };
            GameBoard = new GameBoard();
            FiringBoard = new FiringBoard();
            shipsLost = 0;
        }
        
        // Reacting to Shots Fired
        public ShotResult ProcessShot(Coordinates coordinates) {
            var firedCell = GameBoard.Cells.At(coordinates.row, coordinates.column);
            

            if (!firedCell.IsOccupied) {
                Console.WriteLine(Name + " says: \"Miss!\"");
                firedCell.OccupationType = OccupationType.Miss;
                return ShotResult.Miss;
            }
            
            // -> hit the ship
            var ship = Ships.First(x => x.OccupationType == firedCell.OccupationType);
            ship.Hits++;
            
            firedCell.OccupationType = OccupationType.Hit; // Mark the cell on the Own Board

            
            Console.WriteLine(Name + " says: \"Hit!\"");

            if (ship.IsSunk) {
                shipsLost++;
                Console.WriteLine(Name + " says: \"You sunk my " + ship.Name + "!\"");
                // Console.WriteLine("    Player " + Name + " LOST " + shipsLost);
            }

            return ShotResult.Hit;
        }

        public void ProcessShotResult(Coordinates coordinates, ShotResult result) {

            var cell = FiringBoard.Cells.At(coordinates.row, coordinates.column);

            switch (result) {
                case ShotResult.Hit:
                    cell.OccupationType = OccupationType.Hit;
                    break;
                default:
                    cell.OccupationType = OccupationType.Miss;
                    break;
            }
        }
    }
}