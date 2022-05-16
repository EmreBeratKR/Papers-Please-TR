using UnityEngine;

namespace Procedural_Generators
{
    public class BodyGenerator : MonoBehaviour
    {
        [SerializeField] private SpriteContainer[] bodyParts;


        public void Generate()
        {
            foreach (var bodyPart in bodyParts)
            {
                bodyPart.Generate();
            }
        }
    }
}
