using System;
using Helpers;
using UnityEngine;

namespace Worlds
{
    public class World : Scenegleton<World>
    {
        [SerializeField] private Location boothEntrance;
        public static Vector3 BoothEntrance => Instance.boothEntrance.Position;
        
        [SerializeField] private Location booth;
        public static Vector3 Booth => Instance.booth.Position;
        
        [SerializeField] private Location boothExit;
        public static Vector3 BoothExit => Instance.boothExit.Position;


    }
    
    
    
    
    
    
    [Serializable]
    internal struct Location
    {
        [SerializeField] private Transform location;
        public Vector3 Position => location.position;
    }
}
