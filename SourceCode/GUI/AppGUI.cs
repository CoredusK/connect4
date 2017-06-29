using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;
using System.Threading;

namespace GUI {
	public partial class AppGUI : Form {
	
		GameFlow GameFlow;

		public AppGUI() {
			GameFlow = new GameFlow();
			GameFlow.ThereIsAWinner += Game_ThereIsAWinner;
            GameFlow.Draw += GameFlow_Draw;
			InitializeComponent();
		}

        private void GameFlow_Draw() {
            // Draw winning board before ending game
            gameBoard.GameBoard = GameFlow.Game.Board;
            gameBoard.Invalidate();

            MessageBox.Show("Draw! Nobody wins...", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void Game_ThereIsAWinner(Turn obj) {
			// Draw winning board before ending game
			gameBoard.GameBoard = GameFlow.Game.Board;
			gameBoard.Invalidate();

			MessageBox.Show(GameFlow.Game.Turn.ToString() + " wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}



		private async void gameBoard_MouseUp(object sender, MouseEventArgs e) {
			int ColWidth = gameBoard.Width / gameBoard.NCOLS;
			int ColClicked;

			// Detect in which col is clicked
			for(int n = 0; n < gameBoard.Width; n += ColWidth) {
				if(e.X > n && e.X < n + ColWidth) {
					ColClicked = n/ColWidth;
	
					GameFlow.PlayerMove(ColClicked);

					gameBoard.GameBoard = GameFlow.Game.Board;
					gameBoard.Invalidate();
				}
			}

            // Fake CPU 'thinking'
            if(!cbFastCPUMoves.Checked) await Task.Delay(new Random().Next(500, 1000));

            GameFlow.Continue();
            gameBoard.Refresh();
        }

		private void AppGUI_Paint(object sender, PaintEventArgs e) {
			gameBoard.Invalidate();
		}

		private void gameBoard_SizeChanged(object sender, EventArgs e) {
			this.Invalidate();
		}

		private void btnPvP_Click(object sender, EventArgs e) {
			GameFlow.ResetGame(PlayerType.Player, PlayerType.Player);
			gameBoard.ResetBoard();
			this.Invalidate();
		}

		private void btnPvRCPU_Click(object sender, EventArgs e) {
			GameFlow.ResetGame(PlayerType.Player, PlayerType.CPURandom);
			gameBoard.ResetBoard();
			this.Invalidate();
		}

		private async void btnRCPUvRCPU_Click(object sender, EventArgs e) {
			GameFlow.ResetGame(PlayerType.CPURandom, PlayerType.CPURandom);
			gameBoard.ResetBoard();
			
			while(!GameFlow.Game.DetectWinner() && !GameFlow.Game.DetectDraw()) {
				if(!cbFastCPUMoves.Checked) await Task.Delay(new Random().Next(500, 1000));
				GameFlow.Continue();
				gameBoard.GameBoard = GameFlow.Game.Board;
				gameBoard.Invalidate();
			}

		}

		private void button4_Click(object sender, EventArgs e) {
            GameFlow.ResetGame(PlayerType.Player, PlayerType.CPUSmart);
            gameBoard.ResetBoard();
		}

		private async void btnSCPUvsSCPU_Click(object sender, EventArgs e) {
			GameFlow.ResetGame(PlayerType.CPUSmart, PlayerType.CPUSmart);
			gameBoard.ResetBoard();

			while (!GameFlow.Game.DetectWinner() && !GameFlow.Game.DetectDraw()) {
                if (!cbFastCPUMoves.Checked) await Task.Delay(new Random().Next(500, 1000));
				GameFlow.Continue();
				gameBoard.GameBoard = GameFlow.Game.Board;
				gameBoard.Invalidate();
			}
		}

		private async void btnSCPUvCsRCPU_Click(object sender, EventArgs e) {
			GameFlow.ResetGame(PlayerType.CPUSmart, PlayerType.CPURandom);
			gameBoard.ResetBoard();

			while (!GameFlow.Game.DetectWinner() && !GameFlow.Game.DetectDraw()) {
                if (!cbFastCPUMoves.Checked) await Task.Delay(new Random().Next(800, 1800));
				GameFlow.Continue();
				gameBoard.GameBoard = GameFlow.Game.Board;
				gameBoard.Invalidate();
			}
		}

	}
}
