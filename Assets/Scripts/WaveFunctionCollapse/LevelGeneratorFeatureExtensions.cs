using UnityEngine;

namespace WaveFunctionCollapse
{
    public static class LevelGeneratorFeatureExtensions
    {
        public static Vector3 GetConstrainedRandom(this ILevelGeneratorFeature feature, Vector3 root, Vector3 bounds)
        {
            return new Vector3(
                root.x + Random.Range(0, bounds.x),
                root.y + Random.Range(0, bounds.y),
                root.z + Random.Range(0, bounds.z)
            );
        }
    }
}