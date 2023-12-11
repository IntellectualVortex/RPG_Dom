#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
#endregion

namespace RPG_Dom
{
    public class BarbarianEnemy : Object2d
    {
        public BarbarianEnemy(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT) : base(PATH, POS, DIMS, VEL, ROT)
        {

        }


        public virtual void Update(Player player, Camera camera)
        {
            var rectangle = camera.worldSpaceToCameraSpace(this);
            var distanceToPlayer = new Vector2(player.pos.X - rectangle.X, player.pos.Y - rectangle.Y);
            rot = (float)Math.Atan2(distanceToPlayer.Y, distanceToPlayer.X);
        }


    }
}
