#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.IO;

#endregion

namespace RPG_Dom
{
    public class HealthBar : ObjectUI
    {
        public Rectangle healthRect;
        public float currentValue;
        public float maxValue;
        Texture2D foreground;
        Texture2D background;

        public HealthBar(Texture2D FOREGROUND, Texture2D BACKGROUND, Vector2 POS, float MAXVALUE) : base(POS)
        {
            maxValue = MAXVALUE;
            foreground = FOREGROUND;
            background = BACKGROUND;
        }  

        public virtual void Update(float value) 
        {
            currentValue = value;
            healthRect.Width = (int)(currentValue / maxValue * foreground.Height);
        }


        public void SetHealthBar(Object2d sprite)
        {
            healthRect = new Rectangle(Globals.gDM.PreferredBackBufferWidth / 2,
                    Globals.gDM.PreferredBackBufferHeight / 2 - 40, 
                    foreground.Width, foreground.Height);
        }

        public override void Draw(Camera camera)
        {
            
            Globals.spriteBatch.Draw(foreground,
                new Rectangle(
                    Globals.gDM.PreferredBackBufferWidth / 2,
                    Globals.gDM.PreferredBackBufferHeight / 2,
                    (int)healthRect.Width,
                    (int)healthRect.Height),
                null,
                Color.White,
                0f,
                new Vector2(foreground.Bounds.Width / 2, foreground.Bounds.Height / 2),
                new SpriteEffects(),
                0.6f);

            Globals.spriteBatch.Draw(background,
                new Rectangle(
                    Globals.gDM.PreferredBackBufferWidth / 2,
                    Globals.gDM.PreferredBackBufferHeight / 2,
                    (int)healthRect.Width,
                    (int)healthRect.Height),
                null,
                Color.White,
                0f,
                new Vector2(background.Bounds.Width / 2, background.Bounds.Height / 2),
                new SpriteEffects(),
                0.6f);
        }
    }
}
