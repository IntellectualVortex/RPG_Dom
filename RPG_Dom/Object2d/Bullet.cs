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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

#endregion

namespace RPG_Dom
{

    public class Bullet : Object2d
    {
        public float bulletRot;

        public Bullet(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL) : base(PATH, POS, DIMS, VEL) {
            
        }

        public override void Update()
        {
            // Bullet rotation vector
            MouseState mouse = Mouse.GetState();
            var distance = new Vector2(mouse.X - pos.X, mouse.Y - pos.Y);
            bulletRot = (float)Math.Atan2(distance.Y, distance.X);

            vel = new Vector2((float)Math.Cos(bulletRot), (float)Math.Sin(bulletRot)) * 5f;
            pos += vel;
        }

        public override void Draw()
        {
            base.DrawWithRot(bulletRot);
        }

    }
}
