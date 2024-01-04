using RPG_Dom.Interfaces;
using System;
using System.Collections.Generic;
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
    

        public static List<CollisionEvent<T>> ObjectListCollision<T>(List<T> objList, List<T> objList2) where T : IHitbox
        {

            List<CollisionEvent<T>> CollisionEvents = new List<CollisionEvent<T>>();

            for (var j = 0; j < objList.Count; j++)
            {
                for (var i = 0; i < objList2.Count; i++)
                {
                    if (objList[j].Hitbox().Intersects(objList2[i].Hitbox()))
                    {
                        CollisionEvents.Add(new CollisionEvent<T>(objList[j], objList2[i]));
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

