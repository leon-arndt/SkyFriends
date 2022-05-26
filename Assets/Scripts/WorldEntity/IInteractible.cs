using UnityEngine;

namespace WorldEntity
{
    public interface IInteractible
    {
        public void Interact(Transform caller);
    }
}