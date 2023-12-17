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
    public class Object2d
    {
 
        public Vector2 pos, dims, vel;
        public float rot, health;
        public Texture2D myObject;


        public Object2d(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT = 0, float HEALTH = 100)
        {
            pos = POS;
            dims = DIMS;
            vel = VEL;
            rot = ROT;
            health = HEALTH;

            myObject = Globals.content.Load<Texture2D>(PATH);
         
        }

        public virtual void Update(Camera camera)
        {
            pos += vel;
        }

        
        public virtual void Draw(float layer, Camera camera)
        {
            // enum
            SpriteEffects flipDirection;

            if (Math.Abs(rot) <= Math.PI/2)
            {
                flipDirection = SpriteEffects.None;

            }
            else
            {
                flipDirection = SpriteEffects.FlipVertically;
            }
            var rectangle = camera.worldSpaceToCameraSpace(this);
            Globals.spriteBatch.Draw(myObject,
                rectangle,
                null,
                Color.White,
                rot,
                new Vector2(myObject.Bounds.Width / 2, myObject.Bounds.Height / 2),
                flipDirection,
                layer);
        }
    }  
}
