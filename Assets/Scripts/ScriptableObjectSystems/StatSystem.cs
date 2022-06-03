using System.Collections.Generic;
using DefaultNamespace;
using Events;
using UniRx;
using UnityEngine;

namespace ScriptableObjectSystems
{
    [CreateAssetMenu(menuName = "StatSystem")]
    public class StatSystem : ScriptableObject, IResettable
    {
        private Dictionary<StatType, StatData> _current;

        private void OnEnable()
        {
            Reset();
        }

        private StatSystem()
        {
            Reset();
        }

        public void Reset()
        {
            _current = new Dictionary<StatType, StatData>();
            _current[StatType.Health] = new StatData{amount = 100};
            _current[StatType.MaxHealth] = new StatData{amount = 100};
            _current[StatType.UltimateCharge] = new StatData{amount = 0};
            _current[StatType.MaxUltimateCharge] = new StatData{amount = 100};
            MessageBroker.Default.Publish(new StatChanged());
        }

        public void Set(StatType type, StatData amount)
        {
            _current[type] = amount;
            MessageBroker.Default.Publish(new StatChanged());
        }

        public StatData Get(StatType type)
        {
            if (_current.TryGetValue(type, out var result))
            {
                return result;
            }

            return default;
        }
        
        public Dictionary<StatType, StatData> GetAll()
        {
            return _current ?? new Dictionary<StatType, StatData>();
        }

        public void Gain(StatType type, uint amount)
        {
            var current = Get(type);
            var statData = new StatData{amount = current.amount + (int) amount};
            Set(type, statData);
        }
    
        public void Subtract(StatType type, uint amount)
        {
            var current = Get(type);
            var statData = new StatData{amount = current.amount - (int) amount};
            Set(type, statData);
        }
    }
}