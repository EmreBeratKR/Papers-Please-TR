using Helpers;
using UnityEngine;

namespace Draggables
{
    public class DraggableController : Scenegleton<DraggableController>
    {
        [SerializeField] private RectTransform dragPanel;
        [SerializeField] private RectTransform topAnchor;
        [SerializeField] private RectTransform bottomAnchor;
        [SerializeField] private RectTransform rightAnchor;
        [SerializeField] private RectTransform leftAnchor;


        public static RectTransform DragPanel => Instance.dragPanel;
        
        public static Draggable CurrentDraggable;
        public static bool HasDraggable => CurrentDraggable != null; 
    
    
        public static void Limit(Draggable draggable)
        {
            var position = draggable.transform.position;
            var halfSize = draggable.ActiveSize * 0.5f * GameCanvas.Scale;
        
            var xMin = Instance.leftAnchor.position.x + halfSize.x;
            var xMax = Instance.rightAnchor.position.x - halfSize.x;

            var yMin = Instance.bottomAnchor.position.y + halfSize.y;
            var yMax = Instance.topAnchor.position.y - halfSize.y;

            position.x = Mathf.Clamp(position.x, xMin, xMax);
            position.y = Mathf.Clamp(position.y, yMin, yMax);

            draggable.transform.position = position;
        }
    }
}
