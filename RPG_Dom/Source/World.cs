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
        List<Object2d> objects = new List<Object2d>();
        public Player player;
        public Bullet bullet;
        public MapTexture map; 
        public Camera camera;
        public BarbarianEnemy barb;

        public World()
        {

            player = new Player("Assets\\Knight", 
                new Vector2(5000, 5000), 
                new Vector2(200, 200), 
                new Vector2(1, 0), 0f);

            barb = new BarbarianEnemy("Assets\\run_1",
                new Vector2(5500, 5000),
                new Vector2(120, 120),
                new Vector2(1, 0), 0f);

            map = new MapTexture("Assets\\tex",
                new Vector2(5000, 5000),
                new Vector2(0, 0),
                new Vector2(1, 0), 0f);
            objects.Add(map);

            camera = new Camera(new Vector2(player.pos.X, player.pos.Y));

            objects.Add(player);
            objects.Add(barb); 
           
        }


        public void Update(GameTime gameTime)
        {

            camera.pos = player.pos;

            for (var i = 0; i < objects.Count; i++)
            {
                if (objects[i].pos.X > camera.pos.X + Globals.gDM.PreferredBackBufferWidth / 2 ||
                    objects[i].pos.X < Globals.gDM.PreferredBackBufferWidth / 2 - camera.pos.X ||
                    objects[i].pos.Y > Globals.gDM.PreferredBackBufferHeight / 2 + camera.pos.Y ||
                    objects[i].pos.Y < Globals.gDM.PreferredBackBufferHeight / 2 - camera.pos.Y)
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
                    objects.Add(player.createBullet());

                    player.primaryCooldownTimer = 0;
                }
            }

            if (mouse.RightButton == ButtonState.Pressed)
            {
                if (player.secondaryCooldownTimer >= player.playerSecondaryCooldownLength)
                {
                    objects.Add(player.createBullet());

                    player.secondaryCooldownTimer = 0;
                }
            }


            foreach (Object2d obj in objects)
            {
                obj.Update(camera);
            }

           

            // Collision check on enemy

            for (var i = 0; i < objects.Count; i++)
            {
                if (objects[i].GetType() == typeof(BarbarianEnemy))
                {
                    continue;
                }
                if (barb != null)
                {

                    // Fix incorrect hitbox calculations
                    if (
                        isInsideRectangle(objects[i].pos.X, objects[i].pos.Y, barb.pos.X, barb.pos.Y, barb.pos.X + barb.myObject.Width, barb.pos.Y + barb.myObject.Height)
                        || isInsideRectangle(objects[i].pos.X + objects[i].myObject.Width, objects[i].pos.Y, barb.pos.X, barb.pos.Y, barb.pos.X + barb.myObject.Width, barb.pos.Y + barb.myObject.Height)
                        || isInsideRectangle(objects[i].pos.X + objects[i].myObject.Width, objects[i].pos.Y + objects[i].myObject.Height, barb.pos.X, barb.pos.Y, barb.pos.X + barb.myObject.Width, barb.pos.Y + barb.myObject.Height)
                        || isInsideRectangle(objects[i].pos.X, objects[i].pos.Y + objects[i].myObject.Height, barb.pos.X, barb.pos.Y, barb.pos.X + barb.myObject.Width, barb.pos.Y + barb.myObject.Height)
                        )
                    {
                        objects.Remove(objects[i]);
                        objects.Remove(barb); 
                        barb = null;
                    }
                }
            }

        }

        private bool isInsideRectangle(float x, float y, float r_x_1, float r_y_1, float r_x_2, float r_y_2)
        {
            return r_x_1 <= x && x <= r_x_2 && r_y_1 <= y && y <= r_y_2;
        }
        
        public void Draw()
        {

            var i = 0f;
            foreach (Object2d obj in objects)
            {
                obj.Draw(i, camera);
                i += 0.001f;
            }
        }
    }
}
