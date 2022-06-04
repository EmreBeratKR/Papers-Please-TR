using Draggables;
using Helpers;
using Inspectables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InspectorBooth : Scenegleton<InspectorBooth>, IPointerTarget
{
    [SerializeField] private GameObject comparisonPanel;
    
    private IInspectableField firstInspectableField;
    private IInspectableField secondInspectableField;

    private float lastClickedTime;
    private bool isComparing;

    public UnityEvent<bool> onComparisonToggled;
    private static void ComparisonToggled(bool isActive) => Instance.onComparisonToggled?.Invoke(isActive);


    public static void Compare(IInspectableField inspectableField)
    {
        var currentTime = Time.time;
        var deltaTime = currentTime - Instance.lastClickedTime;

        if (deltaTime <= PointerHandler.DoubleClickInterval)
        {
            EnableComparison();
        }
        
        Instance.lastClickedTime = currentTime;
        
        if (!Instance.isComparing) return;
        
        if (!inspectableField.TryInspect(out var firstComparableField))
        {
            if (inspectableField == Instance.firstInspectableField)
            {
                inspectableField.Cancel();
                Instance.firstInspectableField = Instance.secondInspectableField;
                Instance.secondInspectableField = null;
            }
            
            else if (inspectableField == Instance.secondInspectableField)
            {
                inspectableField.Cancel();
                Instance.secondInspectableField = null;
            }
            
            return;
        }
        
        if (Instance.firstInspectableField is null)
        {
            inspectableField.Inspect();
            Instance.firstInspectableField = inspectableField;
            return;
        }

        Instance.firstInspectableField.Cancel();
        Instance.secondInspectableField?.Cancel();

        Instance.secondInspectableField = Instance.firstInspectableField;
        Instance.firstInspectableField = inspectableField;
        
        Instance.secondInspectableField.TryInspect(out var secondComparableField);
        
        Debug.Log($"{firstComparableField} : {secondComparableField} = {firstComparableField.Compare(secondComparableField)}");
    }

    public static void EnableComparison()
    {
        Instance.isComparing = true;
        Instance.comparisonPanel.SetActive(true);
        ComparisonToggled(true);
    }
    
    public static void DisableComparison()
    {
        Instance.firstInspectableField?.Cancel();
        Instance.firstInspectableField = null;
        Instance.secondInspectableField?.Cancel();
        Instance.secondInspectableField = null;
        
        Instance.isComparing = false;
        Instance.comparisonPanel.SetActive(false);
        ComparisonToggled(false);
    }

    public static void OnComparisonToggled(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (Instance.isComparing)
        {
            DisableComparison();
            return;
        }
        
        EnableComparison();
    }
    
    public void Target()
    {
        if (!DraggableController.HasDraggable) return;
        
        DraggableController.CurrentDraggable.Close();
    }
}
