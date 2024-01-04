#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#endregion

namespace RPG_Dom
{
    public class Player : Object2d
    {
        public float primaryCooldownTimer = 0;
        public float secondaryCooldownTimer = 0;
        public float playerPrimaryCooldownLength = 100;
        public float playerSecondaryCooldownLength = 500;
        public float critChance = 20;
        public float baseAttack = 10;

        public float speedMult;
        public List<Vector2> lastPositions = new List<Vector2>();


        public Player(int SPEEDMULT, string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT) : base(PATH, POS, DIMS, VEL, ROT) 
        {
            speedMult = SPEEDMULT;
        }

        public override void Update(Camera camera)
        {
            
            lastPositions.Add(pos);

            //Debug.WriteLine(lastPositions[i++]);

            updateRotation(camera);
            updateVelocity();
            base.Update(camera);
        }

        private void updateRotation(Camera camera)
        {
            var rectangle = camera.worldSpaceToCameraSpace(this);
            MouseState mouse = Mouse.GetState();
            var distance = new Vector2(mouse.X - rectangle.X, mouse.Y - rectangle.Y);
            rot = (float)Math.Atan2(distance.Y, distance.X);
        }


        // MOVE MOVEMENT CONTROLLS TO CharacterControl CLASS!!
        private void updateVelocity()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.S)) 
            {
                vel.Y = 0;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W)) {
                vel.Y = -1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S)) {
                vel.Y = 1;
            }
            else
            {
                vel.Y = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                vel.X = 0;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                vel.X = 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                vel.X = -1 ;
            }
            else
            {
                vel.X = 0;
            }

            if (vel != Vector2.Zero)
            {
                vel.Normalize();
                vel *= speedMult;
            }
        }
      
        public Bullet createBulletPrimary()
        {
            return new Bullet("Assets\\item8BIT_sword",
                    new Vector2(pos.X, pos.Y),
                    new Vector2(myObject.Bounds.Width - 10, myObject.Bounds.Height - 10),
                    new Vector2((float)Math.Cos(rot),(float)Math.Sin(rot)) * 10f,
                    rot);
        }

        public Bullet createBulletSecondary()
        {
            return new Bullet("Assets\\item8BIT_sword",
                    new Vector2(pos.X, pos.Y),
                    new Vector2(myObject.Bounds.Width + 50, myObject.Bounds.Height + 50),
                    new Vector2((float)Math.Cos(rot), (float)Math.Sin(rot)) * 10f,
                    rot);
        }


        public override void Draw(float layer, Camera camera)
        {
            SpriteEffects flipDirection;

            if (Math.Abs(rot) <= Math.PI / 2)
            {
                flipDirection = SpriteEffects.None;

            }
            else
            {
                flipDirection = SpriteEffects.FlipVertically;
            }
            
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
                    flipDirection,
                    layer);

        }
    }


}
