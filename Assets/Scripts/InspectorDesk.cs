using System.Collections;
using System.Collections.Generic;
using Draggables;
using Helpers;
using UnityEngine;

public class InspectorDesk : Scenegleton<InspectorDesk>, IPointerTarget
{
    public void Target()
    {
        if (!DraggableController.HasDraggable) return;
        
        DraggableController.CurrentDraggable.Open();
    }
}
