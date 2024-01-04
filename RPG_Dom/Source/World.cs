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

        // private ConsumableFactory consumableFactory;


        public World()
        {
            // Create factory, classes that return some new instances of these class, could make e.g.:
            // - PlayerFactory with create() which return an instance of Player etc
            // - PlayerPetFactory with public PlayerPet create(Player player) which return an instance of Player etc
            // - ConsumableFactory with public Consumable create(Barbarian barb) which return an instance of Player etc

            /*healthBar = new HealthBar("Assets\\element_red_rectangle",
                new Vector2(5000, 5000),
                new Vector2(100, 100),
                new Vector2(1, 0), 0f, 100);*/

            player = new Player(10, "Assets\\Knight",
                new Vector2(5000, 5000),
                new Vector2(100, 100),
                new Vector2(0, 0), 0f);

           
            

            // WHY DOES THIS SHIT NOT WORK BUT CREATING MANUALLY BELOW DOES REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
            for (int i = 0; i < numOfBarbs; i++)
            {
                enemies.Add(BarbarianFactory.Create(player));
            }



            map = new MapTexture("Assets\\tex",
                new Vector2(5000, 5000),
                new Vector2(5000, 5000),
                new Vector2(1, 0), 0f);



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
                    playerObjects.Add(player.CreateBulletPrimary());

                    player.primaryCooldownTimer = 0;
                }
            }

            if (mouse.RightButton == ButtonState.Pressed)
            {
                if (player.secondaryCooldownTimer >= player.playerSecondaryCooldownLength)
                {
                    playerObjects.Add(player.CreateBulletSecondary());
                    player.secondaryCooldownTimer = 2;
                }
            }

            player.Update(camera);



            // Create IUpdateable interface
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


            //IMPLEMENT COLLISION FROM COLLISION.CS
            

            List<CollisionEvent<Object2d>> collisions = Collision.ObjectListCollision(enemies, playerObjects);
            
            foreach (CollisionEvent<Object2d> collision in collisions)
            {
                // How to create pet factory using collision pos data?
                enemies.Remove(collision.CollidingObject1);
                playerObjects.Remove(collision.CollidingObject2);
                powerup = new PowerUp("Assets\\chest_open_3",
                               new Vector2(collision.CollidingObject1.pos.X, collision.CollidingObject1.pos.Y),
                               new Vector2(100, 100),
                               new Vector2(0, 0),
                               0f);
                consumables.Add(powerup);
            }


            List<CollisionEvent<Object2d>> consumableCollisions = Collision.ObjectCollision(player, consumables);

            foreach (CollisionEvent<Object2d> collision in consumableCollisions)
            {
                pets.Add(PlayerPetFactory.Create(player));
                consumables.Remove(collision.CollidingObject2);
                player.primaryCooldownTimer += 100;
                player.speedMult *= 1.02f;
            }
        }


        // Create IDrawable interface
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