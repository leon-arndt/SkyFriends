using UnityEngine;

namespace WorldEntity
{
    public class Portal : MonoBehaviour
    {
        public Transform target;

        public void OnTriggerEnter(Collider other)
        {
            var controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
                other.gameObject.transform.position = target.position;
                controller.enabled = true;
            }
            else
            {
                other.gameObject.transform.position = target.position;
            }
        }
    }
}