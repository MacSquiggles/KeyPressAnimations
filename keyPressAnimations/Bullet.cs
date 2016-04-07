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
        public void move(Bullet b, string direction)
        {
            if (direction == "left")
            {
                b.x -= b.speed;
            }
            else if (direction == "right")
            {
                b.x += b.speed;
            }

            else if (direction == "up")
            {
                b.y -= b.speed;
            }
            else if (direction == "down")
            {
                b.y += b.speed;
            }
        }
       
    }
}
