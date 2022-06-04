using Inspectables;
using Person;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Draggables
{
    public class Passport : Document
    {
        [SerializeField] private NameField nameField;
        [SerializeField] private GenderField genderField;
        [SerializeField] private CityField cityField;
        
        
        public void Generate(PersonIdentity identity)
        {
            nameField.Set(new NameData{firstName = identity.Firstname, lastName = identity.Lastname});
            genderField.Set(new GenderData{gender = identity.Gender});
            cityField.Set(new CityData{cityName = identity.City});
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            if (clicked.TryGetComponent(out IInspectableField inspectable))
            {
                InspectorBooth.Compare(inspectable);
            }
        }
    }
}
