#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#endregion

namespace RPG_Dom
{
    public static class BarbarianFactory
    { 

        public static BarbarianEnemy Create(Player player)
        {
            Random rnd = new Random();
            return new BarbarianEnemy(player,
                "Assets\\barb",
                new Vector2(5500 + rnd.Next(-500, 500), 5000 + rnd.Next(-500, 500)),
                new Vector2(120, 120),
                new Vector2(1, 0), 0f);
        }
    }
}
