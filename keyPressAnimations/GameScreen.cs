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
        #region Variables, brushes and starting set up
        //initial starting points for player
        Player p = new Player(400, 300, 53, 8);
        Monster m = new Monster(100, 300, 53, 5);

        //Variables
        public static string title = "";
        public string direct = "";
        int bulletSpeed = 20;
        int bulletSize = 10;
        bool fireOK = true;

        //Brushes for the bullets
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        SolidBrush blueBrush = new SolidBrush(Color.RoyalBlue);
        SolidBrush greenBrush = new SolidBrush(Color.SeaGreen);
        SolidBrush monsterBrush = new SolidBrush(Color.Black);
        SolidBrush playerBrush = new SolidBrush(Color.Red);
        SolidBrush[] colours;

        //creates a random number
        Random rand = new Random();

        //determines whether a key is being pressed or not
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceArrowDown;

        //creates a list of bullets
        List<Bullet> bullets = new List<Bullet>();
        #endregion

        public GameScreen()
        {
            InitializeComponent();
            p.images = new Image[] { Properties.Resources.right, Properties.Resources.left, Properties.Resources.up, Properties.Resources.down };
            m.mImages = new Image[] { Properties.Resources.monster, Properties.Resources.monster2, Properties.Resources.monster3 };
            colours = new SolidBrush[] { purpleBrush, blueBrush, greenBrush };
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            this.Focus();
            //start the timer when the program starts
            gameTimer.Enabled = true;
            gameTimer.Start();
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
                case Keys.Space:
                    spaceArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region movePlayer
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
            if (p.y > m.y)
            {
                m.move(m, "down");
            }
            else
            {
                m.move(m, "up");
            }
            if (p.x > m.x)
            {
                m.move(m, "right");
            }
            else
            {
                m.move(m, "left");
            }
            #endregion

            #region moveBullet
            if (spaceArrowDown && fireOK == true)
            {
                Bullet b = new Bullet(p.x + (p.size/2), p.y + (p.size / 2), bulletSize, bulletSpeed, rand.Next(0, 3));
                bullets.Add(b);
                if (p.pimage == 0)
                {
                    direct = "right";
                }
                if (p.pimage == 1)
                {
                    direct = "left";
                }
                if (p.pimage == 2)
                {
                    direct = "up";
                }
                if (p.pimage == 3)
                {
                    direct = "down";
                }
               fireOK = false;
            }

            foreach (Bullet b in bullets)
            {
                if (b.y > this.Height)
                {
                    bullets.Remove(b);
                    fireOK = true;
                    break;
                }
                if (b.y < 0)
                {
                    bullets.Remove(b);
                    fireOK = true;
                    break;
                }
                if (b.x > this.Width)
                {
                    bullets.Remove(b);
                    fireOK = true;
                    break;
                }
                if (b.x < 0)
                {
                    bullets.Remove(b);
                    fireOK = true;
                    break;
                }
            }
            foreach (Bullet b in bullets)
            {
                b.move(b, direct);
            }
            #endregion

            #region collision
            foreach (Bullet b in bullets)
            {
                if (m.bulletCollision(m, b) == true)
                {
                    gameTimer.Enabled = false;
                    winGame();
                }
            }
            if (p.monsterCollision(p, m) == true)
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
            e.Graphics.DrawImage(p.images[p.pimage], p.x, p.y, p.size, p.size);
            e.Graphics.DrawImage(m.mImages[m.mimage], m.x, m.y, m.size, m.size);
        }

        private void endGame()
        {
            title = "You lose!!";
            EndScreen es = new EndScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            es.Location = new Point((f.Width - es.Width) / 2, (f.Height - es.Height) / 2);
            f.Controls.Add(es);
            es.BringToFront();
        }

        private void winGame()
        {
            title = "You win!!!!!!";
            EndScreen es = new EndScreen();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            es.Location = new Point((f.Width - es.Width) / 2, (f.Height - es.Height) / 2);
            f.Controls.Add(es);
            es.BringToFront();
        }

    }
}
