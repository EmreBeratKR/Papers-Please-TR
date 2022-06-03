using System;
using TMPro;
using UnityEngine;

namespace Inspectables
{
    public class CityField : MonoBehaviour, IInspectableField
    {
        [SerializeField] private TextMeshProUGUI cityField;
        [SerializeField] private GameObject highlight;
        private CityData locationData;


        public void Set(string cityName)
        {
            locationData = new CityData {cityName = cityName};
            cityField.text = cityName;
        }
        
        public IComparableField Inspect()
        {
            highlight.SetActive(true);
            return locationData;
        }

        public void Cancel()
        {
            highlight.SetActive(false);
        }
    }
    
    [Serializable]
    public struct CityData : IComparableField
    {
        public string cityName;


        public string Compare(object other)
        {
            if (other is not CityData cityData)
            {
                return "Type Mismatch";
            }

            return Matches(cityData) ? "Yes" : "No";
        }

        public bool Matches(CityData other)
        {
            return cityName == other.cityName;
        }

        public override string ToString()
        {
            return cityName;
        }
    }
}