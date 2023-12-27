using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Dom
{
    public static class Collision
    {

        static Collision() { }  

        // Check whether sprite rectangle objects intersect with each other
        private static bool isInsideRectangle(float x, float y, float r_x_1, float r_y_1, float r_x_2, float r_y_2)
        {
            return r_x_1 <= x && x <= r_x_2 && r_y_1 <= y && y <= r_y_2;
        }

        public static bool EnemyCollision(List<Object2d> obj, List<Object2d> obj2, int i, int j) 
        {
            if (
                isInsideRectangle( // BULLET TOP LEFT
                    obj[i].pos.X - (obj[i].myObject.Width / 2), obj[i].pos.Y - (obj[i].myObject.Height / 2),
                    obj2[j].pos.X - (obj2[j].myObject.Width / 2), obj2[j].pos.Y - (obj2[j].myObject.Height / 2), // BARB TOP LEFT
                    obj2[j].pos.X + (obj2[j].myObject.Width / 2), obj2[j].pos.Y + (obj2[j].myObject.Height / 2) // BARB BOT RIGHT
                    )
                || isInsideRectangle( // BULLET TOP RIGHT
                    obj[i].pos.X + (obj[i].myObject.Width / 2), obj[i].pos.Y - (obj[i].myObject.Height / 2),
                    obj2[j].pos.X - (obj2[j].myObject.Width / 2), obj2[j].pos.Y - (obj2[j].myObject.Height / 2), // BARB TOP LEFT
                    obj2[j].pos.X + (obj2[j].myObject.Width / 2), obj2[j].pos.Y + (obj2[j].myObject.Height / 2) // BARB BOT RIGHT
                    )
                || isInsideRectangle( // BULLET BOT RIGHT
                    obj[i].pos.X + (obj[i].myObject.Width / 2), obj[i].pos.Y + (obj[i].myObject.Height / 2),
                    obj2[j].pos.X - (obj2[j].myObject.Width / 2), obj2[j].pos.Y - (obj2[j].myObject.Height / 2), // BARB TOP LEFT
                    obj2[j].pos.X + (obj2[j].myObject.Width / 2), obj2[j].pos.Y + (obj2[j].myObject.Height / 2) // BARB BOT RIGHT
                    )
                || isInsideRectangle( // BULLET BOT LEFT
                    obj[i].pos.X - (obj[i].myObject.Width / 2), obj[i].pos.Y + (obj[i].myObject.Height / 2),
                    obj2[j].pos.X - (obj2[j].myObject.Width / 2), obj2[j].pos.Y - (obj2[j].myObject.Height / 2), // BARB TOP LEFT
                    obj2[j].pos.X + (obj2[j].myObject.Width / 2), obj2[j].pos.Y + (obj2[j].myObject.Height / 2) // BARB BOT RIGHT
                    )
                ) 
            {

                return true;
                    
            }

            return false;
        } 
    }

}
