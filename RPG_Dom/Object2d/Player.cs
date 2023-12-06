#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;


#endregion

namespace RPG_Dom
{
    public class Player : Object2d
    {

        public Player(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT) : base(PATH, POS, DIMS, VEL, ROT) 
        {
        
        }

        // Override the update method of Object2d to perform below changes
        public override void Update()
        { 
            MouseState mouse = Mouse.GetState();
            var distance = new Vector2(mouse.X - pos.X, mouse.Y - pos.Y);
            rot = (float)Math.Atan2(distance.Y, distance.X);

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

        public override void Draw()
        {
            base.Draw();
        }

    }


}
