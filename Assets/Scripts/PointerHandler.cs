using System.Collections.Generic;
using Draggables;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PointerHandler : MonoBehaviour
{
    public const float DoubleClickInterval = 0.5f;
    
    public static Vector2 PointerPosition;

    private static readonly List<RaycastResult> RaycastResults = new();



    private void CheckDraggable()
    {
        if (!DraggableController.HasDraggable) return;
        
        var eventData = new PointerEventData(EventSystem.current)
        {
            position = DraggableController.CurrentDraggable.transform.position
        };

        EventSystem.current.RaycastAll(eventData, RaycastResults);

        foreach (var raycastResult in RaycastResults)
        {
            if (raycastResult.gameObject.TryGetComponent(out IPointerTarget target))
            {
                target.Target();
            }
        }
    }
    
    public void OnPointerPoint(InputAction.CallbackContext context)
    {
        PointerPosition = context.ReadValue<Vector2>();
        
        CheckDraggable();
    }
}
