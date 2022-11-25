using UnityEngine;

namespace Models
{
    public class BallData
    {
        public BallData(Rigidbody2D rigidbody, GameObject obj)
        {
            
            Rigidbody = rigidbody;
            Obj = obj;
        }

        public Rigidbody2D Rigidbody { get; private set; }
        
        public GameObject Obj { get; private set; }
        
    }
}