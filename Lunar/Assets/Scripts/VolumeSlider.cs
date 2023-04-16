using UnityEngine;
using UnityEngine.UI;

namespace LunarJam
{
    public class VolumeSlider : MonoBehaviour
    {
        private void Start()
        {
            GameManager.instance.SetVolumeSlider(GetComponent<Slider>());
        }
    }
}