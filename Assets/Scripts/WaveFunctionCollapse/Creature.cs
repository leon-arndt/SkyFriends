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
                    Random.Range(-levelLayer.Size.x / 2, levelLayer.Size.x / 2),
                    0,
                    Random.Range(-levelLayer.Size.y / 2, levelLayer.Size.y / 2)
                );
            }
        }
    }
}