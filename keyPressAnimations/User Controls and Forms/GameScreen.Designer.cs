﻿namespace keyPressAnimations
{
    partial class GameScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sarcasmLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sarcasmLabel
            // 
            this.sarcasmLabel.BackColor = System.Drawing.Color.Transparent;
            this.sarcasmLabel.Font = new System.Drawing.Font("Segoe Script", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sarcasmLabel.Location = new System.Drawing.Point(-1, 163);
            this.sarcasmLabel.Name = "sarcasmLabel";
            this.sarcasmLabel.Size = new System.Drawing.Size(900, 131);
            this.sarcasmLabel.TabIndex = 0;
            this.sarcasmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Pristina", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(3, 451);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(78, 37);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Score:";
            // 
            // GameScreen
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.sarcasmLabel);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(898, 488);
            this.Load += new System.EventHandler(this.GameScreen_Load_1);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint_1);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp_1);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label sarcasmLabel;
        private System.Windows.Forms.Label scoreLabel;
    }
}
