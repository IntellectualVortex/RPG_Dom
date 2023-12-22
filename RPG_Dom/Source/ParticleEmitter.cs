#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using RPG_Dom.Source;
using System;
using System.IO;

#endregion

namespace RPG_Dom
{
    public class ParticleEmitter
    {
        ParticleEmitterData _data;
        private float intervalLeft;
        public ParticleManager ParticleManager;

        public ParticleEmitter(ParticleEmitterData data)
        {
            intervalLeft = data.interval;
            _data = data;
            
        }

        private void Emit(Vector2 pos)
        {

            ParticleData d = _data.particleData;
            d.lifespan = Globals.RandomFloat(_data.lifespanMin, _data.lifespanMax);
            d.speed = Globals.RandomFloat(_data.speedMin, _data.speedMax);
            d.angle = Globals.RandomFloat(_data.angle - _data.angleVariance, _data.angle + _data.angleVariance);

            Particle p = new(pos, d);
            ParticleManager.AddParticle(p);
        }

        public void Update(Bullet bullet)
        {
            intervalLeft -= Globals.TotalSeconds;
            while (intervalLeft <= 0f)
            {
                intervalLeft += _data.interval;
                var pos = bullet.pos;
                for (int i = 0; i < _data.emitCount; i++)
                {
                    Emit(bullet.pos);
                }
            }
        }
    }
}