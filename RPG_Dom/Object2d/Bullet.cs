﻿#region Includes
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


        public Bullet(string PATH, Vector2 CURRPOS, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT) : base(PATH, CURRPOS, POS, DIMS, VEL, ROT) {
            
        }

        public override void Update()
        {
            vel = new Vector2((float)Math.Cos(rot), (float)Math.Sin(rot)) * 5f;
            pos += vel;
        }
    }
}
