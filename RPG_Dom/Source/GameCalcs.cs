#region Includes

using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion
namespace RPG_Dom
{
    public static class GameCalcs
    {

        static GameCalcs() 
        { 
        }  

        public static Vector2 rotatePoint(float X, float Y, float rot)
        {
            return new Vector2((X * (float)Math.Cos(rot)) - (Y * (float)Math.Sin(rot)),
                (X * (float)Math.Sin(rot)) + (Y * (float)Math.Cos(rot)));
        }

        public static void MoveToPlayer(int X, int Y, int X2, int Y2)
        {
            // Calculate the distance between the enemy and the player
            int distanceX = X - X2;
            int distanceY = Y - Y2;

            // Move the enemy towards the player
            if (distanceX > 0)
            {
                X++;
            }
            else if (distanceX < 0)
            {
                X--;
            }

            if (distanceY > 0)
            {
                Y++;
            }
            else if (distanceY < 0)
            {
                Y2--;
            }

            /*
                    public static float critChance()
                    {
                        if 
                    }*/

        }
    }
}
