using Events;
using UniRx;
using UnityEngine;

namespace UserInterface.Overlay
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private StatSystem statSystem;
        [SerializeField] private TextMeshSlider health, energy;
        
        private void Start()
        {
            DisplayCurrentStats();
            MessageBroker.Default
                .Receive<StatChanged>()
                .TakeUntilDestroy(this)
                .Subscribe(_ => DisplayCurrentStats());
        }
        
        private void DisplayCurrentStats()
        {
            var currentHealth = statSystem.Get(StatType.Health).amount;
            var maxHealth = statSystem.Get(StatType.MaxHealth).amount;
            health.Set((float)currentHealth / maxHealth, $"{currentHealth}/{maxHealth}");
            
            var currentCharge = statSystem.Get(StatType.UltimateCharge).amount;
            var maxCharge = statSystem.Get(StatType.MaxUltimateCharge).amount;
            energy.Set((float)currentCharge / maxCharge, $"{currentCharge}/{maxCharge}");
        }
    }
}