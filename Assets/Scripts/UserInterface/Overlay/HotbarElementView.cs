using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Overlay
{
    public class HotbarElementView : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private GameObject activeIndicator;
        
        public void Display(IHotbarItemType itemType, bool isActive)
        {
            icon.sprite = itemType.GetIcon();
            activeIndicator.SetActive(isActive);
        }
    }
}