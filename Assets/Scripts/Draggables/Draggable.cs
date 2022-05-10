using UnityEngine;
using UnityEngine.EventSystems;

namespace Draggables
{
    public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private GameObject closed;
        [SerializeField] private GameObject opened;
        
        private RectTransform rectTransform;

        private State state;
        
        private bool isDragging;
    
        private Vector2 dragStartPosition;
        private Vector2 pointerStartPosition;


        public Vector2 ActiveSize
        {
            get
            {
                switch (state)
                {
                    default : return closed.GetComponent<RectTransform>().rect.size;
                    
                    case State.Open : return opened.GetComponent<RectTransform>().rect.size;
                }
            }
        }


        private void Start()
        {
            rectTransform = this.GetComponent<RectTransform>();
        }
    
        private void Update()
        {
            Drag();
        }
    
        private void Drag()
        {
            if (!isDragging) return;

            var pointerDelta = PointerHandler.PointerPosition - pointerStartPosition;

            rectTransform.position = dragStartPosition + pointerDelta;
        
            DraggableController.Limit(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            DraggableController.CurrentDraggable = this;
            isDragging = true;
            dragStartPosition = rectTransform.position;
            pointerStartPosition = PointerHandler.PointerPosition;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isDragging = false;
        }

        public void Open()
        {
            closed.SetActive(false);
            opened.SetActive(true);

            state = State.Open;
        }

        public void Close()
        {
            opened.SetActive(false);
            closed.SetActive(true);

            state = State.Close;
        }
    }

    public enum State
    {
        Close,
        Open
    }
}
