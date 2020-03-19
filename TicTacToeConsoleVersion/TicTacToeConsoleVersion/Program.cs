using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeConsoleVersion {

    struct Move {
        public int index;
        public int score;
    }
    
    class Program {
        // private static List<object> origBoard;
        
        public static int minimaxCalls = 0;
        
        String human = "O";
        String ai = "X";

        private static List<String> origBoard;

        private List<int> emptyIndices(List<String> board) {
            // return board.Where(x => int.TryParse(x, out _)).ToList();
            List<int> result = new List<int>();
            foreach (var spot in board) {
                int number;
                if (int.TryParse(spot, out number)) {
                    result.Add(number);
                }
            }
            return result;
        }

        private bool winning(List<String> board, String player) {
            if ((board[0] == player && board[1] == player && board[2] == player) ||
                (board[3] == player && board[4] == player && board[5] == player) ||
                (board[6] == player && board[7] == player && board[8] == player) ||
                (board[0] == player && board[3] == player && board[6] == player) ||
                (board[1] == player && board[4] == player && board[7] == player) ||
                (board[2] == player && board[5] == player && board[8] == player) ||
                (board[0] == player && board[4] == player && board[8] == player) ||
                (board[2] == player && board[4] == player && board[6] == player)
            ) {
                return true;
            } else {
                return false;
            }
        }

        private Move miniMax(List<String> newBoard, String player) {
            
            minimaxCalls++;

            // available spots
            List<int> availableSpots = emptyIndices(newBoard);
            
            // in the end of the game reached
            if (winning(newBoard, human)) {
                Move moveToReturn = new Move();
                moveToReturn.score = -10;
                return moveToReturn;
            }
            else if (winning(newBoard, ai)) {
                Move moveToReturn = new Move();
                moveToReturn.score = 10;
                return moveToReturn;
            } 
            else if (availableSpots.Count == 0) {
                Move moveToReturn = new Move();
                moveToReturn.score = 0;
                return moveToReturn;
            }

            List<Move> moves = new List<Move>();

            for (int i = 0; i < availableSpots.Count; i++) {
                Move move = new Move();

                var number = 0;
                var index = int.TryParse(newBoard[availableSpots[i]], out number);
                move.index = number; // number 0-8

                newBoard[(int)availableSpots[i]] = player;

                if (player == ai) {
                    var result = miniMax(newBoard, human);
                    move.score = result.score; // ??
                }
                else {
                    var result = miniMax(newBoard, ai);
                    move.score = result.score;
                }
                
                // reset the spot to empty 
                newBoard[availableSpots[i]] = move.index.ToString();

                moves.Add(move);
            }

            int bestMove = 0;
            
            if (player == ai) {
                var bestScore = -10000;
                for (var i = 0; i < moves.Count; i++) {
                    if (moves[i].score > bestScore) {
                        bestScore = moves[i].score;
                        bestMove = i;
                    }
                }
            }
            else {
                var bestScore = 10000;
                for (int i = 0; i < moves.Count; i++) {
                    if (moves[i].score < bestScore) {
                        bestScore = moves[i].score;
                        bestMove = i;
                    }
                }
            }

            Console.WriteLine(moves[bestMove].index);
            return moves[bestMove];
        }



        static void Main(string[] args) {
            
            // origBoard = new List<String>()  {"O","1" ,"X","X","4" ,"X", "6" ,"O","O"};
            origBoard = new List<String>()  {"X","X","2",  "O","O","5",  "6","7","8" };

            // Console.Write(origBoard[0]);
            // List<string> l = new List<string>() {"1", "2"};
            // foreach (var elem in l) {
            //     int number;
            //     if (int.TryParse(elem, out number)) {
            //         Console.Write(elem);
            //     }
            // }
            Program game  = new Program();
            
            var rightMove = game.miniMax(origBoard, game.ai);
            Console.Write("The best move is " + rightMove.index);
            Console.Write("Calls " + minimaxCalls);


        }
        
    }
}