using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;


namespace RPG_Dom.Source
{
    public class Particle
    {
        private readonly ParticleData data;
        private Vector2 position;
        private float lifespanLeft;
        private float lifespanAmount;
        private Color color;
        private float opacity;
        public bool isFinished = false;
        private float scale;
        private Vector2 origin;
        private Vector2 direction;

        public Particle(Vector2 pos, ParticleData DATA)
        {
            data = DATA;
            lifespanLeft = data.lifespan;
            lifespanAmount = 1f;
            position = pos;
            color = data.colorStart;
            opacity = data.opacityStart;
            origin = new(data.texture.Width / 2, data.texture.Height / 2);

            if (data.speed != 0)
            {
                data.angle = MathHelper.ToRadians(data.angle);
                direction = new Vector2((float)Math.Sin(data.angle), -(float)Math.Cos(data.angle));
            }
            else
            {
                direction = Vector2.Zero;
            }
        }

        public void Update()
        {
            lifespanLeft -= Globals.TotalSeconds;
            if (lifespanLeft <= 0f)
            {
                isFinished = true;
                return;
            }

            lifespanAmount = MathHelper.Clamp(lifespanLeft / data.lifespan, 0, 1);
            color = Color.Lerp(data.colorEnd, data.colorStart, lifespanAmount);
            opacity = MathHelper.Clamp(MathHelper.Lerp(data.opacityEnd, data.opacityStart, lifespanAmount), 0, 1);
            scale = MathHelper.Lerp(data.sizeEnd, data.sizeStart, lifespanAmount) / data.texture.Width;
            position += direction * data.speed * Globals.TotalSeconds;
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(data.texture, position, null, color * opacity, 0f, origin, scale, SpriteEffects.None, 1f);
        }
    }
}