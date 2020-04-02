namespace BattleShipConsole.Objects {
    public class Battleship : Ship { //  линейный / линкор
        public Battleship() {
            Name = "Battleship";
            Width = 4;
            OccupationType = OccupationType.Battleship;
        }
    }
}
