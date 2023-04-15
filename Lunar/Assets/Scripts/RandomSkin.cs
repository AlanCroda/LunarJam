using System.Collections.Generic;
using UnityEngine;

namespace LunarJam
{
    public class RandomSkin : MonoBehaviour
    {
        [SerializeField] private List<Sprite> skins;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            ShuffleList(skins);
            var rand = Random.Range(0, skins.Count);
            spriteRenderer.sprite = skins[rand];
        }
        
        // Makes it more random, idk why
        private void ShuffleList(List<Sprite> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var rand = Random.Range(i, list.Count);
                (list[i], list[rand]) = (list[rand], list[i]);
            }
        }

    }
}
