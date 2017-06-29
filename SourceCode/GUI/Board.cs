using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI {
	public partial class Board : UserControl {
		public int NCOLS { get; set; }
		public int NROWS { get; set; }

		public int[,] GameBoard { get; set; }


		public Board() {
			NCOLS = 7;
			NROWS = 6;

			ResetBoard();
		}

		public void ResetBoard() {
			GameBoard = new int[NROWS, NCOLS];

			for (int y = 0; y < NROWS; y++) {
				for (int x = 0; x < NCOLS; x++) {
					GameBoard[y, x] = -1;
				}
			}

			this.Invalidate();
		}
		

		public void DrawDiscs(Graphics g) {
			if(GameBoard == null) return; // Just to fix designer display issue

			SolidBrush b1 = new SolidBrush(Color.Red);
			SolidBrush b2 = new SolidBrush(Color.Yellow);

			int ColWidth = this.Width/NCOLS;
			int ColHeight = this.Height/NROWS;

			// Draw discs
			for (int y = 0; y < NROWS; y++) {
				for (int x = 0; x < NCOLS; x++) {
					if(GameBoard[y, x] == -1) continue;

					if(GameBoard[y, x] == 1) {
						g.FillEllipse(b1, x*ColWidth+5, y*ColHeight+5, ColWidth-10, ColHeight-10);
						continue;
					}

					else if(GameBoard[y, x] == 2) {
						g.FillEllipse(b2, x * ColWidth+5, y * ColHeight+5, ColWidth-10, ColHeight-10);
						continue;
					}
				}

			}


		}

		public void DrawGrid(Graphics g) {
			Pen p = new Pen(Color.Gray);
			
			for(int x = 0; x < (this.Width/NCOLS) * NCOLS; x+=this.Width/NCOLS) {
				g.DrawLine(p, new Point(x, 0), new Point(x, this.Height));
			}

			for(int y = 0; y < (this.Height/NROWS) * NROWS; y+=this.Height/NROWS) {
				g.DrawLine(p, new Point(0, y), new Point(this.Width, y));
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			Graphics g = e.Graphics;
			
			DrawGrid(g);
			DrawDiscs(g);

		}

	}
}
