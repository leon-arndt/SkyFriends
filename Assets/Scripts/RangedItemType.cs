using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(menuName = "RangedItemType")]
public class RangedItemType : ScriptableObject, IHotbarItemType
{
    [SerializeField] private uint maxInteractDistance = 20;
    [SerializeField] private uint attackPower = 10;
    [SerializeField] private SkillSystem skillSystem;
    [SerializeField] private StatSystem statSystem;
    [SerializeField] private Faction faction;
    [SerializeField] private Sprite sprite;
    private Camera _camera;
    
    private void OnEnable()
    {
        _camera = Camera.main;
    }

    public void Use()
    {
        RaycastHit[] hits;
        var cameraTransform = _camera.transform;
        hits = Physics.RaycastAll(cameraTransform.position, cameraTransform.forward, maxInteractDistance);

        foreach (var hit in hits)
        {
            var damageable = hit.transform.GetComponent<Damageable>();

            if (!damageable) continue;
            skillSystem.Gain(SkillType.Ranged, 2);
            statSystem.Gain(StatType.UltimateCharge, 12);
            damageable.Damage(faction, attackPower);
        }
    }

    public void UseAlternative()
    {
        if (statSystem.Get(StatType.UltimateCharge).amount < statSystem.Get(StatType.MaxUltimateCharge).amount) return;
        
        statSystem.Set(StatType.UltimateCharge, new StatData{amount = 0});

        RaycastHit[] hits;
        var cameraTransform = _camera.transform;
        hits = Physics.RaycastAll(cameraTransform.position, cameraTransform.forward, maxInteractDistance);

        foreach (var hit in hits)
        {
            var damageable = hit.transform.GetComponent<Damageable>();

            if (!damageable) continue;
            skillSystem.Gain(SkillType.Ranged, 10);
            damageable.Damage(faction, attackPower);
        }
    }

    public Sprite GetIcon()
    {
        return sprite;
    }
}