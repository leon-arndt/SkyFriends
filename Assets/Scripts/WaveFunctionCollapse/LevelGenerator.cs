using UnityEngine;

namespace WaveFunctionCollapse
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject levelLayer;
        [SerializeField] private ushort layerCount;
        [SerializeField] private ushort layerHeight;

        private void Start()
        {
            for (var i = 0; i < layerCount; i++)
            {
                var layer = Instantiate(levelLayer, transform);
                layer.transform.localPosition = new Vector3(0, i * layerHeight, 0);
            }
        }
    }
}