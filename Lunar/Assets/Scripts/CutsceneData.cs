using UnityEngine;

namespace LunarJam
{
    [CreateAssetMenu(menuName = "Cutscene/Cutscene Data", fileName = "New Cutscene Data")]
    public class CutsceneData : ScriptableObject
    {
        public Sprite cutsceneSprite;
        [TextArea] public string cutsceneText;
    }
}
