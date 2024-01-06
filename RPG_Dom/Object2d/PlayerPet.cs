#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing;
#endregion

namespace RPG_Dom
{
    public class PlayerPet : Object2d, IMoveable
    {
        public Player player;


        public PlayerPet(Player PLAYER, string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT) : base(PATH, POS, DIMS, VEL, ROT)
        {
            player = PLAYER;
        }


        public override void Update(Camera camera)
        {
            UpdateRotation(camera);
            Move(camera);
            base.Update(camera);
        }

        // MOVE MOVEMENT CONTROLLS TO CharacterControl CLASS!!
        public void Move(Camera camera)
        {
            if (Math.Abs(pos.X - player.pos.X) > 75 || Math.Abs(pos.Y - player.pos.Y) > 75)
            {
                vel = GameCalcs.MoveToPlayer((int)player.pos.X, (int)player.pos.Y, (int)this.pos.X, (int)this.pos.Y);
                vel.Normalize();
                vel *= player.speedMult;
            }

            else 
            {
                vel = new Vector2(0,0);
            }

        }
        private void UpdateRotation(Camera camera)
        {
            var distance = new Vector2(player.pos.X - pos.X, player.pos.Y - pos.Y);
            rot = (float)Math.Atan2(distance.Y, distance.X);
        }
    }



}
