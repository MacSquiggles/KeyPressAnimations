using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace keyPressAnimations
{
    class Monster
    {
        //Creates all of the properties needed to make monster
        public int x, y, size, speed, mimage;

        //creats an image array to hold a image for each direction
        public Image[] mImages;

        public Monster(int _x, int _y, int _size, int _speed, int _image)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            mimage = _image;
        }

        /// <summary>
        /// Moves the monster based on the players position and changes the 
        /// monster image accordingly
        /// </summary>
        /// <param name="m">the object monster</param>
        /// <param name="direction">tells the monster what direction to move</param>
        public void move(Monster m, string direction)
        {
            if (direction == "left")
            {
                mimage = 1;
                m.x -= m.speed;
            }
            else if (direction == "right")
            {
                mimage = 0;
                m.x += m.speed;
            }

            else if (direction == "up")
            {
                mimage = 2;
                m.y -= m.speed;
            }
            else if (direction == "down")
            {
                mimage = 3;
                m.y += m.speed;
            }
            else
            {
                mimage = 2;
            }
        }
        public bool bulletCollision(Monster m, Bullet b)
        {
            Rectangle pRec = new Rectangle(m.x, m.y, 40, 40);
            Rectangle bRec = new Rectangle(b.x, b.y, b.size, b.size);
            if (pRec.IntersectsWith(bRec))
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
