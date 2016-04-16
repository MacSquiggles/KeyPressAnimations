using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/* Created by Quigley
 * to make a game in which the player has to avoid getting hit by a monster 
 * and kill it by firing bullets
 *April 10th 2016
 */

namespace keyPressAnimations
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Once the form loads it opens up the introduction form (main menu)
            IntroductionForm inf = new IntroductionForm();
            Form f = this.FindForm();
            inf.Location = new Point((f.Width - inf.Width) / 2, (f.Height - inf.Height) / 2);
            f.Controls.Add(inf);
            inf.BringToFront();
        }

    }

}
