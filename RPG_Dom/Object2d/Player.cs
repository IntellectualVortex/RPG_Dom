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

        float playerRot;

        public Player(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL) : base(PATH, POS, DIMS, VEL) 
        {
            playerRot = 0.0f;
        }


        // override the update method of Object2d to perform below changes
        public override void Update()
        {

            // Player sprite rotate towards cursor
            MouseState mouse = Mouse.GetState();
            var distance = new Vector2(mouse.X - pos.X, mouse.Y - pos.Y);
            playerRot = (float)Math.Atan2(distance.Y, distance.X);
          







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
            base.DrawWithRot(playerRot);

            
        }

    }


}
