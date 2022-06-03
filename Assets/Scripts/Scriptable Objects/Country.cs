using UnityEngine;
using Random = UnityEngine.Random;

namespace Scriptable_Objects
{
    [CreateAssetMenu(menuName = "My Objects/Country")]
    public class Country : ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private string[] cities;

        public string Name => name;
        public string RandomCity => cities[Random.Range(0, cities.Length)];
    }
}
