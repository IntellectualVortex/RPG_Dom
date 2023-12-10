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
    }
}
