using System;
using System.Collections.Generic;
using System.Linq;
using BattleShipConsole.Objects;

namespace BattleShipConsole {
    class Type {
        private int i;

        public Type(int i) {
            this.i = i;
        }
    }
    class Program {
        static void Main(string[] args) {
            Game game = new Game();
            game.PlayToEnd();
        }
    }
}