namespace BattleShipConsole.Objects {
    
    public class Cell {

        public OccupationType OccupationType { get; set; }
        public Coordinates Coordinates { get; set; }

        public Cell(int row, int column) {
            Coordinates = new Coordinates(row, column);
            OccupationType = OccupationType.Empty;
        }

        public char Status {
            get { return (char) this.OccupationType; }
        }

        public bool IsOccupied {
            get {
                return this.OccupationType == OccupationType.Battleship ||
                       this.OccupationType == OccupationType.Destroyer ||
                        this.OccupationType == OccupationType.Cruiser || 
                    this.OccupationType == OccupationType.Submarine ||
                    this.OccupationType == OccupationType.Carrier;
            }
        }

        public bool IsRandomAvailable {
            get {
                return (Coordinates.row % 2 == 0 && Coordinates.column % 2 == 0) ||
                       (Coordinates.row % 2 == 1 && Coordinates.column % 2 == 1);
            }
        }
    }
}