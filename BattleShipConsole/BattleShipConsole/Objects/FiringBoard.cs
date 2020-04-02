using System.Collections.Generic;
using System.Linq;
using BattleShipConsole.Objects.Extensions;

namespace BattleShipConsole.Objects {
    public class FiringBoard : GameBoard {
        public List<Coordinates> GetOpenRandomCells() {
            return Cells.Where(x => x.OccupationType == OccupationType.Empty
                                    && x.IsRandomAvailable)
                .Select(x => x.Coordinates)
                .ToList();
        }

        public List<Coordinates> GetHitNeighbours() {
            List <Cell> hitCells = new List<Cell>();
            var hits = Cells.Where(x => x.OccupationType == OccupationType.Hit);

            foreach (var hit in hits) { // neighbours for all the hit panels
                hitCells.AddRange(GetNeighbours(hit.Coordinates).ToList());
            }

            return hitCells.Distinct()
                .Where(x => x.OccupationType == OccupationType.Empty)
                .Select(x => x.Coordinates)
                .ToList();
        }

        public List<Cell> GetNeighbours(Coordinates coordinates) {
            int row = coordinates.row;
            int column = coordinates.column;

            List<Cell> neighbouringCells = new List<Cell>();
            
            if (row>1) 
                neighbouringCells.Add(Cells.At(row-1, column));
            if (column>1)
                neighbouringCells.Add(Cells.At(row, column-1));
            if (row<10)
                neighbouringCells.Add(Cells.At(row+1, column));
            if (column<10)
                neighbouringCells.Add(Cells.At(row, column+1));

            return neighbouringCells;
        }
    }
}