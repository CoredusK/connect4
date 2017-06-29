using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
	public enum Turn { P1 = 1, P2 = 2 }

    public class Game
    {
		public const int NROWS = 6;
		public const int NCOLS = 7;

		public int[,] Board { get; set; }

		public Turn Turn { get; set; }

		public Game() {
			ResetGame();
		}


		public void ResetGame() {
			Board = new int[NROWS, NCOLS];

			for (int i = 0; i < Board.GetLength(0); i++) {
				for (int j = 0; j < Board.GetLength(1); j++) {
					Board[i, j] = -1;
				}
			}

			//Turn = (Turn)new Random().Next(1, 3);	// Random start move
			Turn = Turn.P1;
		}


		public void PrintBoard() {
			for(int y = 0; y < NROWS; y++) {
				for(int x = 0; x < NCOLS; x++) {
					Console.Write(Board[y, x] + " ");
				}
				Console.WriteLine();
			}
		}

		public bool ColHasSpace(int col) {
			for(int y = 0; y < NROWS; y++) {
				if(Board[y, col] == -1) return true;
			}
			return false;
		}

		/// <summary>
		/// Next player make a move on the board
		/// </summary>
		/// <param name="col">Which column to do a move in</param>
		/// <returns></returns>
		public void MakeMove(int col) {
			for(int y = 0; y < NROWS; y++) {
				if(y == NROWS - 1 && Board[y,col] == -1) { // reach bottom of board
					Board[y, col] = (int) Turn;
					return;
				}
				else if(Board[y, col] == -1 && Board[y + 1, col] != -1) {
					Board[y, col] = (int) Turn;
					return;
				}

			}      

		}

        public bool DetectDraw() {
            for(int i = 0; i < NCOLS; i++) {
                if(ColHasSpace(i)) {
                    return false;
                }
            }

            return true;
        }

		public bool DetectWinner() {
			// Check horizontal
			for (int y = 0; y < NROWS; y++) {
				for (int x = 0; x < NCOLS - 3; x++) {
					if(Board[y, x] == -1) continue;
					if(Board[y, x] == Board[y, x+1] && Board[y, x] == Board[y, x+2] && Board[y, x] == Board[y, x+3]) {
						return true;
					}
				}
	
			}

			// Check vertical
			for (int y = 0; y < NROWS - 3; y++) {
				for (int x = 0; x < NCOLS; x++) {
					if(Board[y, x] == -1) continue;
					if(Board[y, x] == Board[y+1, x] && Board[y, x] == Board[y+2, x] && Board[y, x] == Board[y+3, x]) {
						return true;
					}
				}
			}

			// Check diag 1
			for(int y = 0; y < NROWS - 3; y++) {
				for(int x = 0; x < NCOLS - 3; x++) {
					if(Board[y, x] == -1) continue;
					if(Board[y, x] == Board[y+1, x+1] && Board[y, x] == Board[y+2, x+2] && Board[y, x] == Board[y+3, x+3]) {
						return true;
					}
				}
			}

			// Check diag 2
			for(int y = 3; y < NROWS; y++){
				for(int x = 0; x < NCOLS-3; x++) {
					if(Board[y, x] == -1) continue;
					if(Board[y, x] == Board[y-1, x+1] && Board[y, x] == Board[y-2, x+2] && Board[y, x] == Board[y-3, x+3]) {
						return true;
					}
				}
			}

			return false;

		}

		public void ShiftTurns() {
			if (Turn == Turn.P1) Turn = Turn.P2;
			else Turn = Turn.P1;

		}


	}
}
