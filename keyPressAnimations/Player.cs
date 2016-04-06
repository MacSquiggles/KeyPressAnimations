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
        public int i = 2;
        Image[] images;

        public Player(int _x, int _y, int _size, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            images = new Image[] { Properties.Resources.right, Properties.Resources.left, Properties.Resources.up, Properties.Resources.down };
        }
        public void move(Player p, string direction)
        {
            if (direction == "left")
                {
                    i = 1;
                    p.x -= p.speed;
                }
            else if (direction == "right")
            {
                i = 0;
                p.x += p.speed;
            }

            else if (direction == "up")
            {
                i = 2;
                p.y -= p.speed;
            }
           else if(direction == "down")
            {
                i = 3;
                    p.y += p.speed;
             }
            else
            {
                i = 2;

            }
        }
    }
}
