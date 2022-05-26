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
            if (Input.GetMouseButtonDown(0))
            {
                hotbarSystem.UseActive();
            }
        
            if (Input.GetMouseButtonDown(1))
            {
                hotbarSystem.UseActiveAlternative();
            }
            
            // TODO: consider reducing code duplication of hotbar slots
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                hotbarSystem.SetActive(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                hotbarSystem.SetActive(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                hotbarSystem.SetActive(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                hotbarSystem.SetActive(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                hotbarSystem.SetActive(4);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                hotbarSystem.SetActive(5);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                hotbarSystem.SetActive(6);
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                hotbarSystem.SetActive(7);
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                hotbarSystem.SetActive(8);
            }
        }
    }
}
