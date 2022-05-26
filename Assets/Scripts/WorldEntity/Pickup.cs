using ScriptableObjectSystems;
using UnityEngine;

namespace WorldEntity
{
    public class Pickup : MonoBehaviour, IInteractible
    {
        [SerializeField] private BuildItemType itemType;
        
        public void Interact(Transform caller)
        {
            if (caller.GetComponent<IHotbarSystem>() != null)
            {
                caller.GetComponent<IHotbarSystem>().HotbarSystem.Add(itemType);
                Destroy(this.gameObject);
            }
        }
    }
}