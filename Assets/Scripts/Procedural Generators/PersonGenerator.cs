using NaughtyAttributes;
using Scriptable_Objects;
using UnityEngine;

namespace Procedural_Generators
{
    public class PersonGenerator : MonoBehaviour
    {
        [SerializeField] private BodyContainer bodies;
        [SerializeField] private Transform appearance;

        private BodyGenerator body;


        [Button()]
        public void Generate()
        {
            if (body == null)
            {
                body = Instantiate(bodies.RandomGenerator, appearance);
            }
            
            body.Generate();
        }
    }
}
