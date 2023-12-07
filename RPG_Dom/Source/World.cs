#region Includes

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
        public MapTexture map; 


        public World()
        {
            player = new Player("Assets\\Knight", 
                new Vector2(Globals.graphicsDeviceManager.PreferredBackBufferWidth/2, 
                Globals.graphicsDeviceManager.PreferredBackBufferHeight/2), 
                new Vector2(100, 100), 
                new Vector2(1, 0), 0f);

            map = new MapTexture("Assets\\tex", new Vector2(0, 0), new Vector2(1920, 1080));

            objects.Add(player);    
        }

        public void Update(GameTime gameTime)
        {

            for (var i = 0; i < objects.Count; i++)
            {
                if (objects[i].pos.X > Globals.graphicsDeviceManager.PreferredBackBufferWidth / 2 + 500 ||
                    objects[i].pos.X < Globals.graphicsDeviceManager.PreferredBackBufferWidth / 2 - 500 ||
                    objects[i].pos.Y > Globals.graphicsDeviceManager.PreferredBackBufferHeight / 2 + 500 ||
                    objects[i].pos.Y < Globals.graphicsDeviceManager.PreferredBackBufferHeight / 2 - 500)
                {
                    objects.Remove(objects[i]);
                }
            }

            
            player.primaryCooldownTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            player.secondaryCooldownTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            MouseState mouse = Mouse.GetState();
            
            if (mouse.LeftButton == ButtonState.Pressed)
            {

                if (player.primaryCooldownTimer >= player.playerPrimaryCooldownLength)
                {
                    objects.Add(new Bullet("Assets\\item8BIT_sword",
                    new Vector2(player.pos.X, player.pos.Y),
                    new Vector2(20, 20),
                    new Vector2(0, 0), player.rot));

                    player.primaryCooldownTimer = 0;
                }

            }

            if (mouse.RightButton == ButtonState.Pressed)
            {

                if (player.secondaryCooldownTimer >= player.playerSecondaryCooldownLength)
                {
                    objects.Add(new Bullet("Assets\\item8BIT_sword",
                    new Vector2(player.pos.X, player.pos.Y),
                    new Vector2(50, 50),
                    new Vector2(0, 0), player.rot));

                    player.secondaryCooldownTimer = 0;
                }

            }

            foreach (Object2d obj in objects)
            {
                obj.Update();
            } 

            map.Update();
        }
        
        public void Draw() 
        {
            map.Draw(.1f);

            foreach (Object2d obj in objects)
            {
                obj.Draw(.2f);
            }
        }

    

    }
}
