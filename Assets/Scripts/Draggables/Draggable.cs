using Inspectables;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Draggables
{
    public abstract class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField] private GameObject closed;
        [SerializeField] private GameObject opened;

        protected GameObject clicked;
        
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

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            clicked = eventData.pointerPressRaycast.gameObject;
        }
    }

    public enum State
    {
        Close,
        Open
    }
}
