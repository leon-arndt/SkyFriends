using UnityEngine;
using WaveFunctionCollapse;

namespace ScriptableObjectSystems
{
    [CreateAssetMenu(menuName = "LevelGeneratorSystem")]
    public class LevelGeneratorSystem : ScriptableObject, IResettable
    {
        [SerializeReference] private ScriptableObject[] features;
        private LevelGenerator _levelGenerator;

        public void Reset()
        {
            _levelGenerator = FindObjectOfType<LevelGenerator>();
            if (_levelGenerator == null) return;

            _levelGenerator.SetFeatures(features);
            _levelGenerator.Reset();
        }
    }
}