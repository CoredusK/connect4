namespace GUI {
	partial class AppGUI {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.btnPvP = new System.Windows.Forms.Button();
            this.btnPvRCPU = new System.Windows.Forms.Button();
            this.btnRCPUvRCPU = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSCPUvsSCPU = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSCPUvCsRCPU = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbFastCPUMoves = new System.Windows.Forms.CheckBox();
            this.gameBoard = new GUI.Board();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPvP
            // 
            this.btnPvP.Location = new System.Drawing.Point(6, 28);
            this.btnPvP.Name = "btnPvP";
            this.btnPvP.Size = new System.Drawing.Size(152, 27);
            this.btnPvP.TabIndex = 3;
            this.btnPvP.Text = "P1 vs P2";
            this.btnPvP.UseVisualStyleBackColor = true;
            this.btnPvP.Click += new System.EventHandler(this.btnPvP_Click);
            // 
            // btnPvRCPU
            // 
            this.btnPvRCPU.Location = new System.Drawing.Point(6, 28);
            this.btnPvRCPU.Name = "btnPvRCPU";
            this.btnPvRCPU.Size = new System.Drawing.Size(152, 27);
            this.btnPvRCPU.TabIndex = 4;
            this.btnPvRCPU.Text = "P1 vs RCPU";
            this.btnPvRCPU.UseVisualStyleBackColor = true;
            this.btnPvRCPU.Click += new System.EventHandler(this.btnPvRCPU_Click);
            // 
            // btnRCPUvRCPU
            // 
            this.btnRCPUvRCPU.Location = new System.Drawing.Point(6, 61);
            this.btnRCPUvRCPU.Name = "btnRCPUvRCPU";
            this.btnRCPUvRCPU.Size = new System.Drawing.Size(152, 27);
            this.btnRCPUvRCPU.TabIndex = 5;
            this.btnRCPUvRCPU.Text = "RCPU vs RCPU";
            this.btnRCPUvRCPU.UseVisualStyleBackColor = true;
            this.btnRCPUvRCPU.Click += new System.EventHandler(this.btnRCPUvRCPU_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 27);
            this.button4.TabIndex = 6;
            this.button4.Text = "P1 vs SCPU";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnSCPUvsSCPU
            // 
            this.btnSCPUvsSCPU.Location = new System.Drawing.Point(6, 61);
            this.btnSCPUvsSCPU.Name = "btnSCPUvsSCPU";
            this.btnSCPUvsSCPU.Size = new System.Drawing.Size(151, 27);
            this.btnSCPUvsSCPU.TabIndex = 11;
            this.btnSCPUvsSCPU.Text = "SCPU vs SCPU";
            this.btnSCPUvsSCPU.UseVisualStyleBackColor = true;
            this.btnSCPUvsSCPU.Click += new System.EventHandler(this.btnSCPUvsSCPU_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPvP);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 64);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player vs Player                        You vs a friend";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPvRCPU);
            this.groupBox2.Controls.Add(this.btnRCPUvRCPU);
            this.groupBox2.Location = new System.Drawing.Point(346, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 96);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Random CPU (RCPU)   Maybe you can win";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.btnSCPUvsSCPU);
            this.groupBox3.Location = new System.Drawing.Point(174, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 96);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Smart CPU (SCPU)             You think you can handle it?";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSCPUvCsRCPU);
            this.groupBox4.Location = new System.Drawing.Point(517, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(165, 64);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Smart vs Random                 The AI Challenge";
            // 
            // btnSCPUvCsRCPU
            // 
            this.btnSCPUvCsRCPU.Location = new System.Drawing.Point(6, 28);
            this.btnSCPUvCsRCPU.Name = "btnSCPUvCsRCPU";
            this.btnSCPUvCsRCPU.Size = new System.Drawing.Size(152, 27);
            this.btnSCPUvCsRCPU.TabIndex = 7;
            this.btnSCPUvCsRCPU.Text = "SCPU vs RCPU";
            this.btnSCPUvCsRCPU.UseVisualStyleBackColor = true;
            this.btnSCPUvCsRCPU.Click += new System.EventHandler(this.btnSCPUvCsRCPU_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbFastCPUMoves);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 118);
            this.panel2.TabIndex = 17;
            // 
            // cbFastCPUMoves
            // 
            this.cbFastCPUMoves.AutoSize = true;
            this.cbFastCPUMoves.Location = new System.Drawing.Point(523, 74);
            this.cbFastCPUMoves.Name = "cbFastCPUMoves";
            this.cbFastCPUMoves.Size = new System.Drawing.Size(106, 17);
            this.cbFastCPUMoves.TabIndex = 16;
            this.cbFastCPUMoves.Text = "Fast CPU Moves";
            this.cbFastCPUMoves.UseVisualStyleBackColor = true;
            // 
            // gameBoard
            // 
            this.gameBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameBoard.GameBoard = null;
            this.gameBoard.Location = new System.Drawing.Point(0, 118);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.NCOLS = 7;
            this.gameBoard.NROWS = 6;
            this.gameBoard.Size = new System.Drawing.Size(693, 526);
            this.gameBoard.TabIndex = 2;
            this.gameBoard.SizeChanged += new System.EventHandler(this.gameBoard_SizeChanged);
            this.gameBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gameBoard_MouseUp);
            // 
            // AppGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 644);
            this.Controls.Add(this.gameBoard);
            this.Controls.Add(this.panel2);
            this.Name = "AppGUI";
            this.Text = "Connect 4";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AppGUI_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private Board gameBoard;
		private System.Windows.Forms.Button btnPvP;
		private System.Windows.Forms.Button btnPvRCPU;
		private System.Windows.Forms.Button btnRCPUvRCPU;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button btnSCPUvsSCPU;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnSCPUvCsRCPU;
		private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbFastCPUMoves;
    }
}

