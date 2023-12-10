#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
#endregion

namespace RPG_Dom
{
    public class Player : Object2d
    {
        public float primaryCooldownTimer = 0;
        public float secondaryCooldownTimer = 0;
        public float playerPrimaryCooldownLength = 100;
        public float playerSecondaryCooldownLength = 500;
        //Camera camera;
    
        public Player(string PATH, Vector2 CURRPOS, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT) : base(PATH, CURRPOS, POS, DIMS, VEL, ROT) 
        {
        
        }

        // Override the update method of Object2d to perform below changes
        public override void Update()
        { 
            
            //camera = new Camera();
            MouseState mouse = Mouse.GetState();
            var distance = new Vector2(mouse.X - pos.X, mouse.Y - pos.Y);
            rot = (float)Math.Atan2(distance.Y, distance.X);

            // Player controlled directional movement, align with fixed camera
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                currPos = new Vector2(currPos.X, currPos.Y -= 2);
                //camera.pos = new Vector2(pos.X, pos.Y += 2);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                currPos = new Vector2(currPos.X, currPos.Y += 2);
                //camera.pos = new Vector2(pos.X, pos.Y -= 2);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                currPos = new Vector2(currPos.X -= 2, currPos.Y);
                //camera.pos = new Vector2(pos.X += 2, pos.Y);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                currPos = new Vector2(currPos.X += 2, currPos.Y);
                //camera.pos = new Vector2(pos.X -= 2, pos.Y);
            }
        }


    }


}
