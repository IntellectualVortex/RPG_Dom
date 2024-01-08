#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing;
#endregion

namespace RPG_Dom
{
    public class BarbarianEnemy : Object2d, IHealthbar
    {
        Player player;

        public string name;
        public HealthBar healthbar;
        public float health = 100;


        public float GetHealth()
        {
            return health;
        }

        public BarbarianEnemy(Player PLAYER, string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT, float HEALTH) : base(PATH, POS, DIMS, VEL, ROT)
        {
            health = HEALTH;
            player = PLAYER;
        }


        public override void Update(Camera camera)
        {
            GetHealth();    
            UpdateRotation(camera);
            Move(camera);
            base.Update(camera);
        }


        public void TakeDamage()
        {
            health -= 10;
        }

        public void Move(Camera camera)
        {
            vel = GameCalcs.MoveToPlayer((int)player.pos.X, (int)player.pos.Y, (int)this.pos.X, (int)this.pos.Y) / GameCalcs.MoveToPlayer((int)player.pos.X, (int)player.pos.Y, (int)this.pos.X, (int)this.pos.Y).Length();
        }

        private void UpdateRotation(Camera camera)
        {
            var distance = new Vector2(player.pos.X - pos.X, player.pos.Y - pos.Y);
            rot = (float)Math.Atan2(distance.Y, distance.X);
        }

    }
}
