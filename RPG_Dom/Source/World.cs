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
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace RPG_Dom
{
    public class World
    {
        List<Object2d> playerObjects = new List<Object2d>();
        List<Object2d> enemies = new List<Object2d>();
        List<Object2d> worldObjects = new List<Object2d>();

        public Player player;
        public MapTexture map; 
        public Camera camera;
        public BarbarianEnemy barb;
        public HealthBar healthBar;

        public World()
        {

            healthBar = new HealthBar("Assets\\hud_heartFull", 
                new Vector2(5000, 5000),
                new Vector2(100, 100),
                new Vector2(1, 0), 0f, 100);

            player = new Player("Assets\\Knight", 
                new Vector2(5000, 5000), 
                new Vector2(100, 100), 
                new Vector2(0, 0), 0f, 100);

            barb = new BarbarianEnemy(player,
                "Assets\\barb",
                new Vector2(5500, 5000),
                new Vector2(120, 120),
                new Vector2(1, 0), 0f, 100);

            map = new MapTexture("Assets\\tex",
                new Vector2(5000, 5000),
                new Vector2(5000, 5000),
                new Vector2(1, 0), 0f, 100);

            

            camera = new Camera(new Vector2(player.pos.X, player.pos.Y));

            playerObjects.Add(healthBar);
            playerObjects.Add(player);
            enemies.Add(barb); 
           
        }


        public void Update(GameTime gameTime)
        {
            camera.pos = player.pos;
            healthBar.pos = player.pos + new Vector2(0, -70);


            for (var i = 0; i < playerObjects.Count; i++)
            {
                if (playerObjects[i].pos.X > camera.pos.X + Globals.gDM.PreferredBackBufferWidth / 2 ||
                    playerObjects[i].pos.X < Globals.gDM.PreferredBackBufferWidth / 2 - camera.pos.X ||
                    playerObjects[i].pos.Y > Globals.gDM.PreferredBackBufferHeight / 2 + camera.pos.Y ||
                    playerObjects[i].pos.Y < Globals.gDM.PreferredBackBufferHeight / 2 - camera.pos.Y)
                {
                    playerObjects.Remove(playerObjects[i]);
                }
            }


            player.primaryCooldownTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            player.secondaryCooldownTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            MouseState mouse = Mouse.GetState();
            
            if (mouse.LeftButton == ButtonState.Pressed)
            {

                if (player.primaryCooldownTimer >= player.playerPrimaryCooldownLength)
                {
                    playerObjects.Add(player.createBulletPrimary());

                    player.primaryCooldownTimer = 0;
                }
            }

            if (mouse.RightButton == ButtonState.Pressed)
            {
                if (player.secondaryCooldownTimer >= player.playerSecondaryCooldownLength)
                {
                    playerObjects.Add(player.createBulletSecondary());
                    player.secondaryCooldownTimer = 2;
                }
            }


            foreach (Object2d obj in playerObjects)
            {
                obj.Update(camera);
            }

            foreach (Object2d enemy in enemies)
            {
                
                enemy.Update(camera);
            }



            // Collision check on enemy

            for (var i = 0; i < playerObjects.Count; i++)
            {
                if (barb != null)
                { 
                    if (
                        isInsideRectangle( // BULLET TOP LEFT
                            playerObjects[i].pos.X - (playerObjects[i].myObject.Width / 2), playerObjects[i].pos.Y - (playerObjects[i].myObject.Height / 2),
                            barb.pos.X - (barb.myObject.Width / 2), barb.pos.Y - (barb.myObject.Height / 2), // BARB TOP LEFT
                            barb.pos.X + (barb.myObject.Width / 2), barb.pos.Y + (barb.myObject.Height / 2) // BARB BOT RIGHT
                            )
                        || isInsideRectangle( // BULLET TOP RIGHT
                            playerObjects[i].pos.X + (playerObjects[i].myObject.Width / 2), playerObjects[i].pos.Y - (playerObjects[i].myObject.Height / 2), 
                            barb.pos.X - (barb.myObject.Width / 2), barb.pos.Y - (barb.myObject.Height / 2), // BARB TOP LEFT
                            barb.pos.X + (barb.myObject.Width / 2), barb.pos.Y + (barb.myObject.Height / 2) // BARB BOT RIGHT
                            )
                        || isInsideRectangle( // BULLET BOT RIGHT
                            playerObjects[i].pos.X + (playerObjects[i].myObject.Width / 2), playerObjects[i].pos.Y + (playerObjects[i].myObject.Height / 2),
                            barb.pos.X - (barb.myObject.Width / 2), barb.pos.Y - (barb.myObject.Height / 2), // BARB TOP LEFT
                            barb.pos.X + (barb.myObject.Width / 2), barb.pos.Y + (barb.myObject.Height / 2) // BARB BOT RIGHT
                            )
                        || isInsideRectangle( // BULLET BOT LEFT
                            playerObjects[i].pos.X - (playerObjects[i].myObject.Width / 2), playerObjects[i].pos.Y + (playerObjects[i].myObject.Height / 2),
                            barb.pos.X - (barb.myObject.Width / 2), barb.pos.Y - (barb.myObject.Height / 2), // BARB TOP LEFT
                            barb.pos.X + (barb.myObject.Width / 2), barb.pos.Y + (barb.myObject.Height / 2) // BARB BOT RIGHT
                            )
                        )
                    {
                        playerObjects.Remove(playerObjects[i]);
                        enemies.Remove(barb); 
                        barb = null;
                    }
                }
            }

        }


        // Check whether sprite rectangle objects intersect with each other
        private bool isInsideRectangle(float x, float y, float r_x_1, float r_y_1, float r_x_2, float r_y_2)
        {
            return r_x_1 <= x && x <= r_x_2 && r_y_1 <= y && y <= r_y_2;
        }
        


        public void Draw()
        {
            map.Draw(0.1f, camera);

            foreach (Object2d enemy in enemies)
            {
                enemy.Draw(0f, camera);
            }

            foreach (Object2d obj in playerObjects)
            {
                obj.Draw(0.5f, camera);
            }

        }
    }
}
