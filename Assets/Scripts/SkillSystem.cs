using System.Collections.Generic;
using Events;
using UniRx;
using UnityEngine;

[CreateAssetMenu(menuName = "SkillSystem")]
public class SkillSystem : ScriptableObject
{
    private Dictionary<SkillType, SkillData> _current;

    private void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        _current = new Dictionary<SkillType, SkillData>();
    }

    public void Set(SkillType type, SkillData amount)
    {
        _current[type] = amount;
        MessageBroker.Default.Publish(new SkillChanged());
    }

    public SkillData Get(SkillType type)
    {
        if (_current.TryGetValue(type, out var result))
        {
            return result;
        }

        return default;
    }
        
    public Dictionary<SkillType, SkillData> GetAll()
    {
        return _current ?? new Dictionary<SkillType, SkillData>();
    }

    public void Gain(SkillType type, uint amount)
    {
        var current = Get(type);
        var newSkillData = new SkillData{level = current.level + (int) amount};
        Set(type, newSkillData);
    }
}