using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Overlay
{
    public class HotbarElementView : MonoBehaviour
    {
        [SerializeField] private Image icon;
        public void Display(IHotbarItemType itemType)
        {
            icon.sprite = itemType.GetIcon();
        }
    }
}