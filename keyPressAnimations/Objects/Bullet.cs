using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace keyPressAnimations
{
    class Bullet
    {
        //Creates all properties needed to make the bullet
        public int x, y, size, speed, colour;
        public string direction;

        public Bullet(int _x, int _y, int _size, int _speed, int _colour, string _direction)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            colour = _colour;
            direction = _direction;
        }

        /// <summary>
        /// Moves the bullet across the screen in the direction the user fired
        /// </summary>
        /// <param name="b">the bullet in the list of bullets</param>
        public void move(Bullet b)
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
