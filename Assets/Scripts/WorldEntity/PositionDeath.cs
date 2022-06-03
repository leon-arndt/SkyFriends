using ScriptableObjectSystems;
using UnityEngine;

namespace WorldEntity
{
    public class PositionDeath : MonoBehaviour
    {
        [SerializeField] private ScriptableVector3 playerPosition;
        [SerializeField] private ScriptableVector3 playerInitPosition;
        [SerializeField] private LifeTimeSystem lifeTimeSystem;
        [SerializeField] private sbyte killFloorHeight = -10;

        private void Start()
        {
            playerInitPosition.value = transform.position;
        }

        private void Update()
        {
            if (transform.position.y < killFloorHeight)
            {
                Reset();
            }
        }

        private void Reset()
        {
            var controller = GetComponent<CharacterController>();
            controller.enabled = false;
            transform.position = playerInitPosition.value;
            controller.enabled = true;
            playerPosition.value = playerInitPosition.value;

            lifeTimeSystem.Reset();
        }
    }
}