#region Includes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace RPG_Dom
{
    public class MapTexture : Object2d
    {

        public MapTexture(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT) : base(PATH, POS, DIMS, VEL, ROT)
        {
            
        }

        // Override the update method of Object2d to perform below changes

    }


}





