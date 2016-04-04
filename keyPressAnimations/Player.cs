using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace keyPressAnimations
{
    class Player
    {
        public int x, y, size, speed;

        public Player(int _x, int _y, int _size, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
        }
        public void move(Player p, string direction)
        {
            if (direction == "left")
                {
                    p.x -= p.speed;
                }
            else if (direction == "right")
            {
                p.x += p.speed;
            }

            else if (direction == "up")
            {
                p.y -= p.speed;
            }
           else if(direction == "down")
            {
                    p.y += p.speed;
             }
        }
    }
}
