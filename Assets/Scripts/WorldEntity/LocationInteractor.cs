using UnityEngine;

namespace WorldEntity
{
    public class LocationInteractor : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<IInteractible>()?.Interact(transform);
        }
    }
}