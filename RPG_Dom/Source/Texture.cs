#region Includes

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
    public class MapTexture
    {
        public Vector2 pos, dims;
        public Texture2D myTexture;

        public MapTexture(string PATH, Vector2 POS, Vector2 DIMS)
        { 
            pos = POS;
            dims = DIMS;

            myTexture = Globals.content.Load<Texture2D>(PATH);  
        }

        public void Update()
        {

        }

        public void Draw(float layer)
        {
            Globals.spriteBatch.Draw(myTexture,
                new Rectangle((int)(pos.X), (int)(pos.Y), (int)(dims.X), (int)(dims.Y)),
                null, 
                Color.White, 
                0f, 
                new Vector2(myTexture.Bounds.Width / 2, myTexture.Bounds.Height / 2),
                new SpriteEffects(), layer);
        }
    }
}
