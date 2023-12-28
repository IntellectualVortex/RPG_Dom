#region Includes
using System.IO;
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
using System.Runtime.ConstrainedExecution;
#endregion

namespace RPG_Dom
{
    public class World
    {
        private int numOfBarbs = 20;
        Random rnd = new Random();

        List<Object2d> playerObjects = new List<Object2d>();
        List<Object2d> enemies = new List<Object2d>();
        List<Object2d> worldObjects = new List<Object2d>();
        List<Object2d> consumables = new List<Object2d>();
        List<Object2d> pets = new List<Object2d>();

        //Figure out how to categorize HUD objects

        public PlayerPet pet;
        public Player player;
        public MapTexture map;
        public Camera camera;
        //public HealthBar healthBar;
        public PowerUp powerup;

        public World()
        {

            /*healthBar = new HealthBar("Assets\\element_red_rectangle",
                new Vector2(5000, 5000),
                new Vector2(100, 100),
                new Vector2(1, 0), 0f, 100);*/

            player = new Player(2, "Assets\\Knight",
                new Vector2(5000, 5000),
                new Vector2(100, 100),
                new Vector2(0, 0), 0f, 100);


            pet = new PlayerPet(player, "Assets\\pet",
                new Vector2(5100, 5100),
                new Vector2(100, 100),
                new Vector2(1, 0), 0f, 100);

            pets.Add(pet);

            // WHY DOES THIS SHIT NOT WORK BUT CREATING MANUALLY BELOW DOES REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
            for (int i = 0; i < numOfBarbs; i++)
            {
                enemies.Add(new BarbarianEnemy(player,
                    "Assets\\barb",
                    new Vector2(5500 + rnd.Next(-500, 500), 5000 + rnd.Next(-500, 500)),
                    new Vector2(120, 120),
                    new Vector2(1, 0), 0f, 100));
            }



            map = new MapTexture("Assets\\tex",
                new Vector2(5000, 5000),
                new Vector2(5000, 5000),
                new Vector2(1, 0), 0f, 100);



            camera = new Camera(new Vector2(player.pos.X, player.pos.Y));

            //playerObjects.Add(healthBar);
            //playerObjects.Add(player);



        }


        public void Update(GameTime gameTime)
        {
            camera.pos = player.pos;
            //healthBar.pos = player.pos + new Vector2(0, -70);

            // Remove bullets if reach end of screen space
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

            // Player primary and secondary attack cooldowns
            player.primaryCooldownTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            player.secondaryCooldownTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            MouseState mouse = Mouse.GetState();


            // Instantiating Bullet isntances on left/right mouse clicks
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

            player.Update(camera);

            foreach (Object2d obj in playerObjects)
            {
                obj.Update(camera);
            }

            foreach (Object2d enemy in enemies)
            {
                enemy.Update(camera);
            }

            foreach (Object2d obj in consumables)
            {
                obj.Update(camera);
            }

            foreach (Object2d obj in pets)
            {
                obj.Update(camera);
            }


            if (Collision.ObjectListCollision(playerObjects, enemies))
            {
                powerup = new PowerUp("Assets\\chest_open_3",
                new Vector2(enemies[j].pos.X, enemies[j].pos.Y),
                new Vector2(100, 100),
                new Vector2(0, 0),
                0f, 100);

                playerObjects.Remove(playerObjects[i]);
                enemies.Remove(enemies[j]);
                consumables.Add(powerup);
            }






            for (var k = 0; k < consumables.Count; k++) 
            { 

                if (
                    isInsideRectangle( // BULLET TOP LEFT
                        player.pos.X - (player.myObject.Width / 2), player.pos.Y - (player.myObject.Height / 2),
                        consumables[k].pos.X - (consumables[k].myObject.Width / 2), consumables[k].pos.Y - (consumables[k].myObject.Height / 2), // BARB TOP LEFT
                        consumables[k].pos.X + (consumables[k].myObject.Width / 2), consumables[k].pos.Y + (consumables[k].myObject.Height / 2) // BARB BOT RIGHT
                        )
                    || isInsideRectangle( // BULLET TOP RIGHT
                        player.pos.X + (player.myObject.Width / 2), player.pos.Y - (player.myObject.Height / 2),
                        consumables[k].pos.X - (consumables[k].myObject.Width / 2), consumables[k].pos.Y - (consumables[k].myObject.Height / 2), // BARB TOP LEFT
                        consumables[k].pos.X + (consumables[k].myObject.Width / 2), consumables[k].pos.Y + (consumables[k].myObject.Height / 2) // BARB BOT RIGHT
                        )
                    || isInsideRectangle( // BULLET BOT RIGHT
                        player.pos.X + (player.myObject.Width / 2), player.pos.Y + (player.myObject.Height / 2),
                        consumables[k].pos.X - (consumables[k].myObject.Width / 2), consumables[k].pos.Y - (consumables[k].myObject.Height / 2), // BARB TOP LEFT
                        consumables[k].pos.X + (consumables[k].myObject.Width / 2), consumables[k].pos.Y + (consumables[k].myObject.Height / 2) // BARB BOT RIGHT
                        )
                    || isInsideRectangle( // BULLET BOT LEFT
                        player.pos.X - (player.myObject.Width / 2), player.pos.Y + (player.myObject.Height / 2),
                        consumables[k].pos.X - (consumables[k].myObject.Width / 2), consumables[k].pos.Y - (consumables[k].myObject.Height / 2), // BARB TOP LEFT
                        consumables[k].pos.X + (consumables[k].myObject.Width / 2), consumables[k].pos.Y + (consumables[k].myObject.Height / 2) // BARB BOT RIGHT
                        )
                    )
                {
                    consumables.Remove(consumables[k]);
                    player.primaryCooldownTimer += 100;
                    player.speedMult *= 1.2f;
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
            player.Draw(0f, camera);

            foreach (Object2d enemy in enemies)
            {
                enemy.Draw(0f, camera);
            }

            foreach (Object2d obj in playerObjects)
            {
                obj.Draw(0.5f, camera);
            }

            foreach (Object2d obj in consumables)
            {
                obj.Draw(0.5f, camera);
            }
            foreach (Object2d obj in pets)
            {
                obj.Draw(0.5f, camera);
            }

        }
    }
}