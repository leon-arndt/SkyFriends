using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Attacker : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Faction faction;
    [SerializeField] private Damageable damageable;
    [SerializeField] private uint attackPower = 1;
    [SerializeField] private uint aggroRange = 10;

    private void Update()
    {
        if (damageable == null)
        {
            damageable = FindObjectsOfType<Damageable>()
                .FirstOrDefault(CanAggro());
        }

        if (damageable == null) return;

        var targetPosition = damageable.transform.position;
        agent.destination = targetPosition;
        var attackDistance = 2f;

        switch (Vector3.Distance(targetPosition, transform.position))
        {
            case var distance when distance < attackDistance:
                damageable.Damage(faction, attackPower);
                break;
            case var distance when distance > aggroRange * 1.2f:
                damageable = null;
                break;
        }
    }

    private Func<Damageable, bool> CanAggro()
    {
        return x =>
            x.Faction.value != faction.value &&
            Vector3.Distance(transform.position, x.transform.position) <= aggroRange;
    }
}