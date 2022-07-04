using UnityEngine;
using WorldEntity;

namespace WaveFunctionCollapse
{
    [CreateAssetMenu(menuName = nameof(PortalExit))]
    public class PortalExit : ScriptableObject, ILevelGeneratorFeature
    {
        [SerializeField] private Transform prefab;

        public void Handle(IOverlapWfcInfo levelLayer)
        {
            var portals = FindObjectsOfType<Portal>();

            foreach (var portal in portals)
            {
                if (portal.target != null) continue;
                var uniquePrefab = Instantiate(prefab, levelLayer.Transform);
                uniquePrefab.gameObject.transform.localPosition = new Vector3(
                    Random.Range(0, levelLayer.Size.x),
                    1,
                    -Random.Range(0, levelLayer.Size.y)
                );

                portal.target = uniquePrefab;
                return;
            }
        }
    }
}
