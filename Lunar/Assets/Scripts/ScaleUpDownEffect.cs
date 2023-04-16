using DG.Tweening;
using UnityEngine;

namespace LunarJam
{
    public class ScaleUpDownEffect : MonoBehaviour
    {
        [SerializeField] private float newScale = 1.25f;
        [SerializeField] private float duration = 0.5f;
        
        private void Start()
        {
            Invoke(nameof(StartScale), 0.01f);
        }

        private void StartScale()
        {
            newScale = transform.localScale.x + 0.25f;
            transform.DOScale(newScale, duration).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
