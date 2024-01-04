﻿#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing;
#endregion

namespace RPG_Dom
{
    public class BarbarianEnemy : Object2d, IMoveable
    {
        Player player;

        public string name;

        public BarbarianEnemy(Player PLAYER, string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT) : base(PATH, POS, DIMS, VEL, ROT)
        {
            player = PLAYER;
        }


        public override void Update(Camera camera)
        {
            UpdateRotation(camera);
            Move(camera);
            base.Update(camera);
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
