using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LunarJam
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;

        private void Start()
        {
            transform.DORotate(new Vector3(0f, 0f, Random.Range(-90f, 91f)), Random.Range(0.1f, rotationSpeed + 0.00001f)).SetLoops(-1, LoopType.Incremental);
        }
    }
}
