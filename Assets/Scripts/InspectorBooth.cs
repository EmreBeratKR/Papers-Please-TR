using System.Collections;
using System.Collections.Generic;
using Draggables;
using Helpers;
using UnityEngine;

public class InspectorBooth : Scenegleton<InspectorBooth>, IPointerTarget
{
    public void Target()
    {
        if (!DraggableController.HasDraggable) return;
        
        DraggableController.CurrentDraggable.Close();
    }
}
