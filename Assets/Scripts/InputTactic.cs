using Events;
using UniRx;
using UnityEngine;

public class InputTactic : MonoBehaviour
{
    [SerializeField]
    private ScriptableInt tactic;

    private void Start()
    {
        tactic.value = default;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            tactic.value = (int)Tactic.Attack;
            MessageBroker.Default.Publish(new TacticChanged());
        }
        else
        if (Input.GetKeyDown(KeyCode.E))
        {
            tactic.value = (int)Tactic.Follow;
            MessageBroker.Default.Publish(new TacticChanged());
        }
    }
}
    
public enum Tactic
{
    None,
    Attack,
    Follow,
}