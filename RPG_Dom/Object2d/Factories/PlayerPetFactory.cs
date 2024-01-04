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
    public static class PlayerPetFactory
    {
        static PlayerPetFactory() { }

        public static PlayerPet Create(Player player)
        {
            return new PlayerPet(player, "Assets\\pet",
                new Vector2(player.pos.X + 100, player.pos.Y + 100),
                new Vector2(100, 100),
                new Vector2(1, 0), 0f);
        }
    }
}
