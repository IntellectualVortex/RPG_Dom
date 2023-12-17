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
        

        public HealthBar(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT, float HEALTH) : base(PATH, POS, DIMS, VEL, ROT, HEALTH)
        {
           
        }  

        public void SetHealthBar(Object2d sprite)
        {
            health = 100;
            healthRect = new Rectangle((int)sprite.pos.X, (int)sprite.pos.Y, health, 20);
        }

        public override void Draw(float layer, Camera camera)
        {
            var rectangle = camera.worldSpaceToCameraSpace(this);
            Globals.spriteBatch.Draw(myObject,
                new Rectangle(
                    Globals.gDM.PreferredBackBufferWidth / 2,
                    Globals.gDM.PreferredBackBufferHeight / 2 - 40,
                    (int)dims.X + 20,
                    (int)dims.Y / 5),
                    null,
                    Color.White,
                    rot,
                    new Vector2(myObject.Bounds.Width / 2, myObject.Bounds.Height / 2),
                    new SpriteEffects(),
                    layer);
        }
    }
}
