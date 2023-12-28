using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Dom
{
    public struct CollisionEvent
    {
        public Object2d CollidingObject1;
        public Object2d CollidingObject2;

        public CollisionEvent(Object2d collidingObject1, Object2d collidingObject2)
        {
            CollidingObject1 = collidingObject1;
            CollidingObject2 = collidingObject2;
        }     
    }
}
