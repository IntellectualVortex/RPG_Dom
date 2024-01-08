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


        //MAKE MAX HEALTH EQUAL TO DIMS for X WIDTH FOR HEALTH BAR
        public float maxHealth;
        public float health;

        HealthBar healthBar;
        public float speedMult;
        //public List<Vector2> lastPositions = new List<Vector2>();


        public Player(int SPEEDMULT, string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT, float HEALTH=150f) : base(PATH, POS, DIMS, VEL, ROT) 
        {
            speedMult = SPEEDMULT;
            maxHealth = HEALTH;
            health = HEALTH;

            var back = Globals.content.Load<Texture2D>("Assets\\back");
            var front = Globals.content.Load<Texture2D>("Assets\\front");
            healthBar = new HealthBar(front, back, new Vector2(pos.X, pos.Y), 150f);
        }

        public void TakeDamage(float dmg)
        {
            if (health > 0)
            {
                health -= dmg;
            }
            else { }
        }


        public override void Update(Camera camera)
        {
            //lastPositions.Add(pos);
            //Debug.WriteLine(lastPositions[i++]);
            healthBar.Update(health);
            UpdateRotation(camera);
            GetVelocity();
            base.Update(camera);
        }

        private void UpdateRotation(Camera camera)
        {
            var rectangle = camera.WorldSpaceToCameraSpace(this);
            MouseState mouse = Mouse.GetState();
            var distance = new Vector2(mouse.X - rectangle.X, mouse.Y - rectangle.Y);
            rot = (float)Math.Atan2(distance.Y, distance.X);
        }


        // MOVE MOVEMENT CONTROLLS TO CharacterControl CLASS!!
        public void GetVelocity()
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
      
        public Bullet CreateBulletPrimary()
        {
            return new Bullet("Assets\\item8BIT_sword",
                    new Vector2(pos.X, pos.Y),
                    new Vector2(myObject.Bounds.Width - 10, myObject.Bounds.Height - 10),
                    new Vector2((float)Math.Cos(rot),(float)Math.Sin(rot)) * 10f,
                    rot);
        }

        public Bullet CreateBulletSecondary()
        {
            return new Bullet("Assets\\item8BIT_sword",
                    new Vector2(pos.X, pos.Y),
                    new Vector2(myObject.Bounds.Width + 50, myObject.Bounds.Height + 50),
                    new Vector2((float)Math.Cos(rot), (float)Math.Sin(rot)) * 10f,
                    rot);
        }


        public override void Draw(float layer, Camera camera)
        {

            healthBar.Draw(camera);

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
