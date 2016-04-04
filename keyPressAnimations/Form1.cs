using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/* Created by Mr. T
 * to demonstrate how to use key presses to control the animation
 * of an object on screen
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
            IntroductionForm inf = new IntroductionForm();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            inf.Location = new Point((f.Width - inf.Width) / 2, (f.Height - inf.Height) / 2);
            f.Controls.Add(inf);
            inf.BringToFront();
        }

    }

}
