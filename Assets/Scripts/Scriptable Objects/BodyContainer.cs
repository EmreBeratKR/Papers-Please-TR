using Procedural_Generators;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(menuName = "My Containers/New Body Container")]
    public class BodyContainer : ScriptableObject
    {
        [SerializeField] private BodyGenerator[] bodyGenerators;


        public BodyGenerator RandomGenerator
        {
            get => bodyGenerators[Random.Range(0, bodyGenerators.Length)];
        }
    }
}
