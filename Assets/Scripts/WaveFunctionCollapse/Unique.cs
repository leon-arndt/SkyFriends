using UnityEngine;

namespace WaveFunctionCollapse
{
    [CreateAssetMenu(menuName = nameof(Unique))]
    public class Unique : ScriptableObject, ILevelGeneratorFeature
    {
        [SerializeField] private GameObject prefab;
        
        public void Handle(IOverlapWfcInfo levelLayer)
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