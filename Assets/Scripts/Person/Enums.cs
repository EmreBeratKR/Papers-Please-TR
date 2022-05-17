using UnityEngine;

namespace Person
{
    public enum Gender { Male, Female }




    public static class EnumExtensions
    {
        public static Gender Random(this Gender gender)
        {
            return UnityEngine.Random.Range(0, 2) == 0 ? Gender.Male : Gender.Female;
        }
    }
}
