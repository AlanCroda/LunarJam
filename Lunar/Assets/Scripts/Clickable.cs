using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace LunarJam
{
    public class Clickable : MonoBehaviour, IPointerDownHandler
    {
        public UnityEvent onClicked;

        public void OnPointerDown(PointerEventData eventData)
        {
            onClicked?.Invoke();
        }
    }
}
