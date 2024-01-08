
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Dom
{
    public static class Collision
    {
        static Collision() { }
    

        public static List<CollisionEvent<T>> ObjectListCollision<T>(List<T> objList, List<T> objList2) where T : IHitbox, IHealthbar
        {

            List<CollisionEvent<T>> CollisionEvents = new List<CollisionEvent<T>>();

            for (var j = 0; j < objList.Count; j++)
            {
                for (var i = 0; i < objList2.Count; i++)
                {

                    // Add both the enemy and the bullet to the CollisionEvent if health equal to or below 0
                    if (objList[j].Hitbox().Intersects(objList2[i].Hitbox()) && objList[j].GetHealth() <= 0)
                    {
                        CollisionEvents.Add(new CollisionEvent<T>(objList[j], objList2[i]));
                    }


                    // Only add bullet to the CollisionEvent for removal on hit if health above 0
                    else if (objList[j].Hitbox().Intersects(objList2[i].Hitbox()) && objList[j].GetHealth() > 0)
                    {
                        CollisionEvents.Add(new CollisionEvent<T>(default, objList2[i]));
                    }
                }
            }
            return CollisionEvents;
        }

        public static List<CollisionEvent<T>> ObjectCollision<T>(T obj, List<T> objList2) where T : IHitbox
        {

            List<CollisionEvent<T>> CollisionEvents = new List<CollisionEvent<T>>();

                for (var i = 0; i < objList2.Count; i++)
                {
                    if (obj.Hitbox().Intersects(objList2[i].Hitbox()))
                    {
                        CollisionEvents.Add(new CollisionEvent<T>(obj, objList2[i]));
                    }
                }
            return CollisionEvents;
        }
    }

}

