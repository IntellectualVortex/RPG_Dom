using RPG_Dom.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Dom
{
    public class ParticleManager
    {
        public Bullet bullet;
        private readonly List<Particle> particles = new();
        private readonly List<ParticleEmitter> particleEmitters = new();

        public void AddParticle(Particle p)
        {
            particles.Add(p);
        }

        public void AddParticleEmitter(ParticleEmitter e)
        {
            particleEmitters.Add(e);
        }

        public void UpdateParticles()
        {
            foreach (var particle in particles)
            {
                particle.Update();
            }

            particles.RemoveAll(p => p.isFinished);
        }

        public void UpdateEmitters()
        {
            foreach (var emitter in particleEmitters)
            {
                emitter.Update(bullet);
            }
        }

        public void Update()
        {
            UpdateParticles();
            UpdateEmitters();
        }

        public void Draw()
        {
            foreach (var particle in particles)
            {
                particle.Draw();
            }
        }
    }
}