using Events;
using ScriptableObjectSystems;
using UniRx;
using UnityEngine;

namespace GameInput
{
    public class InputHotbar : MonoBehaviour, IHotbarSystem
    {
        [SerializeField]
        private HotbarSystem hotbarSystem;

        public HotbarSystem HotbarSystem => hotbarSystem;
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                hotbarSystem.SetActive(0);
            }
        
            if (Input.GetMouseButtonDown(0))
            {
                hotbarSystem.UseActive();
            }
        
            if (Input.GetMouseButtonDown(1))
            {
                hotbarSystem.UseActiveAlternative();
            }
        }
    }
}
