using UnityEngine;

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
    }
}