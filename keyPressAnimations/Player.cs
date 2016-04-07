using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace keyPressAnimations
{
    class Player
    {
        public int x, y, size, speed, pimage;
        public Image[] images;

        public Player(int _x, int _y, int _size, int _speed, int _image)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            pimage = _image;
        }
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
        public bool monsterCollision(Player p, Monster m)
        {
            Rectangle pRec = new Rectangle(p.x, p.y, p.size, p.size);
            Rectangle mRec = new Rectangle(m.x, m.y, m.size, m.size);
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
