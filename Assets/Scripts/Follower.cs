using Events;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    [SerializeField] private SkillSystem skillSystem;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private ScriptableVector3 target;

    private bool _isTame;
    
    private void Update()
    {
        if (_isTame)
        {
            agent.stoppingDistance = 3f;
            agent.destination = target.value;
        }
        else
        {
            if (Vector3.Distance(transform.position, target.value) < 3f)
            {
                _isTame = true;
                skillSystem.Gain(SkillType.Taming, 1);
                MessageBroker.Default.Publish(new SkillChanged());
            }
        }

    }
}
