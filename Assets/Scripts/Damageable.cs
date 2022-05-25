using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private StatSystem statSystem;
    [SerializeField] private SkillSystem skillSystem;
    [SerializeField] private Faction faction;

    public void Damage(Faction source, uint amount)
    {
        if (source.value == faction.value)
            return;
        
        statSystem.Subtract(StatType.Health, amount);
        skillSystem.Gain(SkillType.Construction, amount);
    }
}