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
                Random.Range(0, levelLayer.Size.x),
                1,
                -Random.Range(0, levelLayer.Size.y)
            );
        }
    }
}