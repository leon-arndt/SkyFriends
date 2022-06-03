using ScriptableObjectSystems;
using UnityEngine;

namespace WaveFunctionCollapse
{
    public class LevelGenerator : MonoBehaviour, IResettable
    {
        [SerializeField] private OverlapWFC levelLayer;
        [SerializeField] private ushort layerCount;
        [SerializeField] private ushort layerHeight;
        [SerializeReference] private ScriptableObject[] features;

        private void Start()
        {
            Reset();
        }
        
        public void Reset()
        {
            DeleteGenerated();
            Generate();
        }

        private void DeleteGenerated()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void Generate()
        {
            for (var i = 0; i < layerCount; i++)
            {
                var layer = Instantiate(levelLayer, transform);
                levelLayer.Run();
                layer.transform.localPosition = new Vector3(0, i * layerHeight, 0);
                foreach (var feature in features)
                {
                    if (feature is ILevelGeneratorFeature levelGeneratorFeature)
                    {
                        levelGeneratorFeature.Handle(levelLayer);
                    }
                }
            }
        }
    }

    internal interface ILevelGeneratorFeature
    {
        public void Handle(IOverlapWfcInfo levelLayer);
    }
}