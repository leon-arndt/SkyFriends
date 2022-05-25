using Events;
using UniRx;
using UnityEngine;

public class SkillsView : MonoBehaviour
{
    [SerializeField] private RectTransform holder;
    [SerializeField] private SkillView skillViewPrefab;
    [SerializeField] private SkillSystem skillSystem;

    private void Start()
    {
        DisplayCurrentSkills();
        MessageBroker.Default
            .Receive<SkillChanged>()
            .TakeUntilDestroy(this)
            .Subscribe(_ => DisplayCurrentSkills());
    }

    private void DisplayCurrentSkills()
    {
        foreach (var child in holder.gameObject.GetComponentsInChildren<SkillView>())
        {
            Destroy(child.gameObject);
        }

        foreach (var skill in skillSystem.GetAll())
        {
            var skillView = Instantiate(skillViewPrefab, holder);
            skillView.Display(skill);
        }
    }
}