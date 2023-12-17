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



        public static Vector2 MoveToPlayer(int X, int Y, int X2, int Y2)
        {
            return new Vector2(X - X2, Y - Y2);
        }
    }
}
