using UnityEngine;

namespace ScriptableObjectSystems
{
    [CreateAssetMenu(menuName = nameof(LifeTimeSystem))]
    public class LifeTimeSystem : ScriptableObject, IResettable
    {
        [SerializeField] private ScriptableObject[] systemsToReset;

        public void Reset()
        {
            foreach (var system in systemsToReset)
            {
                if (system is IResettable resettable)
                {
                    resettable.Reset();
                }
            }
        }
    }
}