using System;
using Helpers;

namespace Inspectables
{
    public class NameField : InspectableField<NameData>
    {
        
    }

    [Serializable]
    public struct NameData : IComparableField
    {
        public string firstName;
        public string lastName;
        
        private bool mismatchSolved;


        public NameData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            mismatchSolved = false;
        }

        public ComparisonResult Compare(object other)
        {
            if (other is not NameData nameData)
            {
                return ComparisonResult.Irrelevant;
            }

            if (Matches(nameData)) return ComparisonResult.Matched;

            return mismatchSolved ? ComparisonResult.MismatchSolved : ComparisonResult.Mismatched;
        }

        public bool Matches(NameData other)
        {
            return firstName == other.firstName && lastName == other.lastName;
        }
        
        public void SolveMismatch()
        {
            mismatchSolved = true;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }
    }
}