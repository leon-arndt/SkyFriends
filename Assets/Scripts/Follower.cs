using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    
    [SerializeField]
    private ScriptableVector3 target;

    private void Update()
    {
        agent.destination = target.value;
    }
}
