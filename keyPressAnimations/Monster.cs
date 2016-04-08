using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace keyPressAnimations
{
    class Monster
    {
        public int x, y, size, speed, mimage;
        public Image[] mImages;

        public Monster(int _x, int _y, int _size, int _speed, int _image)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            mimage = _image;
        }
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
