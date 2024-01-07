#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
#endregion

namespace RPG_Dom
{
    public class ObjectUI
    {

        public Vector2 pos;

        public ObjectUI(Vector2 POS)
        {
            pos = POS;
     
        
        }

        public virtual void Update(Camera camera)
        {
            //pos += vel;
        }


        public virtual void Draw(Camera camera)
        {
            //var rectangle = camera.WorldSpaceToCameraSpace(this);

        }
    }
}
