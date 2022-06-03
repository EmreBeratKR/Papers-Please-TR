using Draggables;
using Helpers;
using Inspectables;
using UnityEngine;

public class InspectorBooth : Scenegleton<InspectorBooth>, IPointerTarget
{
    private IInspectableField firstInspectableField;
    private IInspectableField secondInspectableField;


    public static void Compare(IInspectableField inspectableField)
    {
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

        var firstComparableField = Instance.firstInspectableField.Inspect();
        var secondComparableField = Instance.secondInspectableField.Inspect();
        
        Debug.Log($"{firstComparableField} : {secondComparableField} = {firstComparableField.Compare(secondComparableField)}");
    }
    
    public void Target()
    {
        if (!DraggableController.HasDraggable) return;
        
        DraggableController.CurrentDraggable.Close();
    }
}
