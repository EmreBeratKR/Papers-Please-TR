using System;
using Person;
using TMPro;
using UnityEngine;

namespace Inspectables
{
    public class GenderField : MonoBehaviour, IInspectableField
    {
        [SerializeField] private TextMeshProUGUI genderField;
        [SerializeField] private GameObject highlight;
        private GenderData genderData;
        
        
        public void Set(Gender gender)
        {
            genderData = new GenderData {gender = gender};
            genderField.text = gender.ToString();
        }
        
        public IComparableField Inspect()
        {
            highlight.SetActive(true);
            return genderData;
        }

        public void Cancel()
        {
            highlight.SetActive(false);
        }
    }

    
    [Serializable]
    public struct GenderData : IComparableField
    {
        public Gender gender;

        
        public string Compare(object other)
        {
            if (other is not GenderData genderData)
            {
                return "Type Mismatch";
            }

            return Matches(genderData) ? "Yes" : "No";
        }

        public bool Matches(GenderData other)
        {
            return gender == other.gender;
        }
        
        public override string ToString()
        {
            return gender.ToString();
        }
    }
}