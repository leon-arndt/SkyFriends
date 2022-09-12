using UnityEngine;
using WorldEntity;

[CreateAssetMenu(menuName = "ScriptableObjects/BuildItemType")]
public class BuildItemType : ScriptableObject, IHotbarItemType
{
    [SerializeField] private uint maxInteractDistance = 20;
    [SerializeField] private SkillSystem skillSystem;
    [SerializeField] private Sprite sprite;

    private Camera _camera;

    private void OnEnable()
    {
        _camera = Camera.main;
    }

    public void Use()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out var hit, maxInteractDistance))
        {
            if (!hit.transform.TryGetComponent(out Destructible _)) return;
            skillSystem.Gain(SkillType.Destruction, 1);
            Destroy(hit.transform.gameObject);
        }
    }

    public void UseAlternative()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out var hit, maxInteractDistance))
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = hit.point.Round();

            skillSystem.Gain(SkillType.Construction, 1);
        }
    }

    public Sprite GetIcon()
    {
        return sprite;
    }
}
