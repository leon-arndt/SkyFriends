using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Overlay
{
    public class HotbarElementView : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private GameObject activeIndicator;

        private void Start()
        {
	        const float animationSeconds = 0.2f;
	        transform.DOScale(1f, animationSeconds).From(0f).SetEase(Ease.OutBack);
        }

        public void Display(IHotbarItemType itemType, bool isActive)
        {
            icon.sprite = itemType.GetIcon();
            activeIndicator.SetActive(isActive);
        }
    }
}
