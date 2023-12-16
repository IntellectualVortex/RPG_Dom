#region ncludes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
#endregion

namespace RPG_Dom 
{ 
    public class Powerup : Object2d
    {
        public Powerup(string PATH, Vector2 POS, Vector2 DIMS, Vector2 VEL, float ROT, float HEALTH) : base(PATH, POS, DIMS, VEL, ROT, HEALTH)  
        { 
        
        }
    }
}
