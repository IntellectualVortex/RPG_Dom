#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

#endregion

namespace RPG_Dom
{
    public class Player
    {

        public Vector2 pos, dims, vel;
        public Texture2D myPlayer;
        public float rot;



        public Player(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL)
        {
            pos = POS;
            dims = DIMS;
            vel = VEL;

            myPlayer = Globals.content.Load<Texture2D>(PATH);
        }



        public virtual void Update()
        {
            // Player controlled directional movement 
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                pos = new Vector2(pos.X, pos.Y += 1);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                pos = new Vector2(pos.X, pos.Y -= 1);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                pos = new Vector2(pos.X += 1, pos.Y);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                pos = new Vector2(pos.X -= 1, pos.Y);
            }


        }

        public virtual void Draw()
        {
            // Draw the selected model as a rectangle for hitbox and rotation measures
            Globals.spriteBatch.Draw(myPlayer, new Microsoft.Xna.Framework.Rectangle((int)(pos.X), (int)(pos.Y), (int)(dims.X), (int)(dims.Y)), null, Microsoft.Xna.Framework.Color.White, rot, new Vector2(myPlayer.Bounds.Width / 2, myPlayer.Bounds.Height / 2), new SpriteEffects(), 0);
        }

    }

    
}
