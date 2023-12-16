#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.IO;

#endregion

namespace RPG_Dom
{
    public class HealthBar : Object2d
    {
        int health = 0;
        Rectangle healthRect;
        public Texture2D myObject;

        public HealthBar(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT) : base(PATH, POS, DIMS, VEL, ROT)
        {
           
        }  


        public void SetHealthBar(Object2d sprite)
        {
            health = 100;
            healthRect = new Rectangle((int)sprite.pos.X, (int)sprite.pos.Y, health, 20);
        }


        public virtual void Draw(float layer, Camera camera)
        {
            Globals.spriteBatch.Draw(myObject, healthRect, Color.White);
        }
    }
}
