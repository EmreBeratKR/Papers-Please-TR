using System;
using Helpers;

namespace Inspectables
{
    public class CityField : InspectableField<CityData>
    {
        
    }
    
    [Serializable]
    public struct CityData : IComparableField
    {
        public string cityName;

        private bool mismatchSolved;


        public CityData(string cityName)
        {
            this.cityName = cityName;
            mismatchSolved = false;
        }

        public ComparisonResult Compare(object other)
        {
            if (other is not CityData cityData)
            {
                return ComparisonResult.Irrelevant;
            }

            if (Matches(cityData)) return ComparisonResult.Matched;

            return mismatchSolved ? ComparisonResult.MismatchSolved : ComparisonResult.Mismatched;
        }

        public bool Matches(CityData other)
        {
            return cityName == other.cityName;
        }
        
        public void SolveMismatch()
        {
            mismatchSolved = true;
        }

        public override string ToString()
        {
            return cityName;
        }
    }
}