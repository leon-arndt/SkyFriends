using Events;
using TMPro;
using UniRx;
using UnityEngine;

namespace UserInterface
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private StatSystem statSystem;
        [SerializeField] private TextMeshProUGUI health, energy;
        
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
            health.text = statSystem.Get(StatType.Health).amount.ToString();
        }
    }
}