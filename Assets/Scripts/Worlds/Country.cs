using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Worlds
{
    [Serializable]
    public struct Country
    {
        [SerializeField] private string name;
        [SerializeField] private string[] cities;

        public string Name => name;
        public string RandomCity => cities[Random.Range(0, cities.Length)];
    }
}
