using UnityEngine;
using UnityEngine.EventSystems;

namespace LunarJam
{
    public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
    {
        [SerializeField] private AudioClip hoverSound;
        [SerializeField] private AudioClip clickSound;

        private AudioSource source;

        private void Awake()
        {
            source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            source.clip = hoverSound;
            source.Play();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            source.clip = clickSound;
            source.Play();
        }
    }
}
