using DG.Tweening;
using UnityEngine;

namespace LunarJam
{
    public class DoMoveUpDown : MonoBehaviour
    {
        [SerializeField] private float newY;
        [SerializeField] private float duration = 1f;

        private void Start()
        {
            transform.DOLocalMoveY(newY, duration).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
