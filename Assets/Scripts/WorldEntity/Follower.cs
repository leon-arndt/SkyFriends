using Events;
using ScriptableObjectSystems;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

namespace WorldEntity
{
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
    
    
        public void Init(FollowerSettings settings)
        {
            skillSystem = settings.SkillSystem;
            agent = settings.Agent;
            target = settings.Target;
        }

        public struct FollowerSettings
        {
            public SkillSystem SkillSystem;
            public NavMeshAgent Agent;
            public ScriptableVector3 Target;
        }
    }
}
