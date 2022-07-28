using System;
using ScriptableObjectSystems;
using UnityEngine;

namespace WorldEntity
{
    public class Pickup : MonoBehaviour, IInteractible
    {
        [SerializeField] private ScriptableObject itemType;

        public void Interact(Transform caller)
        {
            switch (itemType)
            {
                case IHotbarItemType hotbarItemType:
                    if (caller.GetComponent<IHotbarSystem>() != null)
                    {
                        caller.GetComponent<IHotbarSystem>().HotbarSystem.Add(hotbarItemType);
                        gameObject.SetActive(false);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}
