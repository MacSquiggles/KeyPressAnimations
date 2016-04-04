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
    public partial class GameScreen : UserControl
    {
        //initial starting points for player
        Player p = new Player(500, 400, 50, 4);
        Monster m = new Monster(200, 200, 50, 6);
        Image[] images;

        int i = 2;
        int bulletSpeed = 15;
        int bulletSize = 10;

        SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        SolidBrush blueBrush = new SolidBrush(Color.RoyalBlue);
        SolidBrush greenBrush = new SolidBrush(Color.SeaGreen);
        SolidBrush monsterBrush = new SolidBrush(Color.Black);
        SolidBrush playerBrush = new SolidBrush(Color.Red);
        SolidBrush[] colours;

        Random rand = new Random();

        //determines whether a key is being pressed or not
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;

        List<Bullet> bullets = new List<Bullet>();
        public GameScreen()
        {
            InitializeComponent();
            colours = new SolidBrush[] { purpleBrush, blueBrush, greenBrush };
            images = new Image[] { Properties.Resources.right, Properties.Resources.left, Properties.Resources.up, Properties.Resources.down };

        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            this.Focus();
            //start the timer when the program starts
            gameTimer.Enabled = true;
            gameTimer.Start();
            Bullet b = new Bullet(rand.Next(0, 300), 0, bulletSize, bulletSpeed, rand.Next(0, 3));
            bullets.Add(b);
        }
        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
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
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
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
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            //checks to see if any keys have been pressed and adjusts the X or Y value
            //for the rectangle appropriately
            if (leftArrowDown && p.x > 0)
            {
                i = 1;
                p.move(p, "left");
            }
            if (downArrowDown && p.y < this.Height)
            {
                i = 3;
                p.move(p, "down");
            }
            if (rightArrowDown && p.x < this.Width)
            {
                i = 0;
                p.move(p, "right");
            }
            if (upArrowDown && p.y > 0)
            {
                i = 2;
                p.move(p, "up");
            }
            else
            {
                i = 2;
            }

            foreach (Bullet b in bullets)
            {
                b.y += b.speed;
            }

            if (bullets[0].y > this.Height)
            {
                bullets.RemoveAt(0);
            }

            #region collision
            foreach (Bullet b in bullets)
            {
                if (b.bulletCollision(p, b) == true)
                {
                    gameTimer.Enabled = false;
                    endGame();
                }
            }
            if (m.monsterCollision(p, m) == true)
            {
                gameTimer.Enabled = false;
                endGame();
            }
            #endregion
            //refresh the screen, which causes the Form1_Paint method to run
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw rectangle to screen
            foreach (Bullet b in bullets)
            {
                e.Graphics.FillRectangle(colours[b.colour], b.x, b.y, b.size, b.size);
            }
            e.Graphics.DrawImage(images[i], p.x, p.y, p.size, p.size);
            e.Graphics.DrawImage(Properties.Resources.monster, m.x, m.y, m.size, m.size);
        }


        private void endGame()
        {
        EndScreen es = new EndScreen();
        Form f = this.FindForm();
        f.Controls.Remove(this);
            es.Location = new Point((f.Width - es.Width) / 2, (f.Height - es.Height) / 2);
            f.Controls.Add(es);
            es.BringToFront();
        }
       
    }
}
