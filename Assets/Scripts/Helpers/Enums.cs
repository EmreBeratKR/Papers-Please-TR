namespace Helpers
{
    public enum Gender { Male, Female }

    public enum ComparisonResult
    {
        Matched,
        Mismatched,
        Irrelevant,
        MismatchSolved
    }




    public static class EnumExtensions
    {
        public static Gender Random(this Gender gender)
        {
            return UnityEngine.Random.Range(0, 2) == 0 ? Gender.Male : Gender.Female;
        }
    }
}
