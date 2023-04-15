using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarJam
{
    public class CameraShake : MonoBehaviour
    {
        public static CameraShake instance;
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private float duration;

        private void Awake()
        {
            instance = this;
        }

        public void Shake()
        {
            StartCoroutine(Shaking());
        }

        private IEnumerator Shaking()
        {
            Vector3 startPosition = transform.position;
            float elapsedTime = 0;

            while(elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float strength = curve.Evaluate(elapsedTime / duration);
                transform.position = startPosition + Random.insideUnitSphere * strength;
                yield return null;
            }

            transform.position = startPosition;
        }
    }
}
