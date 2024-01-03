using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Dom
{
    public class CollisionEvent<T>
    {
        public T CollidingObject1;
        public T CollidingObject2;

        public CollisionEvent(T collidingObject1, T collidingObject2)
        {
            CollidingObject1 = collidingObject1;
            CollidingObject2 = collidingObject2;
        }     
    }
}
