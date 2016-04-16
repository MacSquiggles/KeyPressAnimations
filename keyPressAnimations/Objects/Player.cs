using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace keyPressAnimations
{
    class Player
    {
        //creates all properties needed to make the player
        public int x, y, size, speed, pimage;

        //creates an image array to hold the players image based on direction
        public Image[] images;

        public Player(int _x, int _y, int _size, int _speed, int _image)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            pimage = _image;
        }

        /// <summary>
        /// Moves the player in the desired direction and sets pimage equal to the 
        /// image the character should have
        /// </summary>
        /// <param name="p">the object player</param>
        /// <param name="direction"></param>
        public void move(Player p, string direction)
        {
            if (direction == "left")
                {
                    pimage = 1;
                    p.x -= p.speed;
                }
            else if (direction == "right")
            {
                pimage = 0;
                p.x += p.speed;
            }

            else if (direction == "up")
            {
                pimage = 2;
                p.y -= p.speed;
            }
           else if(direction == "down")
            {
                pimage = 3;
                    p.y += p.speed;
             }
            else
            {
                pimage = 2;

            }
        }

        /// <summary>
        /// draws rectangles around the player and monster and checks for collision
        /// </summary>
        /// <param name="p">the object player</param>
        /// <param name="m">the object monster</param>
        /// <returns></returns>
        public bool monsterCollision(Player p, Monster m)
        {
            Rectangle pRec = new Rectangle(p.x, p.y, 40, 40);
            Rectangle mRec = new Rectangle(m.x, m.y, 40, 40);
            if (pRec.IntersectsWith(mRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
