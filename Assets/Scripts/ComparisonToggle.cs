using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ComparisonToggle : MonoBehaviour
{
    [SerializeField] private Sprite enableSprite;
    [SerializeField] private Sprite cancelSprite;

    private Toggle toggle;


    private void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void OnComparisonToggled(bool isActive)
    {
        toggle.isOn = isActive;
        toggle.image.sprite = isActive ? cancelSprite : enableSprite;
    }

    public void OnValueChanged(bool isOn)
    {
        toggle.image.sprite = isOn ? cancelSprite : enableSprite;

        if (isOn)
        {
            InspectorBooth.EnableComparison();
        }
        else
        {
            InspectorBooth.DisableComparison();
        }
    }
}
