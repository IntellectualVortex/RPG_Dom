#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

#endregion

namespace RPG_Dom 
{ 
    public class PowerUp : Object2d
    {

        public PowerUp(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT) : base(PATH, POS, DIMS, VEL, ROT)  
        { 
        
        }

        
/*        public Object2d CreateSpeedPowerUp() 
        {

        }  */


        public override void Draw(float layer, Camera camera)
        {
            var rectangle = camera.WorldSpaceToCameraSpace(this);
            Globals.spriteBatch.Draw(myObject,
                rectangle,
                null,
                Color.White,
                rot,
                new Vector2(myObject.Bounds.Width / 2, myObject.Bounds.Height / 2),
                new SpriteEffects(),
                layer);
        }
    }
}
