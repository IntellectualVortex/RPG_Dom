#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

#endregion

namespace RPG_Dom
{
    public class Object2d
    {
 
        public Vector2 pos, dims, vel;
        public float rot;
        public Texture2D myObject;


        public Object2d(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT = 0)
        {
            pos = POS;
            dims = DIMS;
            vel = VEL;
            rot = ROT;

            myObject = Globals.content.Load<Texture2D>(PATH);
         
        }



        public virtual void Update()
        {

        }

        
        public virtual void Draw(float layer)
        {

            // Draw the selected model as a rectangle for hitbox and rotation measures
            Globals.spriteBatch.Draw(myObject,
                new Rectangle((int)(pos.X), (int)(pos.Y), (int)(dims.X), (int)(dims.Y)),
                null,
                Color.White,
                rot,
                new Vector2(myObject.Bounds.Width / 2, myObject.Bounds.Height / 2),
                new SpriteEffects(),
                layer);
        }
    }  
}
