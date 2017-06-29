using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic {
	public class MasterMindMoveMaker {

        public MasterMindMoveMaker() {
           
        }
		
        /// <summary>
        /// Get a game in a current state and do an intelligent move
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public int GetSmartMove(Game game) {
			Dictionary<int, List<int>> MoveAndItsEvaluation = new Dictionary<int, List<int>>(); // Attempted move (column) and its value results (its score)

			for (int n1 = 0; n1 < Game.NCOLS; n1++) {
				MoveAndItsEvaluation.Add(n1, new List<int>());

				// Reset state to game.Board
				Game attempt = new Game();
				Array.Copy(game.Board, attempt.Board, game.Board.Length);
				attempt.Turn = game.Turn;

				int cpuValue = 100; // Base value for CPU

                // A full column would be the worst move
                if (!attempt.ColHasSpace(n1)) {
                    cpuValue = -1000000;
                }           

				attempt.MakeMove(n1);

				// Evaluate it
				if (attempt.DetectWinner()) cpuValue += 100000; // We will win with this move
				cpuValue += 50 * Detect3(attempt);
				cpuValue += 15 * Detect2(attempt);

				attempt.ShiftTurns();
				
				for(int n2 = 0; n2 < Game.NCOLS; n2++) {
					// From this situation, calculate the best move player can make, on top of the attempt.MakeMove
					// Reset state to attempt.Board
					Game playerAttempt = new Game();
					Array.Copy(attempt.Board, playerAttempt.Board, attempt.Board.Length);
					playerAttempt.Turn = attempt.Turn;
					
					int playerValue = 100;	// Same base value for Player
					playerAttempt.MakeMove(n2);

					// Evaluate it
					if (playerAttempt.DetectWinner()) playerValue += 5000; // He will win this one, worth less than CPU win because it's his turn
					playerValue += 50 * Detect3(playerAttempt);
					playerValue += 15 * Detect2(playerAttempt);

					// Compare cpu value to player value and store it in Dict
					int realValue = cpuValue - playerValue;
					MoveAndItsEvaluation[n1].Add(realValue);
				}

			}

			int[] sums = new int[Game.NCOLS];

			// Make sum of all evaluations for moves - the highest result is the best move
			foreach(KeyValuePair<int, List<int>> kvp in MoveAndItsEvaluation) {
				for(int i = 0 ; i < kvp.Value.Count; i++) {
					sums[kvp.Key] += kvp.Value.ElementAt(i);
				}
			}

			int biggest = sums.Max();
			
			// Get all equally good moves
			List<int> bestMoves = new List<int>();
			for(int i=0; i < sums.Length; i++) {
				if(sums[i] == biggest) bestMoves.Add(i);
			}

			int aBestMove = bestMoves[new Random().Next(0, bestMoves.Count)]; // One random move of equally good moves, to have less stale AI
            return aBestMove;		
        }

		/// <summary>
		/// Returns the winning move, or -1 if there isn't one - Deprecated
		/// </summary>
		/// <param name="game"></param>
		/// <returns></returns>
        private int GetWinningMove(Game game) {
            Game attempt = new Game();        
            Array.Copy(game.Board, attempt.Board, game.Board.Length);

            for (int x = 0; x < Game.NCOLS; x++) {
                // Reset board & turn  
                Array.Copy(game.Board, attempt.Board, game.Board.Length);                  
                attempt.Turn = game.Turn;

                // And try a row & see if it wins
                attempt.MakeMove(x);
                if (attempt.DetectWinner())
                    return x;
            }

            return -1;
        }

		/// <summary>
		/// Returns the amount of open "3 in a rows" there are on the board for the current player
		/// </summary>
		/// <param name="game">The current Board of this game will be analyzed</param>
		/// <returns>Amount of times an open 3 in a row is on the board for current player</returns>
		private int Detect3(Game game) {
			int count = 0;
			Turn turn = game.Turn;

			// Check horizontal
			for (int y = 0; y < Game.NROWS; y++) {
				// Detect 3 with open right 
				for (int x = 0; x < Game.NCOLS - 3; x++) {
					if(game.Board[y, x] != (int)turn) continue;	// Don't check opponent or empty squares
					
					// Find 3 in a row
					if ( game.Board[y, x] == game.Board[y, x + 1] && game.Board[y, x] == game.Board[y, x + 2]
						&&
						(game.Board[y, x + 3] == -1) ) {	// Find open right
						count++;
					}
				}

				// Detect 3 with open left
				for(int x = 1; x < Game.NCOLS - 2; x++) {
					if(game.Board[y, x] != (int)turn) continue;	// Don't check opponent or empty squares

					// Find 3 in a row
					if (game.Board[y, x] == game.Board[y, x + 1] && game.Board[y, x] == game.Board[y, x + 2]
						&&
						(game.Board[y, x - 1] == -1)) { // Find open left
						count++;
					}

				}
			}

			// Check vertical (open bottom cannot exist)
			for(int y = 1; y < Game.NROWS - 2; y++) {
				for(int x = 0; x < Game.NCOLS; x++) {
					if(game.Board[y,x] != (int)turn) continue; // Don't check opponent or empty squares

					if (game.Board[y, x] == game.Board[y + 1, x] && game.Board[y, x] == game.Board[y + 2, x] &&
						(game.Board[y-1, x] == -1)) { // Open top
						count++;
					}
				}
			}

			// Check diag 1 [\]
			for (int y = 0; y < Game.NROWS - 3; y++) {
				for (int x = 0; x < Game.NCOLS - 3; x++) {
					if (game.Board[y, x] != (int) turn) continue; // Don't check opponent or empty squares

					if (game.Board[y, x] == game.Board[y + 1, x + 1] && game.Board[y, x] == game.Board[y + 2, x + 2]
						&& game.Board[y + 3, x + 3] == -1) {
						count++;
					}
				}
			}
			for (int y = 1; y < Game.NROWS - 3; y++) {
				for (int x = 1; x < Game.NCOLS - 3; x++) {
					if (game.Board[y, x] != (int)turn) continue; // Don't check opponent or empty squares

					if (game.Board[y, x] == game.Board[y + 1, x + 1] && game.Board[y, x] == game.Board[y + 2, x + 2]
						&& game.Board[y - 1, x - 1] == -1) {
						count++;
					}
				}
			}


			// Check diag 2 [/]
			for (int y = 3; y < Game.NROWS; y++) {
				for (int x = 0; x < Game.NCOLS-3; x++) {
					if (game.Board[y, x] != (int) turn) continue; // Don't check opponent or empty squares
					if (game.Board[y, x] == game.Board[y - 1, x + 1] && game.Board[y, x] == game.Board[y - 2, x + 2] 
						&& game.Board[y - 3, x + 3] == -1) {
						count++;
					}
				}
			}
			for (int y = 3; y < Game.NROWS - 1; y++) {
				for (int x = 1; x < Game.NCOLS - 2; x++) {
					if (game.Board[y, x] != (int)turn) continue; // Don't check opponent or empty squares
					if (game.Board[y, x] == game.Board[y-1, x+1] && game.Board[y, x] == game.Board[y-2, x+2]
						&& game.Board[y+1, x-1] == -1) {
						count++;
					}
				}
			}

			return count;

		}

		/// <summary>
		/// Detects open "2 in a rows"
		/// </summary>
		/// <param name="game"></param>
		/// <returns>Amount of times 2 in a row with open ends is on board for current player</returns>
		private int Detect2(Game game) {
			int count = 0;
			Turn turn = game.Turn;

			// Check horizontal
			for (int y = 0; y < Game.NROWS; y++) {
				// Detect 3 with open right 
				for (int x = 0; x < Game.NCOLS - 2; x++) {
					if (game.Board[y, x] != (int)turn) continue;    // Don't check opponent or empty squares

					// Find 3 in a row
					if (game.Board[y, x] == game.Board[y, x + 1]
						&& game.Board[y, x + 2] == -1) { // Find open right
						count++;
					}
				}

				// Detect 3 with open left
				for (int x = 1; x < Game.NCOLS - 1; x++) {
					if (game.Board[y, x] != (int)turn) continue;    // Don't check opponent or empty squares
																	// Find 3 in a row
					if (game.Board[y, x] == game.Board[y, x + 1]
						&& game.Board[y, x - 1] == -1) { // Find open left
						count++;
					}

				}
			}

			// Check vertical (open bottom cannot exist)
			for (int y = 1; y < Game.NROWS - 1; y++) {
				for (int x = 0; x < Game.NCOLS; x++) {
					if (game.Board[y, x] != (int)turn) continue; // Don't check opponent or empty squares

					if (game.Board[y, x] == game.Board[y + 1, x] 
						&& game.Board[y - 1, x] == -1) { // Open top
						count++;
					}
				}
			}

			// Check diag 1 [\]
			for (int y = 0; y < Game.NROWS - 2; y++) {
				for (int x = 0; x < Game.NCOLS - 2; x++) {
					if (game.Board[y, x] != (int)turn) continue; // Don't check opponent or empty squares

					if (game.Board[y, x] == game.Board[y + 1, x + 1]
						&& game.Board[y + 2, x + 2] == -1) {
						count++;
					}
				}
			}
			for (int y = 1; y < Game.NROWS - 1; y++) {
				for (int x = 1; x < Game.NCOLS - 1; x++) {
					if (game.Board[y, x] != (int)turn) continue; // Don't check opponent or empty squares

					if (game.Board[y, x] == game.Board[y + 1, x + 1] 
						&& game.Board[y - 1, x - 1] == -1) {
						count++;
					}
				}
			}


			// Check diag 2 [/]
			for (int y = 2; y < Game.NROWS; y++) {
				for (int x = 0; x < Game.NCOLS-2; x++) {
					if (game.Board[y, x] != (int)turn) continue; // Don't check opponent or empty squares
					if (game.Board[y, x] == game.Board[y - 1, x + 1] 
						&& game.Board[y - 2, x + 2] == -1) {
						count++;
					}
				}
			}
			for (int y = 1; y < Game.NROWS - 1; y++) {
				for (int x = 1; x < Game.NCOLS-1; x++) {
					if (game.Board[y, x] != (int)turn) continue; // Don't check opponent or empty squares
					if (game.Board[y, x] == game.Board[y - 1, x + 1]
						&& game.Board[y + 1, x - 1] == -1) {
						count++;
					}
				}
			}

			return count;
		}



	}
}
