using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace keyPressAnimations
{
    public partial class GameScreen : UserControl
    {
        #region Variables, brushes and starting set up

        //Variables
        public static string title = "";
        int bulletSpeed = 20;
        int bulletSize = 10;
        public int score = 10;
        bool fireOK = true;

        //determines whether a key is being pressed or not
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceArrowDown;

        //Brushes to be used to draw the bullets
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        SolidBrush blueBrush = new SolidBrush(Color.RoyalBlue);
        SolidBrush greenBrush = new SolidBrush(Color.SeaGreen);
        SolidBrush monsterBrush = new SolidBrush(Color.Black);
        SolidBrush playerBrush = new SolidBrush(Color.Red);

        //arrays created
        string[] directionList;
        string[] saying;
        SolidBrush[] colours;

        //creates a random number
        public Random rand = new Random();

        //creates a list of bullets
        List<Bullet> bullets = new List<Bullet>();

        //initial starting points for player
        Player p = new Player(400, 400, 53, 8, 2);
        Monster m = new Monster(10, 15, 53, 4, 2);
        #endregion

        public GameScreen()
        {
            InitializeComponent();

            #region Array Values
            //Adds all values int their according arrays
            p.images = new Image[] { Properties.Resources.right, Properties.Resources.left, Properties.Resources.up, Properties.Resources.down };
            m.mImages = new Image[] { Properties.Resources.monRight, Properties.Resources.monLeft, Properties.Resources.monUp, Properties.Resources.mondown };
            saying = new string[] { "That yellow really compliments... \nYOUR FACE", "Kindness is blindness", "It's been such a pleasure....", "Hope to see you again...\nNOT", "There was something on your face... \nIt was PAIN" };
            colours = new SolidBrush[] { purpleBrush, blueBrush, greenBrush };
            directionList = new string[] {"right", "left", "up", "down"};
            #endregion
        }


        private void GameScreen_Load_1(object sender, EventArgs e)
        {
            this.Focus();
            //start the timer when the program starts
            timer1.Enabled = true;
            timer1.Start();
        }

        private void GameScreen_KeyUp_1(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Space:
                    spaceArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Space:
                    spaceArrowDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_Paint_1(object sender, PaintEventArgs e)
        {
            //draws the bullets, monster and player to screen
            foreach (Bullet b in bullets)
            {
                e.Graphics.FillRectangle(colours[b.colour], b.x, b.y, b.size, b.size);
            }
                e.Graphics.DrawImage(p.images[p.pimage], p.x, p.y, p.size, p.size);
                e.Graphics.DrawImage(m.mImages[m.mimage], m.x, m.y, m.size, m.size);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region movePlayer
            //Moves the player based on which arrow key is pressed
            if (leftArrowDown && p.x > 0)
            {
                p.move(p, "left");
            }
            if (downArrowDown && p.y < this.Height - p.size)
            {
                p.move(p, "down");
            }
            if (rightArrowDown && p.x < this.Width - p.size)
            {
                p.move(p, "right");
            }
            if (upArrowDown && p.y > 0)
            {
                p.move(p, "up");
            }
            #endregion

            #region moveMonster
            //Moves the monster according to its position compaired to the player position
            if (p.y > m.y)
            {
                m.move(m, directionList[3]);
            }
            else
            {
                m.move(m, directionList[2]);
            }
            if (p.x > m.x)
            {
                m.move(m, directionList[0]);
            }
            else
            {
                m.move(m, directionList[1]);
            }
            #endregion

            #region moveBullet
            //Will shoot a bullet if no more bullets are on screen and the space button is pressed
            if (spaceArrowDown && fireOK == true)
            {
                    Bullet b = new Bullet(p.x + (p.size / 2), p.y + (p.size / 2), bulletSize, bulletSpeed, rand.Next(0, 3), directionList[p.pimage]);
                    bullets.Add(b);
                    fireOK = false;
            }

            //Keeps the bullet moving in its assigned direction until it is off screen, then it is removed
            //and the ability to fire is given once again, and you lose a point for firing and missing. (fireOK = true)
            foreach (Bullet b in bullets)
            {
                b.move(b);

                if (b.y > this.Height || b.y < 0 || b.x > this.Width || b.x < 0)
                {
                    bullets.Remove(b);
                    fireOK = true;
                    score--;
                    break;
                }
            }

            #endregion

            #region collision
            //Checks to see if the bullet hits the monster and if so disables the timer and runs winGame
            foreach (Bullet b in bullets)
            {
                if (m.bulletCollision(m, b) == true)
                {
                    timer1.Enabled = false;
                    winGame();
                }
            }

            //checks to see if the monster hit the player and if so disables the timer and runs endGame
            if (p.monsterCollision(p, m) == true)
            {
                timer1.Enabled = false;
                endGame();
            }
            #endregion

            //refresh the screen, shows the new score, and causes the Form1_Paint method to run
            scoreLabel.Text = "Score: " + score;
            Refresh();
        }

        #region Game Over
        /// <summary>
        /// If you lose, the end screen will open and print "You Lose!!!"
        /// </summary>
        private void endGame()
        {
            title = "You Lose!!" + "\n Your score: " + score;
            EndScreen es = new EndScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            es.Location = new Point((f.Width - es.Width) / 2, (f.Height - es.Height) / 2);
            f.Controls.Add(es);
            es.BringToFront();
        }

        /// <summary>
        /// If you win, a sarcastic saying will appear and the 
        /// end screen will open and print "You Win!!!"
        /// </summary>
        private void winGame()
        {
            sarcasmLabel.Text = saying[rand.Next(0, 4)];
            Refresh();
            Thread.Sleep(2000);
            title = "You Win!!!!!!" + "\nYour Score: " + score;
            EndScreen es = new EndScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            es.Location = new Point((f.Width - es.Width) / 2, (f.Height - es.Height) / 2);
            f.Controls.Add(es);
            es.BringToFront();
        }
        #endregion

    }
}
