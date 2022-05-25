using Events;
using UniRx;
using UnityEngine;

public class Friend : MonoBehaviour
{
    [SerializeField] private ScriptableInt tacticSystem;
    [SerializeField] private Follower follower;
    [SerializeField] private Attacker attacker;

    private void Start()
    {
        UpdateBehaviour();
        MessageBroker.Default
            .Receive<TacticChanged>()
            .TakeUntilDestroy(this)
            .Subscribe(_ => UpdateBehaviour());
    }

    private void UpdateBehaviour()
    {
        if (tacticSystem.value == (int)Tactic.Follow)
        {
            follower.enabled = true;
            attacker.enabled = false;
        }
        else
        {
            follower.enabled = false;
            attacker.enabled = true;
        }
    }
}