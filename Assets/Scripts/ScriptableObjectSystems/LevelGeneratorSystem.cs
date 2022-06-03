using UnityEngine;
using WaveFunctionCollapse;

namespace ScriptableObjectSystems
{
    [CreateAssetMenu(menuName = "LevelGeneratorSystem")]
    public class LevelGeneratorSystem : ScriptableObject, IResettable
    {
        public void Reset()
        {
            Object.FindObjectOfType<LevelGenerator>().Reset();
        }
    }
}