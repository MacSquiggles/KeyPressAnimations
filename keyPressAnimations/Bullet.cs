using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace keyPressAnimations
{
    class Bullet
    {
        public int x, y, size, speed, colour;

        public Bullet(int _x, int _y, int _size, int _speed, int _colour)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            colour = _colour;
        }
        public bool bulletCollision(Player p, Bullet b)
        {
            Rectangle pRec = new Rectangle(p.x, p.y, p.size, p.size);
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
