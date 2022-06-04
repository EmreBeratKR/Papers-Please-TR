using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inspectables
{
    public abstract class InspectableField<T> : MonoBehaviour, IInspectableField 
        where T : IComparableField
    {
        [SerializeField] private TMP_Text field;
        [SerializeField] private GameObject highlight;
        private T fieldData;
        private bool inspecting;


        public void Set(T data)
        {
            fieldData = data;
            field.text = data.ToString();
        }

        public IComparableField Inspect()
        {
            if (inspecting) return null;

            inspecting = true;
            highlight.SetActive(true);
            return fieldData;
        }

        public bool TryInspect(out IComparableField comparableField)
        {
            comparableField = Inspect();
            return comparableField is not null;
        }

        public void Cancel()
        {
            inspecting = false;
            highlight.SetActive(false);
        }

        public void SolveMismatch()
        {
            fieldData.SolveMismatch();
        }
    }
}