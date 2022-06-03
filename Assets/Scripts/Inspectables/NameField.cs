using System;
using TMPro;
using UnityEngine;

namespace Inspectables
{
    public class NameField : MonoBehaviour, IInspectableField
    {
        [SerializeField] private TextMeshProUGUI nameField;
        [SerializeField] private GameObject highlight;
        private NameData nameData;
        
        
        public void Set(string firstName, string lastName)
        {
            nameData = new NameData {firstName = firstName, lastName = lastName};
            nameField.text = $"{lastName}, {firstName}";
        }

        public IComparableField Inspect()
        {
            highlight.SetActive(true);
            return nameData;
        }

        public void Cancel()
        {
            highlight.SetActive(false);
        }
    }

    [Serializable]
    public struct NameData : IComparableField
    {
        public string firstName;
        public string lastName;

        
        public string Compare(object other)
        {
            if (other is not NameData nameData)
            {
                return "Type Mismatch";
            }

            return Matches(nameData) ? "Yes" : "No";
        }

        public bool Matches(NameData other)
        {
            return firstName == other.firstName && lastName == other.lastName;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }
    }
}