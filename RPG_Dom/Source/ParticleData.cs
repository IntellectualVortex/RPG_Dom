using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RPG_Dom
{
    public struct ParticleData
    {
        public Texture2D texture = Globals.content.Load<Texture2D>("Assets\\particle");
        public float lifespan = 2f;
        public float opacityStart = 1f;
        public Color colorStart = Color.Yellow;
        public Color colorEnd = Color.Red;
        public float opacityEnd = 0f;
        public float sizeStart = 32f;
        public float sizeEnd = 4f;
        public float speed = 100f;
        public float angle = 0f;

        public ParticleData()
        {
        }
    }
}