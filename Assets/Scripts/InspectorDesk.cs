using Draggables;
using Helpers;

public class InspectorDesk : Scenegleton<InspectorDesk>, IPointerTarget
{
    public void Target()
    {
        if (!DraggableController.HasDraggable) return;
        
        DraggableController.CurrentDraggable.Open();
    }
}
