using ScriptableObjectSystems;
using UnityEngine;

namespace ItemTypes
{
    [CreateAssetMenu(menuName = "RangedPhysicsItemType")]
    public class RangedPhysicsItemType : ScriptableObject, IHotbarItemType
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
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var spawnPos = faction.leaderPosition.value;
            cube.transform.position = spawnPos + _camera.transform.forward;
            var rigid = cube.AddComponent<Rigidbody>();
            rigid.AddForce(_camera.transform.forward * 1500);
            rigid.AddTorque(Random.onUnitSphere * 100_000)
            ;
        }
    
        public void UseAlternative()
        {
        }

        public Sprite GetIcon()
        {
            return sprite;
        }
    }
}
