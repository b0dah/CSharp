namespace BattleShipConsole.Objects {
    public class Coordinates {
        

        public int row { get; set; }
        public int column { get; set; }
        
        public Coordinates(int row, int column) {
            this.row = row;
            this.column = column;
        }
    }
}