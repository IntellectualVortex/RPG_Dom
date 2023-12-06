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
        List<Object2d> objects = new List<Object2d>();
        public Player player;
        public Bullet bullet;
        

        public World()
        {
            player = new Player("Assets\\Knight", 
                new Vector2(Globals.graphicsDeviceManager.PreferredBackBufferWidth/2, 
                Globals.graphicsDeviceManager.PreferredBackBufferHeight/2), 
                new Vector2(100, 100), 
                new Vector2(1, 0), 0f);

            objects.Add(player);    
        }

        public virtual void Update()
        {

            // 
            for (var i = 0; i < objects.Count; i++)
            {
                if (objects[i].pos.X > Globals.graphicsDeviceManager.PreferredBackBufferWidth / 2 + 200 ||
                    objects[i].pos.X < Globals.graphicsDeviceManager.PreferredBackBufferWidth / 2 - 200 ||
                    objects[i].pos.Y > Globals.graphicsDeviceManager.PreferredBackBufferHeight / 2 + 200 ||
                    objects[i].pos.Y < Globals.graphicsDeviceManager.PreferredBackBufferHeight / 2 - 200)
                {
                    objects.Remove(objects[i]);
                }
            }

            MouseState mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                objects.Add(new Bullet("Assets\\item8BIT_sword", 
                    new Vector2(player.pos.X, player.pos.Y), 
                    new Vector2(20, 20), 
                    new Vector2(0, 0), player.rot));
            }

            foreach (Object2d obj in objects)
            {
                obj.Update();
            } 
        }
        
        public virtual void Draw() 
        {
            foreach (Object2d obj in objects)
            {
                obj.Draw();
            }
        }

    

    }
}
