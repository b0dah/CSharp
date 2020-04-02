using System.Collections.Generic;
using System.Linq;

namespace BattleShipConsole.Objects.Extensions {
    public static class CellExtension {
        public static List<Cell> Range(this List<Cell> cells, int startRow, int startColumn, int endRow, int endColumn) {
            return cells.Where(x => x.Coordinates.row >= startRow
                                    && x.Coordinates.column >= startColumn
                                    && x.Coordinates.row <= endRow
                                    && x.Coordinates.column <= endColumn).ToList();
        }

        public static Cell At(this List<Cell> cells, int row, int column) {
            return cells.Where(x => x.Coordinates.row == row && x.Coordinates.column == column).First();
        }
    }
}