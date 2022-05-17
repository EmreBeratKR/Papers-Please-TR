using Person;
using TMPro;
using UnityEngine;

namespace Draggables
{
    public class Passport : Document
    {
        [SerializeField] private TextMeshProUGUI nameField;
        [SerializeField] private TextMeshProUGUI genderField;
        [SerializeField] private TextMeshProUGUI cityField;
        
        
        public void Generate(PersonIdentity identity)
        {
            nameField.text = $"{identity.Lastname}, {identity.Firstname}";
            genderField.text = identity.Gender.ToString();
            cityField.text = identity.City;
        }
    }
}
