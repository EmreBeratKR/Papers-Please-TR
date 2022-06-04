using NaughtyAttributes;
using Scriptable_Objects;
using UnityEngine;

namespace Person
{
    public class PersonGenerator : MonoBehaviour
    {
        [SerializeField] private BodyContainer bodies;
        [SerializeField] private PersonIdentity identity;
        [SerializeField] private Transform appearance;
        
        private BodyGenerator body;


        [Button()]
        public void Generate()
        {
            if (body == null)
            {
                body = Instantiate(bodies.Random, appearance);
            }
            
            body.Generate(out var faceSerial);
            
            identity.Generate(faceSerial);

            Debug.Log(faceSerial);
        }

        public Coroutine Illuminate()
        {
            return body.Illuminate();
        }
        
        public Coroutine BlackOut()
        {
            return body.BlackOut();
        }
    }
}
