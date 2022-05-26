using Events;
using TMPro;
using UniRx;
using UnityEngine;

namespace UserInterface
{
    public class TacticView : MonoBehaviour
    {
        [SerializeField] private ScriptableInt tacticSystem;
        [SerializeField] private TextMeshProUGUI tacticName;
        
        private void Start()
        {
            UpdateView();
            MessageBroker.Default
                .Receive<TacticChanged>()
                .TakeUntilDestroy(this)
                .Subscribe(_ => UpdateView());
        }

        private void UpdateView()
        {
            tacticName.text = ((Tactic) tacticSystem.value).ToString();
        }
    }
}