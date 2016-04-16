using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace keyPressAnimations
{
    public partial class EndScreen : UserControl
    {
        public EndScreen()
        {
            InitializeComponent();
        }

        private void EndScreen_Load(object sender, EventArgs e)
        {
            //When the user control loads, the title will be chosen based on if the user
            //has won or lost the game to "You Win!!!" or "You Lose!!!" and the users score
            gameOverLabel.Text = GameScreen.title;
        } 

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            //Will open the game screen if they want to play again
            GameScreen gs = new GameScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            gs.Location = new Point((f.Width - gs.Width) / 2, (f.Height - gs.Height) / 2);
            f.Controls.Add(gs);
            gs.BringToFront();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Will exit the game if the user clicks on the exit button
            Application.Exit();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            //Will open the main menu or introduction form if the user clicks the main menu button
            IntroductionForm inf = new IntroductionForm();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            inf.Location = new Point((f.Width - inf.Width) / 2, (f.Height - inf.Height) / 2);
            f.Controls.Add(inf);
            inf.BringToFront();
        }
    }
}
