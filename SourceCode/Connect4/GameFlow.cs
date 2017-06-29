using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameLogic {
	public enum PlayerType { Player, CPURandom, CPUSmart }

	public class GameFlow {
		public Game Game { get; }

		public PlayerType P1;
		public PlayerType P2;

		public event Action<Turn> ThereIsAWinner;
        public event Action Draw;

		private Random random;

		/// <summary>
		/// Default is PvP
		/// </summary>
		public GameFlow() {
			Game = new Game();
			ResetGame(PlayerType.Player, PlayerType.CPUSmart);
			random = new Random(); // http://stackoverflow.com/questions/767999/random-number-generator-only-generating-one-random-number
		}

		public GameFlow(Game game, PlayerType p1, PlayerType p2) {
			Game = new Game();
			Game = game;
			ResetGame(p1, p2);
		}

		public void ResetGame() {
			Game.ResetGame();
		}

		public void ResetGame(PlayerType p1, PlayerType p2) {
			Game.ResetGame();
			P1 = p1;
			P2 = p2;
		}

		/// <summary>
		/// Let CPU make a move if it's his turn
		/// </summary>
		public void Continue() {
			if( (Game.Turn == Turn.P1 && P1 == PlayerType.CPURandom) || (Game.Turn == Turn.P2 && P2 == PlayerType.CPURandom) ) {
				Game.MakeMove(random.Next(0, Game.NCOLS));

				if (Game.DetectWinner()) {
					if (ThereIsAWinner != null) ThereIsAWinner(Game.Turn);
					return;
				}
                else if(Game.DetectDraw()) {
                    if (Draw != null) Draw();
                    return;
                }
				else Game.ShiftTurns();
			}

            else if( (Game.Turn == Turn.P1 && P1 == PlayerType.CPUSmart) || (Game.Turn == Turn.P2 && P2 == PlayerType.CPUSmart)) {
                MasterMindMoveMaker m = new MasterMindMoveMaker();
                Game.MakeMove(m.GetSmartMove(Game));

                if (Game.DetectWinner()) {
                    if (ThereIsAWinner != null) ThereIsAWinner(Game.Turn);
                    return;
                }
                else if (Game.DetectDraw()) {
                    if (Draw != null)
                        Draw();
                    return;
                }
                else Game.ShiftTurns();
            }
			

		}

		public void PlayerMove(int col) {
			if( (Game.Turn == Turn.P1 && P1 == PlayerType.Player) || (Game.Turn == Turn.P2 && P2 == PlayerType.Player) ) {
				Game.MakeMove(col);

				if (Game.DetectWinner()) {
					if (ThereIsAWinner != null) ThereIsAWinner(Game.Turn);
				}
                else if (Game.DetectDraw()) {
                    if (Draw != null)
                        Draw();
                    return;
                }
                else Game.ShiftTurns();

			}
		}

	}
}
