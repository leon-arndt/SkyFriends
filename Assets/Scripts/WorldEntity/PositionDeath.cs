using UnityEngine;

namespace WorldEntity
{
    public class PositionDeath : MonoBehaviour
    {
        [SerializeField] private ScriptableVector3 playerPosition;
        [SerializeField] private ScriptableVector3 playerInitPosition;
        [SerializeField] private sbyte killFloorHeight = -10;
        private void Start()
        {
            playerInitPosition.value = transform.position;
        }

        private void Update()
        {
            if (transform.position.y < killFloorHeight)
            {
                var controller = GetComponent<CharacterController>();
                controller.enabled = false;
                transform.position = playerInitPosition.value;
                controller.enabled = true;
                playerPosition.value = playerInitPosition.value;
            }
        }
    }
}