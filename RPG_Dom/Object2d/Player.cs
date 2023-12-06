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
    public class Player : Object2d
    {
       
        List<Bullet> bullets = new List<Bullet>(); 
        public Bullet bullet;

        public Player(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT) : base(PATH, POS, DIMS, VEL, ROT) 
        {
        
        }


        // Override the update method of Object2d to perform below changes
        public override void Update()
        {

            // Player sprite rotate towards cursor
            MouseState mouse = Mouse.GetState();
            var distance = new Vector2(mouse.X - pos.X, mouse.Y - pos.Y);
            Globals.playerRot = (float)Math.Atan2(distance.Y, distance.X);



            // On mouse press, add Bullet object to bullet list
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                
                bullets.Add(new Bullet("Assets\\item8BIT_sword", new Vector2(pos.X, pos.Y), new Vector2(20, 20), new Vector2(0, 0), Globals.playerRot));
            }

            // Loop through the list of bullets and update their position
            foreach (Bullet bullet in bullets)
            {
                bullet.Update();
            }


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
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw();
            }


            base.DrawWithRot(Globals.playerRot);

            
        }

    }


}
