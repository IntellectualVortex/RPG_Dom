#region Includes

using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
    public class Camera
    {
        public Vector2 pos;
       

        public Camera(Vector2 POS)
        {
            POS = pos;
        }

        //Replace with generics for both
        public Rectangle WorldSpaceToCameraSpace(Object2d sprite)
        {
            var x_1 = sprite.pos.X - pos.X + Globals.gDM.PreferredBackBufferWidth / 2;
            var y_1 = sprite.pos.Y - pos.Y + Globals.gDM.PreferredBackBufferHeight / 2;
            return new Rectangle((int)x_1, (int)y_1, (int)sprite.dims.X, (int)sprite.dims.Y);
        }

        public Rectangle WorldSpaceToCameraSpace(ObjectUI sprite)
        {
            var x_1 = sprite.pos.X - pos.X + Globals.gDM.PreferredBackBufferWidth / 2;
            var y_1 = sprite.pos.Y - pos.Y + Globals.gDM.PreferredBackBufferHeight / 2;
            return new Rectangle((int)x_1, (int)y_1, (int)50, (int)50);
        }

    }

}

