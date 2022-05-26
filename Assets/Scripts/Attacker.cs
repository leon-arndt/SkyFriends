using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Attacker : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Faction faction;
    [SerializeField] private Damageable damageable;
    [SerializeField] private uint attackPower = 1;
    
    private void Update()
    {
        if (damageable == null)
        {
            damageable = FindObjectsOfType<Damageable>()
                .FirstOrDefault(x => x.Faction.value != faction.value);
        }

        if (damageable == null) return;
        
        agent.destination = damageable.transform.position;
        var attackDistance = 2f;
        if (Vector3.Distance(damageable.transform.position, transform.position) < attackDistance)
        {
            damageable.Damage(faction, attackPower);
        }   
    }
}