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
        List<Object2d> enemies = new List<Object2d>();
        public Player player;
        public Bullet bullet;
        public MapTexture map; 
        public Camera camera;
        public BarbarianEnemy barb;


        public World()
        {
            player = new Player("Assets\\Knight", 
                new Vector2(Globals.graphicsDeviceManager.PreferredBackBufferWidth / 2,
                Globals.graphicsDeviceManager.PreferredBackBufferHeight / 2),
                new Vector2(Globals.graphicsDeviceManager.PreferredBackBufferWidth/2, 
                Globals.graphicsDeviceManager.PreferredBackBufferHeight/2), 
                new Vector2(100, 100), 
                new Vector2(1, 0), 0f);

            barb = new BarbarianEnemy("Assets\\run_1",
                new Vector2(0, 0),
                new Vector2(500, 500),
                new Vector2(120, 120),
                new Vector2(1, 0), 0f);

            map = new MapTexture("Assets\\tex",
                new Vector2(Globals.graphicsDeviceManager.PreferredBackBufferWidth / 2,
                Globals.graphicsDeviceManager.PreferredBackBufferHeight / 2),
                new Vector2(Globals.graphicsDeviceManager.PreferredBackBufferWidth / 2,
                Globals.graphicsDeviceManager.PreferredBackBufferHeight / 2),
                new Vector2(10000, 10000),
                new Vector2(1, 0), 0f);

            camera = new Camera(new Vector2(player.pos.X, player.pos.Y));

            objects.Add(player);
            enemies.Add(barb); 
           
        }


        public Vector2 worldSpaceToCameraSpace(Object2d sprite, float xOffset, float yOffset)
        {
            return new Vector2(camera.pos.X - sprite.pos.X + xOffset, camera.pos.Y - sprite.pos.Y + yOffset);
        }

        public void checkCollison()
        {

        }


        public void Update(GameTime gameTime)
        {

            camera.pos = player.currPos;

            for (var i = 0; i < objects.Count; i++)
            {
                if (objects[i].pos.X > Globals.graphicsDeviceManager.PreferredBackBufferWidth / 2 + 900 ||
                    objects[i].pos.X < Globals.graphicsDeviceManager.PreferredBackBufferWidth / 2 - 900 ||
                    objects[i].pos.Y > Globals.graphicsDeviceManager.PreferredBackBufferHeight / 2 + 600 ||
                    objects[i].pos.Y < Globals.graphicsDeviceManager.PreferredBackBufferHeight / 2 - 600)
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

            foreach (Object2d enemy in enemies)
            {
                enemy.Update();
            }

           
            map.pos += worldSpaceToCameraSpace(map, 0, 0);
            barb.pos += worldSpaceToCameraSpace(barb, 400, 0);

            // Collision check on enemy
            for (var i = 0; i < objects.Count; i++)
            {
                if ((objects[i].pos.X >= barb.pos.X && objects[i].pos.X <= barb.pos.X + 50) && (objects[i].pos.Y >= barb.pos.Y && objects[i].pos.Y <= barb.pos.Y + 50))           
              
                {
                    objects.Remove(objects[i]);
                }
            }
        }
        
        public void Draw()
        {
            map.Draw(1f);

            foreach (Object2d obj in objects)
            {
                obj.Draw(0f);
            }

            foreach (Object2d enemy in enemies)
            {
                enemy.Draw(0f);
            }
        }

    

    }
}
