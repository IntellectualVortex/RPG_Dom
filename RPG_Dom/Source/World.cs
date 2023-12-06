#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace RPG_Dom
{
    public class World
    {
    
        public Object2d knight;
        public Bullet bullet;

        public World()
        {
            knight = new Player("Assets\\Knight", new Vector2(100, 100), new Vector2(100, 100), new Vector2(1, 0), 0f);
           
        }

        public virtual void Update()
        {
            knight.Update();   
        }
        
        public virtual void Draw() 
        { 
            knight.Draw();
        }

    

    }
}
