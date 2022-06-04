using NaughtyAttributes;
using Person;
using Scriptable_Objects;
using UnityEngine;

namespace Draggables
{
    public class DocumentGenerator : MonoBehaviour
    {
        [SerializeField] private DocumentContainer passports; 
        [SerializeField] private PersonIdentity identity;


        [Button()]
        public void GeneratePassport()
        {
            Passport newPassport = Instantiate((Passport)passports.Random, DraggableController.DragPanel);
            newPassport.Generate(identity);
        }
    }
}
