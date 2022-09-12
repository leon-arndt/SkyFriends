using System.Linq;
using Events;
using ScriptableObjectSystems;
using UniRx;
using UnityEngine;

namespace UserInterface.Overlay
{
    public class SkillsView : MonoBehaviour
    {
        [SerializeField] private RectTransform holder;
        [SerializeField] private SkillView skillViewPrefab;
        [SerializeField] private SkillSystem skillSystem;
        [SerializeField] private SkillTypeConfigList skillTypeConfigList;

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
                var icon = skillTypeConfigList.skills.FirstOrDefault(x => x.type == skill.Key).icon;
                skillView.Display(skill, icon);
            }
        }
    }
}
