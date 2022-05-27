﻿using UnityEngine;
using UnityEngine.AI;

namespace WorldEntity
{
    public class Damageable : MonoBehaviour
    {
        public Faction Faction => faction;

        [SerializeField] private StatSystem statSystem;
        [SerializeField] private SkillSystem skillSystem;
        [SerializeField] private Faction faction;

        private void OnEnable()
        {
            if (statSystem == null)
            {
                statSystem = ScriptableObject.CreateInstance<StatSystem>();
            }

            if (skillSystem == null)
            {
                skillSystem = ScriptableObject.CreateInstance<SkillSystem>();
            }
        }

        public void Damage(Faction source, uint amount)
        {
            if (source.value == faction.value)
                return;

            statSystem.Subtract(StatType.Health, amount);
            skillSystem.Gain(SkillType.Construction, amount);

            if (statSystem.Get(StatType.Health).amount <= 0)
            {
                if (faction.isBefriendable && Random.value < 0.1f)
                {
                    Befriend(source);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

        private void Befriend(Faction source)
        {
            faction = source;
            GetComponent<Attacker>().Set(source);
            statSystem.Gain(StatType.Health, 100);
            var follower = gameObject.AddComponent<Follower>();
            var settings = new Follower.FollowerSettings
            {
                SkillSystem = skillSystem,
                Agent = GetComponent<NavMeshAgent>(),
                Target = faction.leaderPosition
            };
            follower.Init(settings);
        }
    }
}