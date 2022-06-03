using UnityEngine;

namespace WaveFunctionCollapse
{
    [CreateAssetMenu(menuName = nameof(Creature))]
    public class Creature : ScriptableObject, ILevelGeneratorFeature
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private uint maxCount = 5;

        public void Handle(IOverlapWfcInfo levelLayer)
        {
            for (int i = 0; i < maxCount; i++)
            {
                var uniquePrefab = Instantiate(prefab, levelLayer.Transform);
                uniquePrefab.transform.localPosition = new Vector3(
                    Random.Range(0, levelLayer.Size.x),
                    1,
                    -Random.Range(0, levelLayer.Size.y)
                );
            }
        }
    }
}