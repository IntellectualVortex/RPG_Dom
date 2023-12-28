using RPG_Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Dom
{
    public static class Collision
    {
        public Collision() { }  

        // Check whether sprite rectangle objects intersect with each other
        private static bool isInsideRectangle(float x, float y, float r_x_1, float r_y_1, float r_x_2, float r_y_2)
        {
            return r_x_1 <= x && x <= r_x_2 && r_y_1 <= y && y <= r_y_2;
        }

        public static bool ObjectCollision(Object2d obj, Object2d obj2) 
        {
            if (
                isInsideRectangle( // BULLET TOP LEFT
                    obj.pos.X - (obj.myObject.Width / 2), obj.pos.Y - (obj.myObject.Height / 2),
                    obj2.pos.X - (obj2.myObject.Width / 2), obj2.pos.Y - (obj2.myObject.Height / 2), // BARB TOP LEFT
                    obj2.pos.X + (obj2.myObject.Width / 2), obj2.pos.Y + (obj2.myObject.Height / 2) // BARB BOT RIGHT
                    )
                || isInsideRectangle( // BULLET TOP RIGHT
                    obj.pos.X + (obj.myObject.Width / 2), obj.pos.Y - (obj.myObject.Height / 2),
                    obj2.pos.X - (obj2.myObject.Width / 2), obj2.pos.Y - (obj2.myObject.Height / 2), // BARB TOP LEFT
                    obj2.pos.X + (obj2.myObject.Width / 2), obj2.pos.Y + (obj2.myObject.Height / 2) // BARB BOT RIGHT
                    )
                || isInsideRectangle( // BULLET BOT RIGHT
                    obj.pos.X + (obj.myObject.Width / 2), obj.pos.Y + (obj.myObject.Height / 2),
                    obj2.pos.X - (obj2.myObject.Width / 2), obj2.pos.Y - (obj2.myObject.Height / 2), // BARB TOP LEFT
                    obj2.pos.X + (obj2.myObject.Width / 2), obj2.pos.Y + (obj2.myObject.Height / 2) // BARB BOT RIGHT
                    )
                || isInsideRectangle( // BULLET BOT LEFT
                    obj.pos.X - (obj.myObject.Width / 2), obj.pos.Y + (obj.myObject.Height / 2),
                    obj2.pos.X - (obj2.myObject.Width / 2), obj2.pos.Y - (obj2.myObject.Height / 2), // BARB TOP LEFT
                    obj2.pos.X + (obj2.myObject.Width / 2), obj2.pos.Y + (obj2.myObject.Height / 2) // BARB BOT RIGHT
                    )
                ) 
            {
                return true;     
            }
            return false;
        }

        public static bool ObjectListCollision(List<Object2d> objList, List<Object2d> objList2)
        {
            for (var j = 0; j < objList.Count; j++)
            {
                for (var i = 0; i < objList2.Count; i++)
                {
                    return ObjectCollision(Object2d obj, Object2d obj2);

                }

            }
            return false;
        }
    }

}


/*
public static bool ObjectCollision(List<Object2d> obj, List<Object2d> obj2, int i, int j)
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
*/