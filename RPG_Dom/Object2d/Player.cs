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
    public class Player : Object2d
    {
        public float primaryCooldownTimer = 0;
        public float secondaryCooldownTimer = 0;
        public float playerPrimaryCooldownLength = 100;
        public float playerSecondaryCooldownLength = 500;
    
        public Player(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT, float HEALTH) : base(PATH, POS, DIMS, VEL, ROT, HEALTH) 
        {
        
        }

        // Override the update method of Object2d to perform below changes
        public override void Update(Camera camera)
        {
            //camera = new Camera();
            var rectangle = camera.worldSpaceToCameraSpace(this);
            MouseState mouse = Mouse.GetState();
            var distance = new Vector2(mouse.X - rectangle.X, mouse.Y - rectangle.Y);
            rot = (float)Math.Atan2(distance.Y, distance.X);

            // Player controlled directional movement, align with fixed camera
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                pos = new Vector2(pos.X, pos.Y -= 2);
                //camera.pos = new Vector2(pos.X, pos.Y += 2);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                pos = new Vector2(pos.X, pos.Y += 2);
                //camera.pos = new Vector2(pos.X, pos.Y -= 2);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                pos = new Vector2(pos.X -= 2, pos.Y);
                //camera.pos = new Vector2(pos.X += 2, pos.Y);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                pos = new Vector2(pos.X += 2, pos.Y);
                //camera.pos = new Vector2(pos.X -= 2, pos.Y);
            }
        }


        public override void Draw(float layer, Camera camera)
        {
            Globals.spriteBatch.Draw(myObject,
                new Rectangle(
                    Globals.gDM.PreferredBackBufferWidth / 2,
                    Globals.gDM.PreferredBackBufferHeight / 2, 
                    (int)dims.X,
                    (int)dims.Y),
                    null,
                    Color.White,
                    rot,
                    new Vector2(myObject.Bounds.Width / 2, myObject.Bounds.Height / 2),
                    new SpriteEffects(),
                    layer);

        }
      
        public Bullet createBulletPrimary()
        {
            return new Bullet("Assets\\item8BIT_sword",
                    new Vector2(pos.X, pos.Y),
                    new Vector2(50, 50),
                    new Vector2(-1 * (float)Math.Cos(rot), -1 * (float)Math.Sin(rot)) * 10f,
                    rot, 100);
        }

        public Bullet createBulletSecondary()
        {
            return new Bullet("Assets\\item8BIT_sword",
                    new Vector2(pos.X, pos.Y),
                    new Vector2(100, 100),
                    new Vector2(-1 * (float)Math.Cos(rot), -1 * (float)Math.Sin(rot)) * 10f,
                    rot, 100);
        }
    }


}
