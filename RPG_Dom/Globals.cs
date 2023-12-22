using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace RPG_Dom
{
    public class Globals
    {
        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static GraphicsDeviceManager gDM;
        public static Random random;
        public static float TotalSeconds;

        public static float RandomFloat(float min, float max)
        {
            return (float)(random.NextDouble() * (max - min)) + min;
        }

        public static void Update(GameTime gt)
        {
            TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
        }
    }
}
