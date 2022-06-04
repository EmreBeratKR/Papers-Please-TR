using System;
using Helpers;
using TMPro;
using UnityEngine;

namespace Inspectables
{
    public class GenderField : InspectableField<GenderData>
    {
        [SerializeField] private TMP_Text field;


        public override void Set(GenderData data)
        {
            base.Set(data);
            field.text = data.ToString();
        }
    }

    
    [Serializable]
    public struct GenderData : IComparableField
    {
        public Gender gender;
        
        private bool mismatchSolved;

        
        public GenderData(Gender gender)
        {
            this.gender = gender;
            mismatchSolved = false;
        }

        public ComparisonResult Compare(object other)
        {
            if (other is not GenderData genderData)
            {
                return ComparisonResult.Irrelevant;
            }

            if (Matches(genderData)) return ComparisonResult.Matched;

            return mismatchSolved ? ComparisonResult.MismatchSolved : ComparisonResult.Mismatched;
        }

        public bool Matches(GenderData other)
        {
            return gender == other.gender;
        }

        public void SolveMismatch()
        {
            mismatchSolved = true;
        }

        public override string ToString()
        {
            return gender.ToString();
        }
    }
}