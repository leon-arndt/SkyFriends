using Events;
using TMPro;
using UniRx;
using UnityEngine;

namespace UserInterface
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private StatSystem statSystem;
        [SerializeField] private TextMeshSlider health, energy;
        
        private void Start()
        {
            DisplayCurrentSkills();
            MessageBroker.Default
                .Receive<StatChanged>()
                .TakeUntilDestroy(this)
                .Subscribe(_ => DisplayCurrentSkills());
        }
        
        private void DisplayCurrentSkills()
        {
            var currentHealth = statSystem.Get(StatType.Health).amount;
            var maxHealth = statSystem.Get(StatType.MaxHealth).amount;
            health.Set((float)currentHealth / maxHealth, $"{currentHealth}/{maxHealth}");
        }
    }
}