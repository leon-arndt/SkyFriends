using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    
    [SerializeField]
    private ScriptableVector3 target;

    private void Update()
    {
        agent.stoppingDistance = 3f;
        agent.destination = target.value;
    }
}
