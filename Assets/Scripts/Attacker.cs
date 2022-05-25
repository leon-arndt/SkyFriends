using UnityEngine;
using UnityEngine.AI;

public class Attacker : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] Faction faction;
    [SerializeField] private ScriptableVector3 targetPosition;
    [SerializeField] private uint attackPower = 5;
    
    private void Update()
    {
        agent.destination = targetPosition.value;
        
        if (Vector3.Distance(agent.destination, transform.position) < 2)
        {
            FindObjectOfType<Damageable>().Damage(faction, attackPower);
        }
    }
}